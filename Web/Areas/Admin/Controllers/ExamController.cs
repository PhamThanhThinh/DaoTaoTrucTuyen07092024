using Model;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
  public class ExamController : Controller
  {
    // GET: Admin/Exam
    public ActionResult Index(string searchString, int page = 1, int pageSize = 200)
    {
      var dao = new ExamDao();
      var model = dao.ListAllPaging(searchString, page, pageSize);
      ViewBag.SearchString = searchString;
      // xác định xem bài thi nằm trong khóa học nào
      SetViewBag();
      return View();
    }

    public void SetViewBag(long? selectedId = null)
    {
      var dao = new ProductDao();
      ViewBag.ProductList = dao.ListAllProduct();
    }

    [HttpDelete]
    public ActionResult Delete(int id) 
    {
      new ExamDao().Delete(id);
      return RedirectToAction("Index");
    }

    [HttpPost]
    public JsonResult AddProductAjax(
      string name,
      string metatitle,
      string code,
      string questionlist,
      string answerlist,
      string productid,
      string startdate,
      string enddate,
      string totalscore,
      string time,
      string totalquestion,
      string questionessay,
      string userlist,
      string sorelist
      )
    {
      try
      {
        var dao = new ExamDao();
        Exam exam = new Exam();

        exam.Name = name;
        exam.MetaTitle = metatitle;
        exam.Code = code;
        exam.QuestionList = questionlist;
        exam.AnswerList = answerlist;
        exam.ProductID = Convert.ToInt16(productid);
        exam.StartDate = Convert.ToDateTime(startdate);
        exam.EndDate = Convert.ToDateTime(enddate);
        exam.TotalScore = Convert.ToInt16(totalscore);
        exam.Time = Convert.ToInt16(time);
        exam.TotalQuestion = Convert.ToInt16(totalquestion);
        exam.QuestionEssay = questionessay;
        exam.UserList = userlist;
        exam.SoreList = sorelist;
        exam.Type = "1";
        exam.Status = true;

        long id = dao.Insert(exam);
        if (id > 0)
        {
          return Json(new { status = true });
        }
        else
        {
          return Json(new { status = false });
        }
      }
      catch
      {
        return Json(new
        {
          status = false
        });
      }
    }

    [HttpPost]
    public JsonResult UpdateExamAjax(
      string id,
      string name,
      string metatitle,
      string code,
      string questionlist,
      string answerlist,
      string productid,
      string startdate,
      string enddate,
      string totalscore,
      string time,
      string totalquestion,
      string questionessay,
      string userlist,
      string sorelist
      )
    {
      try
      {
        var dao = new ExamDao();
        Exam exam = new Exam();

        exam = dao.ViewDetail(Convert.ToInt16(id));

        exam.Name = name;
        exam.MetaTitle = metatitle;
        exam.Code = code;
        exam.QuestionList = questionlist;
        exam.AnswerList = answerlist;
        exam.ProductID = Convert.ToInt16(productid);
        exam.StartDate = Convert.ToDateTime(startdate);
        exam.EndDate = Convert.ToDateTime(enddate);
        exam.TotalScore = Convert.ToInt16(totalscore);
        exam.Time = Convert.ToInt16(time);
        exam.TotalQuestion = Convert.ToInt16(totalquestion);
        exam.QuestionEssay = questionessay;
        exam.UserList = userlist;
        exam.SoreList = sorelist;

        bool editresult = dao.Update(exam);
        if (editresult == true)
        {
          return Json(new { status = true });
        }
        else
        {
          return Json(new { status = false });
        }
      }
      catch
      {
        return Json(new
        {
          status = false
        });
      }
    }
  }
}