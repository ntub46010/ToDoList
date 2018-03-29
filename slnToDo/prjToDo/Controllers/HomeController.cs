using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjToDo.Models;

namespace prjToDo.Controllers
{
    public class HomeController : Controller
    {
        dbToDoEntities db = new dbToDoEntities();

        //首頁
        public ActionResult Index()
        {
            var todos = db.tTodo.OrderByDescending(m => m.fDate).ToList();
            return View(todos);
        }

        //前往新增頁面
        public ActionResult Create()
        {
            return View();
        }

        //送出新增資料
        [HttpPost]
        public ActionResult Create(string fTitle, string fImage, DateTime fDate)
        {
            tTodo todo = new tTodo();
            todo.fTitle = fTitle;
            todo.fImage = fImage;
            todo.fDate = fDate;
            db.tTodo.Add(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //刪除頁面
        public ActionResult Delete(int id)
        {
            var todo = db.tTodo.Where(m => m.fId == id).FirstOrDefault();
            db.tTodo.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //前往編輯頁面
        public ActionResult Edit(int id)
        {
            var todo = db.tTodo.Where(m => m.fId == id).FirstOrDefault();
            return View(todo);
        }

        //確認修改資料
        [HttpPost]
        public ActionResult Edit(int fId, string fTitle, string fImage, DateTime fDate)
        {
            var todo = db.tTodo.Where(m => m.fId == fId).FirstOrDefault();
            todo.fTitle = fTitle;
            todo.fImage = fImage;
            todo.fDate = fDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}