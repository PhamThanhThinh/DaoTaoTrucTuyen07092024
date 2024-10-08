﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public class ExamDao
  {
    DaoTaoTrucTuyen6Entities db = null;
    public ExamDao()
    {
      db = new DaoTaoTrucTuyen6Entities();
    }

    public long Insert(Exam entity)
    {
      db.Exams.Add(entity);
      db.SaveChanges();
      return entity.ID;
    }

    public bool Delete(int id)
    {
      try
      {
        var exam = db.Exams.Find(id);
        db.Exams.Remove(exam);
        db.SaveChanges();
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public IEnumerable<Exam> ListAllPaging(string searchString, int page, int pagesize)
    {
      IQueryable<Exam> model = db.Exams;
      if (!string.IsNullOrEmpty(searchString))
      {
        model = model.Where(x => x.ProductID.ToString().Contains(searchString) || x.Name.Contains(searchString));
      }
      return model.OrderByDescending(x => x.ID).ToPagedList(page, pagesize);
    }

    public Exam ViewDetail(int id)
    {

      return db.Exams.Find(id);
    }

    public bool Update(Exam entity)
    {
      try
      {
        var exam = db.Exams.Find(entity.ID);
        exam.Name = entity.Name;
        exam.Code = entity.Code;
        exam.MetaTitle = entity.MetaTitle;
        exam.AnswerList = entity.AnswerList;
        exam.ProductID = entity.ProductID;
        exam.StartDate = entity.StartDate;
        exam.EndDate = entity.EndDate;
        exam.TotalScore = entity.TotalScore;
        exam.Time = entity.Time;
        exam.TotalQuestion = entity.TotalQuestion;
        exam.QuestionEssay = entity.QuestionEssay;
        exam.UserList = entity.UserList;
        exam.SoreList = entity.SoreList;
        db.SaveChanges();
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public List<Exam> ListAllExam()
    {
      return db.Exams.Where(x => x.Status == true).OrderByDescending(x => x.ID).ToList();
    }

    public List<Exam> ListByType(string searchString, string Type)
    {
      return db.Exams.Where(x => x.Type == Type).ToList();
    }

  }
}
