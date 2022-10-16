using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }

        [StringLength(1000)]
        public string ContentValue  { get; set; }

        public DateTime ContentDate { get; set; }

        //content writer ile iliski
        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }

        //content header ile iliski
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }
    }
}
