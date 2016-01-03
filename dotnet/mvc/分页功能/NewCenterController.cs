using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiosealMVCWeb.Models;

namespace BiosealMVCWeb.Controllers
{
    public class NewsCenterController : Controller
    {
        //
        // GET: /NewCenter/
        biosealEntities db;
        public ActionResult Index()
        {
            db = new biosealEntities();
            //group by 分组遍历所有新闻，每个类别取前5条记录
            var News = from t in db.News
                       group t by t.CategoryId into g
                       select g.OrderByDescending(i => i.DateTime).Take(5);
         
            return View(News);
        }
        public ActionResult List()
        {
             //设置分页类
            int? pageIndex = Convert.ToInt16(Request.QueryString["pageIndex"]);
            pageIndex = (pageIndex == null ? 0 : pageIndex);

            int pageSize = 10; //设置每页显示条数

            //获取新闻分类列表的CategoryId
            int CategoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
            db = new biosealEntities();
            //获取置顶新闻
            var TopNewsId = db.TopNews.Single();
            var TopNews = db.News.Where(i => i.Id == TopNewsId.NewsID && i.CategoryId == CategoryId).SingleOrDefault();
            ViewBag.TopNews = TopNews;
            //获取分类列表的前20条记录
            var News = db.News.Where(i => i.Id != TopNewsId.NewsID && i.CategoryId == CategoryId).OrderByDescending(i => i.DateTime).Skip(pageIndex.Value * pageSize).Take(pageSize).ToList();


            ViewBag.Pagination = new Pagination(pageIndex, pageSize, db.News.Where(i => i.Id != TopNewsId.NewsID && i.CategoryId == CategoryId).Count());

            return View(News);
        }
        public ActionResult Detail()
        {
            db = new biosealEntities();

            int id = Convert.ToInt32(Request.QueryString["id"]);
            var news = db.News.Where(i => i.Id == id).Single();
            int NewsTypeId = news.CategoryId;
            //获取上一条下一条记录
            var prenews = db.News.Where(i => i.Id < id && i.CategoryId ==NewsTypeId).OrderByDescending(i => i.Id).FirstOrDefault();
            ViewBag.prenews = prenews;

            var nextnews = db.News.Where(i => i.Id > id && i.CategoryId == NewsTypeId).OrderBy(i => i.Id).FirstOrDefault();
            ViewBag.nextnews = nextnews;

            return View(news);
        }
        public ActionResult Download()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult NewsMenu(int id)
        {
            db = new biosealEntities();
            var menu = db.Categories.ToList();
            //id 为890413时，代表资料下载位当前样式
            //id 为851211时，代表无当前样式
            ViewBag.cur = id;
            return PartialView(menu);
        }
    }
}
