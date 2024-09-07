using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public class QuestionDao
  {
    DaoTaoTrucTuyen6Entities db = null;

    public QuestionDao()
    {
      db = new DaoTaoTrucTuyen6Entities();
    }

    public long Insert(Question entity)
    {
      db.Questions.Add(entity);
      db.SaveChanges();
      return entity.ID;
    }

    public bool Delete(int id) 
    {
      try
      {
        var question = db.Questions.Find(id);
        db.Questions.Remove(question);
        db.SaveChanges();
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    // dùng để chứa câu hỏi của bài thi (chức năng phân trang hiển thị cho user admin)
    public IEnumerable<Question> ListAllPaging(string searchString, int page, int pagesize)
    {
      IQueryable<Question> model = db.Questions;
      if (!string.IsNullOrEmpty(searchString))
      {
        model = model.Where(x => x.Content.Contains(searchString) || x.Name.Contains(searchString));
      }
      return model.OrderByDescending(x => x.ID).ToPagedList(page, pagesize);
    }

    public Question ViewDetail(int id)
    {
      return db.Questions.Find(id);
    }

    public bool Update(Question entity)
    {
      try
      {
        var question = db.Questions.Find(entity.ID);
        question.Name = entity.Name;
        question.Content = entity.Content;
        question.Answer = entity.Answer;
        question.ProductID = entity.ProductID;
        db.SaveChanges();
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}
