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
			RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını adını boş geçemezssiniz");
			RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soy adını boş geçemezssiniz");
			RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısımını boş geçemezssiniz");
			RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvan kısımını boş geçemezsiniz");
			RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
			RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayınız");
		}
	}
}
