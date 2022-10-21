using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezsiniz.");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("lğtfen en az 3 karakter girişi yapın.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("en fazla 20 karakter girisi yapınız.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Ünvanı eklenmelidir.");
        }
    }
}
