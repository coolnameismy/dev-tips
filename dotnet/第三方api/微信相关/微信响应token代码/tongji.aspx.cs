using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Xml;
using System.IO;
using System.Text;

public partial class tongji : System.Web.UI.Page
{
    const string Token = "liuyw"; //你的token
    protected void Page_Load(object sender, EventArgs e)
    {
        string postStr = "";

        Valid();
        if (Request.HttpMethod.ToLower() == "post")
        {
            Stream s = System.Web.HttpContext.Current.Request.InputStream;
            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);
            postStr = Encoding.UTF8.GetString(b);
            if (!string.IsNullOrEmpty(postStr))
            {
                ResponseMsg(postStr);

            }

        }
    }
    ///
    /// 验证微信签名
    ///
    /// * 将token、timestamp、nonce三个参数进行字典序排序
    /// * 将三个参数字符串拼接成一个字符串进行sha1加密
    /// * 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。
    ///
    private bool CheckSignature()
    {
        string signature = Request.QueryString["signature"].ToString();
        string timestamp = Request.QueryString["timestamp"].ToString();
        string nonce = Request.QueryString["nonce"].ToString();
        string[] ArrTmp = { Token, timestamp, nonce };
        Array.Sort(ArrTmp);     //字典排序
        string tmpStr = string.Join("", ArrTmp);
        tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
        tmpStr = tmpStr.ToLower();
        if (tmpStr == signature)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Valid()
    {
        string echoStr = Request.QueryString["echoStr"].ToString();
        if (CheckSignature())
        {
            if (!string.IsNullOrEmpty(echoStr))
            {
                Response.Write(echoStr);
                Response.End();
            }
        }
    }

    ///
    /// 返回信息结果(微信信息返回)
    ///
    ///
    private void ResponseMsg(string weixinXML)
    {
        //回复消息的部分:你的代码写在这里

    }



    ///
    /// unix时间转换为datetime
    ///
    ///
    ///
    private DateTime UnixTimeToTime(string timeStamp)
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        long lTime = long.Parse(timeStamp + "0000000");
        TimeSpan toNow = new TimeSpan(lTime);
        return dtStart.Add(toNow);
    }

    ///
    /// datetime转换为unixtime
    ///
    ///
    ///
    private int ConvertDateTimeInt(System.DateTime time)
    {
        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        return (int)(time - startTime).TotalSeconds;
    }

    ///
    /// 写日志(用于跟踪)
    ///
    private void WriteLog(string strMemo)
    {
        string filename = Server.MapPath("/logs/log.txt");
        if (!Directory.Exists(Server.MapPath("//logs//")))
            Directory.CreateDirectory("//logs//");
        StreamWriter sr = null;
        try
        {
            if (!File.Exists(filename))
            {
                sr = File.CreateText(filename);
            }
            else
            {
                sr = File.AppendText(filename);
            }
            sr.WriteLine(strMemo);
        }
        catch
        {
        }
        finally
        {
            if (sr != null)
                sr.Close();
        }
    }
}
//    public class WeiXinHandler : IHttpHandler
//    {
//        string echostr
//        {
//            get
//            {
//                try
//                {
//                    return HttpContext.Current.Request["echostr"].ToString();
//                }
//                catch
//                {
//                    return "";
//                }
//            }


//        }
//        string signature
//        {
//            get
//            {
//                try
//                {
//                    return HttpContext.Current.Request["signature"].ToString();
//                }
//                catch
//                {
//                    return "";
//                }
//            }


//        }
//        string timestamp
//        {
//            get
//            {
//                try
//                {
//                    return HttpContext.Current.Request["timestamp"].ToString();
//                }
//                catch
//                {
//                    return "";
//                }
//            }


//        }
//        string nonce
//        {
//            get
//            {
//                try
//                {
//                    return HttpContext.Current.Request["nonce"].ToString();
//                }
//                catch
//                {
//                    return "";
//                }
//            }


//        }
//        string TOKEN = "liuyw";//根据个人需要填写


//        public void ProcessRequest(HttpContext context) 
//        { 
//            context.Response.ContentType = "text/plain"; 
//            if (context.Request.HttpMethod.ToUpper() == "POST") 
//            { 


                 
                
                     
//                    XmlDocument px=new XmlDocument(); 
//                    px.Load(context.Request.InputStream); 
                     
                     
//                    string fromUsername = px.GetElementsByTagName("FromUserName")[0].InnerText; 
//                    string toUsername = px.GetElementsByTagName("ToUserName")[0].InnerText; 
//                    string keyword = px.GetElementsByTagName("Content")[0].InnerText; 
//                    DateTime dt = DateTime.Now; 






                     
//                    string textTpl = "<xml> <ToUserName><![CDATA[" + fromUsername + @"]]></ToUserName>\r\n"; 
//                    textTpl += "<FromUserName><![CDATA[" + toUsername + @"]]></FromUserName>\r\n"; 
//                    textTpl += "<CreateTime>" + DateTime.Now + @"</CreateTime>\r\n"; 
//                    textTpl += "<MsgType><![CDATA[text]]></MsgType>\r\n"; 
//                    textTpl += "<Content><![CDATA[hehe:-)]]></Content>\r\n"; 
//                    textTpl += "<FuncFlag>0</FuncFlag>\r\n"; 
//                    textTpl+="</xml>"; 

//                    /*调试用 
//                    try 
//                    { 
//                        FileStream fs = new FileStream(context.Server.MapPath("weixin.txt"), FileMode.OpenOrCreate); 
//                        实例化一个StreamWriter-->与fs相关联   
//                        StreamWriter sw = new StreamWriter(fs); 
//                        开始写入   
//                        sw.Write(textTpl); 
//                        清空缓冲区   
//                        sw.Flush(); 
//                        关闭流   
//                        sw.Close(); 
//                        fs.Close(); 
//                    } 
//                    catch { }

//*/

//                    context.Response.Write(textTpl); 
                     
                 


                
                
//            } 
//            else 
//            { 
//                这部分是提供给微信公众平台验证使用的 
//                string[] pp = { TOKEN, timestamp, nonce }; 
//                Array.Sort(pp); 
//                string catPP = ""; 
//                for (int i = 0; i < 3; i++) 
//                { 
//                    catPP += pp[i]; 
//                } 


//                string p_p = FormsAuthentication.HashPasswordForStoringInConfigFile(catPP, "SHA1"); 
//                if (p_p.ToLower() == signature.ToLower()) 
//                    context.Response.Write(echostr); 
//            } 
             
             


               
             
//        }


//        public bool IsReusable
//        {
//            get
//            {
//                return false;
//            }
//        }
//    }

//}
