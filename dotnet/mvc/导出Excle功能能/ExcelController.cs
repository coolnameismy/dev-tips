using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using JNJWeb.Areas.LifeScanAdmin.Models;

namespace JNJWeb.Areas.LifeScanAdmin.Controllers
{
    public class ExcelController : Controller
    {
      
        //LifeScan 网站维护，用户导出注册用户信息 
        public void ExportUserData()
        {
            lifescanAdminEntities db = new lifescanAdminEntities();
            var result = db.UserProfile.ToList();

            StringBuilder sHtml = new StringBuilder(string.Empty);

            //打印表头（不加meta信息会出现Excel内容乱码！）
            sHtml.Append("<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=UTF-8\"/>"); // the key!!! 
            sHtml.Append("<table border=\"1\" width=\"100%\">");
            //   _date:"+DateTime.Now.ToString("yy/mm/dd")+
            sHtml.Append("<tr height=\"20\" align=\"center\" style='background-color:#CD0000'><td>用户账户</td><td>姓名</td><td>移动电话</td><td>联系电话</td><td>出生年月 </td><td>国家或地区</td>" +
                "<td>居住地</td><td>地址</td><td>邮编</td><td>我想获得</td><td>是否使用强生血糖仪产品</td>" +
                "<td>血糖仪的类型</td><td>血糖仪的序列号</td><td>“我想要强生(中国)医疗器材有限公司提供的糖尿病相关信息和促销信息资料”选项</td><td>性别</td><td>糖尿病诊断日期</td><td>糖尿病类型</td><td>管理您的糖尿病方法</td><td>有人推荐血糖仪给您吗？</td><td>您多久测试一次血糖呢？</td>" + "</tr>");


            foreach (var item in result)
            {

                sHtml.Append("<tr>");
                sHtml.Append("<td>"); sHtml.Append(item.UserName); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(item.Name); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(item.MobilePhone); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(item.Phone); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(item.Birth); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(item.Country); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(item.Place); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(item.Address); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(item.ZipCode); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(item.WantGet); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(item.HasGlucometer); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(item.GlucometerType); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append("num:" +item.GlucometerId); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append((item.IsWantGetInformation=="true")?"是":"否"); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(item.Gender); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(""+item.DateOfDiagnosis); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(item.DiabetesType); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(item.DiseaseControl); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(item.HasGlucometer); sHtml.Append("</td>");
                sHtml.Append("<td>"); sHtml.Append(item.TestFrequency); sHtml.Append("</td>");
                sHtml.Append("</tr>");
            }
            //打印表尾
            sHtml.Append("<tr height=\"20\"><td align=\"left\" colspan=\"19\" style='font-size:14px'><b> 导出数据日期：" + DateTime.Now + "</b></td></tr>");
            //调用输出Excel表的方法
            ExportToExcel("application/ms-excel", "LifeScan注册用户数据导出.xls", sHtml.ToString());
        }
        public void ExportToExcel(string FileType, string FileName, string ExcelContent)
        {
            System.Web.HttpContext.Current.Response.Charset = "GB2312";
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8).ToString());
            System.Web.HttpContext.Current.Response.ContentType = FileType;
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.HttpContext.Current.Response.Output.Write(ExcelContent.ToString());
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }
    }
}
