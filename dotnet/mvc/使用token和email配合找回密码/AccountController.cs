using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using LifeScan.Filters;
using LifeScan.Models;

namespace LifeScan.Controllers
{
   

    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login

        UsersContext UsersDB = new UsersContext();


        //重置密码
        [AllowAnonymous]
        public ActionResult FindPWD()
        {
            return View();
        }
        //重置密码，通过邮件获取token值
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult FindPWDByEmail()
        {
            string Message = "";
            string email = Request.Form["email"];

            string name = Request.Form["uname"];
            UserProfile userProfile = UsersDB.UserProfiles.Where(i => i.UserName == email).Single();
            if (name == userProfile.Name)
            {

                string token = WebSecurity.GeneratePasswordResetToken(email);
             

                ViewBag.email = email;
                ViewBag.pwd = token;
                //获取主机域名
                string domain = System.Configuration.ConfigurationManager.AppSettings["DomainName"].ToString();
                string local = "Account/SetPWDByTokenView?token=" + token + "";
                string URL = "<a href='" + domain + local + "'>进入密码重置页面</a>";
                string eboby = "您的账号为：" + name + "</br> 请点击下面的链接，完成密码重置（有效期为24小时）</br>" + URL ;
                ViewBag.message = Email.FindPWDByEmail(email, eboby);
            }
            else
            {
                Message = "Email和用户名不匹配";
                ViewBag.message = Message;
            }

            return View();
        }
        //重置密码，根据邮件获取的token值，设置密码
        [AllowAnonymous]
        public ActionResult SetPWDByTokenView()
        {
            ViewBag.token = Request.QueryString["token"];
            return View();
        }
        //重置密码，根据邮件获取的token值，设置密码，保存密码
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SetPWDByToken()
        {
            string token = Request.Form["token"];
            string pwd = Request.Form["Password"];
            try
            {
                WebSecurity.ResetPassword(token, pwd);
            }
            catch
            {
               
            }
            return View();
        }


        //快速注册用户注册
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult FastRegisterPost(RegisterModel model) 
        {
            if (ModelState.IsValid)
            {
                // 尝试注册用户
                try
                {
                    //首先注册用户
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    Email.RegisterReminder("新用户注册提醒！注册ID：" + model.UserName + ",姓名：" + model.Name +
                                     ",移动电话：" + model.MobilePhone + ",注册时间：" + DateTime.Now
                                     );
                    //附加用户Profile信息
                    UserProfile adduser = UsersDB.UserProfiles.Where(i => i.UserName == model.UserName).Single();
                    adduser.MobilePhone = model.MobilePhone;
                    adduser.Name = model.Name;
                    UsersDB.SaveChanges();
                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToAction("FastRegisterView", "Account");

                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            //return View("_FastRegister",model);
            return View("Register", model);
         
        }
        //快速注册补充页面
        [Authorize]
        public ActionResult FastRegisterView(string returnUrl)
        {
            return View();
        }

        //快速注册补充页面提交
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]      
        public ActionResult FastRegisterSubmit(AttachRegisterModel model) //快速注册补充用户信息
        {
            if (ModelState.IsValid)
            {
                // 尝试注册用户
                try
                {
                    
                    #region 附加用户Profile信息
                    UserProfile AttachUser = UsersDB.UserProfiles.Where(i => i.UserName ==  User.Identity.Name).Single();


                    AttachUser.Phone = model.Phone;
                    AttachUser.Birth = model.Birth;
                    AttachUser.Country = model.Country;
                    AttachUser.Place = model.Place;
                    AttachUser.Address = model.Address;
                    AttachUser.ZipCode = model.ZipCode;
                    AttachUser.WantGet = model.WantGet;
                    AttachUser.HasGlucometer = model.HasGlucometer;
                    AttachUser.GlucometerType = model.GlucometerType;
                    AttachUser.GlucometerId = model.GlucometerId;
                    AttachUser.IsWantGetInformation = model.IsWantGetInformation;

                    AttachUser.Gender = model.Gender;
                    AttachUser.DateOfDiagnosis = model.DateOfDiagnosis;
                    AttachUser.DiabetesType = model.DiabetesType;
                    //adduser.DiseaseControl = model.DiseaseControl;
                    AttachUser.DiseaseControl = Request.Form["DiseaseControl"];
                    // adduser.HasRecommend = model.HasRecommend;
                    AttachUser.HasRecommend = Request.Form["HasRecommend"];
                    AttachUser.TestFrequency = model.TestFrequency;
                    #endregion


                        UsersDB.SaveChanges();
                   

                    //     WebSecurity.Login(model.UserName, model.Password);
                        return RedirectToAction("RegisterSuccess", "Account");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
                // 如果我们进行到这一步时某个地方出错，则重新显示表单
            }
            return View(model);

        }

        [AllowAnonymous]
        public ActionResult FastRegister()
        {
            return PartialView("_FastRegister");
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                return RedirectToLocal(returnUrl);
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            ModelState.AddModelError("", "提供的用户名或密码不正确。");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        //用户详细注册页面
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
      
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // 尝试注册用户
                try
                {
                    //首先注册用户
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    Email.RegisterReminder("新用户注册提醒！注册ID：" + model.UserName + ",姓名：" + model.Name +
                                      ",移动电话：" + model.MobilePhone + ",注册时间：" + DateTime.Now
                                      );
                    #region 附加用户Profile信息
                    UserProfile adduser = UsersDB.UserProfiles.Where(i => i.UserName == model.UserName).Single();

                    adduser.Name = model.Name; //用户名 必填
                    adduser.MobilePhone = model.MobilePhone;//移动电话 必填

                    adduser.Phone = model.Phone;
                    adduser.Birth = model.Birth;
                    adduser.Country = model.Country;
                    adduser.Place = model.Place;
                    adduser.Address = model.Address;
                    adduser.ZipCode = model.ZipCode;
                    adduser.WantGet = model.WantGet;
                    adduser.HasGlucometer = model.HasGlucometer;
                    adduser.GlucometerType = model.GlucometerType;
                    adduser.GlucometerId = model.GlucometerId;
                    adduser.IsWantGetInformation = model.IsWantGetInformation;

                    adduser.Gender = model.Gender;
                    adduser.DateOfDiagnosis = model.DateOfDiagnosis;
                    adduser.DiabetesType = model.DiabetesType;
                    //adduser.DiseaseControl = model.DiseaseControl;
                    adduser.DiseaseControl = Request.Form["DiseaseControl"];
                    // adduser.HasRecommend = model.HasRecommend;
                    adduser.HasRecommend = Request.Form["HasRecommend"];
                    adduser.TestFrequency = model.TestFrequency; 
                    #endregion
                   
        
                    try
                    {
                        UsersDB.SaveChanges();
                    }
                    catch
                    { 
                        //删除用户
                        if (WebSecurity.UserExists(model.UserName))
                        {
                            SimpleMembershipProvider smp = new SimpleMembershipProvider();
                            smp.DeleteAccount(model.UserName);

                        }
                    }
                  
                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToAction("RegisterSuccess", "Account");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult RegisterSuccess()
        {
           return View();
        }
        //
        // POST: /Account/Disassociate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId)
        {
            string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            ManageMessageId? message = null;

            // 只有在当前登录用户是所有者时才取消关联帐户
            if (ownerAccount == User.Identity.Name)
            {
                // 使用事务来防止用户删除其上次使用的登录凭据
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
                    if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
                    {
                        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
                        scope.Complete();
                        message = ManageMessageId.RemoveLoginSuccess;
                    }
                }
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage

        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "已更改你的密码。"
                : message == ManageMessageId.SetPasswordSuccess ? "已设置你的密码。"
                : message == ManageMessageId.RemoveLoginSuccess ? "已删除外部登录。"
                : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.HasLocalPassword = hasLocalAccount;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasLocalAccount)
            {
                if (ModelState.IsValid)
                {
                    // 在某些失败方案中，ChangePassword 将引发异常，而不是返回 false。
                    bool changePasswordSucceeded;
                    try
                    {
                        changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                    }
                    catch (Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError("", "当前密码不正确或新密码无效。");
                    }
                }
            }
            else
            {
                // 用户没有本地密码，因此将删除由于缺少
                // OldPassword 字段而导致的所有验证错误
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e);
                    }
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
            {
                return RedirectToLocal(returnUrl);
            }

            if (User.Identity.IsAuthenticated)
            {
                // 如果当前用户已登录，则添加新帐户
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // 该用户是新用户，因此将要求该用户提供所需的成员名称
                string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
                ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
                ViewBag.ReturnUrl = returnUrl;
                return View("ExternalLoginConfirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
        {
            string provider = null;
            string providerUserId = null;

            if (User.Identity.IsAuthenticated || !OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, out provider, out providerUserId))
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // 将新用户插入到数据库
                using (UsersContext db = new UsersContext())
                {
                    UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());
                    // 检查用户是否已存在
                    if (user == null)
                    {
                        // 将名称插入到配置文件表
                        db.UserProfiles.Add(new UserProfile { UserName = model.UserName });
                        db.SaveChanges();

                        OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
                     //   OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "用户名已存在。请输入其他用户名。");
                    }
                }
            }

            ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // GET: /Account/ExternalLoginFailure

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        [ChildActionOnly]
        public ActionResult RemoveExternalLogins()
        {
            ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);
            List<ExternalLogin> externalLogins = new List<ExternalLogin>();
            foreach (OAuthAccount account in accounts)
            {
                AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

                externalLogins.Add(new ExternalLogin
                {
                    Provider = account.Provider,
                    ProviderDisplayName = clientData.DisplayName,
                    ProviderUserId = account.ProviderUserId,
                });
            }

            ViewBag.ShowRemoveButton = externalLogins.Count > 1 || OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            return PartialView("_RemoveExternalLoginsPartial", externalLogins);
        }
        [AllowAnonymous]
        public ActionResult Test()
        {           
            return View();
        }
        #region 帮助程序
      
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // 请参见 http://go.microsoft.com/fwlink/?LinkID=177550 以查看
            // 状态代码的完整列表。
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "用户名已存在。请输入其他用户名。";

                case MembershipCreateStatus.DuplicateEmail:
                    return "该电子邮件地址的用户名已存在。请输入其他电子邮件地址。";

                case MembershipCreateStatus.InvalidPassword:
                    return "提供的密码无效。请输入有效的密码值。";

                case MembershipCreateStatus.InvalidEmail:
                    return "提供的电子邮件地址无效。请检查该值并重试。";

                case MembershipCreateStatus.InvalidAnswer:
                    return "提供的密码取回答案无效。请检查该值并重试。";

                case MembershipCreateStatus.InvalidQuestion:
                    return "提供的密码取回问题无效。请检查该值并重试。";

                case MembershipCreateStatus.InvalidUserName:
                    return "提供的用户名无效。请检查该值并重试。";

                case MembershipCreateStatus.ProviderError:
                    return "身份验证提供程序返回了错误。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。";

                case MembershipCreateStatus.UserRejected:
                    return "已取消用户创建请求。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。";

                default:
                    return "发生未知错误。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。";
            }
        }
        #endregion
    }
}
