using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public class CommentDao
  {
    DaoTaoTrucTuyen6Entities db = null;

    public CommentDao()
    {
      db = new DaoTaoTrucTuyen6Entities();
    }

    public bool Insert(CommentDao entity)
    {
      return true;
    }

  }
}
