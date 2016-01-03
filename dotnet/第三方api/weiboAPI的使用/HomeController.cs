using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LifeScan.Models;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace LifeScan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            lifescanEntities db = new lifescanEntities();
            return View(db.Slides.OrderBy(i => i.Id).ToList());
        }
        public static List<T> JSONStringToList<T>(string JsonStr)
        {
            System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<T> objs = Serializer.Deserialize<List<T>>(JsonStr);
            return objs;
        }   
        //抓取官方微薄最新消息，sensitive账号
        public ActionResult WeiBoAPI1()
        {
            
            //sina授权的实例化
            var oauth = new NetDimension.Weibo.OAuth("2371575470", "4b03b21f941c30c091e995f63d7e5103", "http://127.0.0.1/NewLifeScan/home/WeiBoAPI");
            //access token 授权
            var result = oauth.ClientLogin("sensitive_liuyw@sina.com","weiZIPP1");
            string AccessToken = oauth.AccessToken; //还是来打印下AccessToken 

            var Sina = new NetDimension.Weibo.Client(oauth);
            var uid = Sina.API.Dynamic.Account.GetUID(); //调用API中获取UID的方法
         //   var NearestNews = Sina.API.Dynamic.Statuses.UserTimeline("1897719834","刘彦玮", "", "", 1, 1, true, 0);
            var NearestNews = Sina.API.Dynamic.Statuses.FriendsTimelineIDs();
            //weibo.com/u/2709878972

            
            //传递数据
            ViewBag.AccessToken = AccessToken;
            ViewBag.weiboResult = uid;
            ViewBag.NearestNews = NearestNews;
            ViewBag.MentionIDs = Sina.API.Dynamic.Statuses.MentionIDs();
            ViewBag.Mentions = Sina.API.Dynamic.Statuses.Mentions();
            ViewBag.UserTimeline = Sina.API.Dynamic.Statuses.UserTimeline();//获取用户发布的微薄列表
            var UserTimeline = Sina.API.Dynamic.Statuses.UserTimeline();


           var TILELINE = Sina.API.Entity.Statuses.UserTimeline();
           ViewBag.firstText =  TILELINE.Statuses.First().Text;
           
            //据说通过审核后可以使用功能，坐等
           //参考网址http://open.weibo.com/qa/index.php?qa=17410&qa_1=statuses-user_timeline%E5%8D%87%E7%BA%A7%E5%90%8E%E5%8F%AA%E8%83%BD%E8%AF%B7%E6%B1%82%E5%BD%93%E5%89%8D%E6%8E%88%E6%9D%83%E7%94%A8%E6%88%B7%E4%BF%A1%E6%81%AF
       //    var lifescanWeibo = Sina.API.Entity.Statuses.UserTimeline("2642246987");
       //   ViewBag.lifescanWeibo = lifescanWeibo.Statuses.FirstOrDefault().Text;
         
             ViewBag.test = "";
       
            return View();
        }
     
        
        //抓取官方微薄最新消息，我是it刘账号
        public ActionResult WeiBoAPI()
        {

            //sina授权的实例化
            var oauth = new NetDimension.Weibo.OAuth("3472401107", "21338ee3f6c6ff661945974ee2d0b2de", "http://127.0.0.1/NewLifeScan");
            //access token 授权
            var result = oauth.ClientLogin("13851488992", "851211");
            string AccessToken = oauth.AccessToken; //还是来打印下AccessToken 

            var Sina = new NetDimension.Weibo.Client(oauth);
            var uid = Sina.API.Dynamic.Account.GetUID(); //调用API中获取UID的方法
            //   var NearestNews = Sina.API.Dynamic.Statuses.UserTimeline("1897719834","刘彦玮", "", "", 1, 1, true, 0);
            var NearestNews = Sina.API.Dynamic.Statuses.FriendsTimelineIDs();
            //weibo.com/u/2709878972


            //传递数据
            ViewBag.AccessToken = AccessToken;
            ViewBag.weiboResult = uid;
            ViewBag.NearestNews = NearestNews;
            ViewBag.MentionIDs = Sina.API.Dynamic.Statuses.MentionIDs();
            ViewBag.Mentions = Sina.API.Dynamic.Statuses.Mentions();

            //获取朋友发的微博数据
            //测试地址：https://api.weibo.com/2/statuses/home_timeline.json?appkey=3472401107&&access_token=2.00z5kqwDTJqzmDeae65e57f77ge13E

            var HomeTimeline = Sina.API.Entity.Statuses;//获取用户发布的微薄列表
            ViewBag.User = uid;
          //  ViewBag.test = HomeTimeline.Statuses.ToList();
            ViewBag.UserTimeline = HomeTimeline;
                //from c in HomeTimeline.Statuses.ToList()
                //                   select new
                //                   {
                //                       c.User,
                //                       c.Text,
                //                       c.Source
                //                   };


            return View();
        }

    }
}
