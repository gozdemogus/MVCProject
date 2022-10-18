using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categorydal = categoryDal; 
        }

        public void CategoryAdd(Category category)
        {
           _categorydal.Insert(category);  
        }

        public void CategoryDelete(Category category)
        {
            //bu methodlar generic repositoryden geliyor 
            //Irepositoryden gelio ici genericrepositoryle doluyor
           _categorydal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
          _categorydal.Update(category);    
        }

        public Category GetById(int id)
        {
          return _categorydal.Get(x=>x.CategoryId==id);
        }

        public List<Category> GetList()
        {
            return _categorydal.List();
        }

      
        //GenericRepository<Category> repo = new GenericRepository<Category>();

        //public List<Category> GetAllBl()
        //{
        //    return repo.List();
        //}

        //public void CategoryAddBl(Category p)
        //{
        //    if (p.CategoryName == "" || p.CategoryName.Length <= 3 || p.CategoryDescription == "" || p.CategoryName.Length >= 51)
        //    {
        //        //hata mesajı
        //    }
        //    else
        //    {
        //        repo.Insert(p); 
        //    }
        //}


    }
}
