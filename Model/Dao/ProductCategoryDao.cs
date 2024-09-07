﻿using System.Collections.Generic;
using System.Linq;

namespace Model.Dao
{
  public class ProductCategoryDao
  {
    DaoTaoTrucTuyen6Entities db = null;
    public ProductCategoryDao()
    {
      db = new DaoTaoTrucTuyen6Entities();
    }
    public List<ProductCategory> ListAll()
    {
      return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
    }
    public ProductCategory ViewDetail(long id)
    {
      return db.ProductCategories.Find(id);
    }
  }
}