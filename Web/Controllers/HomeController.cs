using Model;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
  public class HomeController : Controller
  {
    // GET: Home
    public ActionResult Index()
    {
      var dao = new ProductCategoryDao();
      ViewBag.CategoryID = dao.ListAll();

      var productDao = new ProductDao();
      ViewBag.HomeProducts = productDao.ListAllProduct();
      ViewBag.ProductID = dao.ListAll();

      // bài thi trắc nghiệm
      var baithitracnghiemDao = new Exam();

      return View();
    }
  }
}