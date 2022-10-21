using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();

        //once methodu interface tarafında tanımla sonra icini sınıf tarafında (manager) doldur.
        void CategoryAdd(Category category);

        Category GetById(int id);
        void CategoryDelete(Category category);

        void CategoryUpdate(Category category); 
    }
}
