using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter(int id);
        void Headingadd(Heading heading);
        Heading GetById(int id);
        void HeadingDelete(Heading heading);
        void Headingupdate(Heading heading);

    }
}
