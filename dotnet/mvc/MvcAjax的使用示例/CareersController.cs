using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiosealMVCWeb.Models;
namespace BiosealMVCWeb.Controllers
{
    public class CareersController : Controller
    {
        //
        // GET: /Careers/
        biosealEntities db;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult AjaxRecruits()
        {
            db = new biosealEntities();
            //获取页面索引pageIndex
            int? pageIndex = Convert.ToInt16(Request.QueryString["pageIndex"]);
            pageIndex = (pageIndex == null ? 0 : pageIndex);
            //设置每页显示条数
            int pageSize = 8;

            //查询数据和设置分页Pagination类
            var recruits = db.Recruits.OrderByDescending(i => i.Date).Skip(pageIndex.Value * pageSize).Take(pageSize).ToList();
            ViewBag.Pagination = new Pagination(pageIndex, pageSize, db.Recruits.Count());
            ViewBag.pageIndex = pageIndex;

            // 返回json数据集
            var results = new List<Recruit>();
            foreach (var item in recruits)
            {
                results.Add(item);
            }
            return Json(results); 
       
        }
        [HttpPost]
        public ActionResult AjaxContract()
        {
            //获取pageIndex

            db = new biosealEntities();
            int? pageIndex = Convert.ToInt16(Request.QueryString["pageIndex"]);
            pageIndex = (pageIndex == null ? 0 : pageIndex);
            int pageSize = 8; //设置每页显示条数

            var Contracts = db.Contracts.OrderByDescending(i => i.Date).Skip(pageIndex.Value * pageSize).Take(pageSize).ToList();
            ViewBag.Pagination = new Pagination(pageIndex, pageSize, db.Contracts.Count());
            ViewBag.pageIndex = pageIndex;

            // Display the confirmation message 
            var results = new List<Contract>();
            foreach (var item in Contracts)
            {
                results.Add(item);
            }
            return Json(results);

        }
        public ActionResult Process()
        {

            db = new biosealEntities();
            int? pageIndex = Convert.ToInt16(Request.QueryString["pageIndex"]);
            pageIndex = (pageIndex == null ? 0 : pageIndex);
            int pageSize = 8; //设置每页显示条数
            //招聘部分
            var Recruits = db.Recruits.OrderByDescending(i => i.Date).Skip(pageIndex.Value * pageSize).Take(pageSize).ToList();
            ViewBag.Pagination = new Pagination(pageIndex, pageSize, db.Recruits.Count());

            //签约部分
            var Contracts = db.Contracts.OrderByDescending(i => i.Date).Skip(pageIndex.Value * pageSize).Take(pageSize).ToList();
            ViewBag.Pagination1 = new Pagination(pageIndex, pageSize, db.Contracts.Count());
            ViewBag.Contracts = Contracts;
            return View(Recruits);
        }
        public ActionResult ResumeUpload()
        {
            return View();
        }
        public ActionResult Campus()
        {
            return View();
        }
        public ActionResult Intern()
        {
            return View();
        }
        public ActionResult WorkInBioseal()
        {
            db = new biosealEntities();
            int? pageIndex = Convert.ToInt16(Request.QueryString["pageIndex"]);
            pageIndex = (pageIndex == null ? 0 : pageIndex);
            int pageSize = 20; //设置每页显示条数

            var InBioseals = db.InBioseals.OrderByDescending(i => i.Datetime).Skip(pageIndex.Value * pageSize).Take(pageSize).ToList();
            ViewBag.Pagination = new Pagination(pageIndex,pageSize,db.InBioseals.Count());

            return View(InBioseals);
        }
        public ActionResult Detail()
        {
            db = new biosealEntities();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            var news = db.InBioseals.Where(i => i.Id == id).Single();
           
            //获取上一条下一条记录
            var prenews = db.InBioseals.Where(i => i.Id < id).OrderByDescending(i => i.Id).FirstOrDefault();
            ViewBag.prenews = prenews;

            var nextnews = db.InBioseals.Where(i => i.Id > id).OrderBy(i => i.Id).FirstOrDefault();
            ViewBag.nextnews = nextnews;

            return View(news);
        }
    }
}
