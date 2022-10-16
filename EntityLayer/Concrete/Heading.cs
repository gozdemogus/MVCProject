using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        public int HeadingId { get; set; }
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }

        //bunlar ikili paket gibi oluyor 

        //iliskili tablonun anahtar sütunuyla aynı isimde verilmeli!!!!
        //Heading tablosu icinde CategoryID isimli bi sütun olacak
        //bire cok iliski
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

   
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }

        //ikinci iliski de contentle, bire cok iliski, burası bir tarafında
        public ICollection<Content> Contents { get; set; }


    }
}
