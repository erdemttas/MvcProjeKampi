using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ContactValidator : AbstractValidator<Contact>
	{
		public ContactValidator()
		{
			RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezssiniz!");
			RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanını boş geçemezssiniz");
			RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adını boş geçemezssiniz");
			RuleFor(x => x.Subject).MinimumLength(3).WithMessage("lütfen en az 3 karakter girişi yapın.");
			RuleFor(x => x.UserName).MinimumLength(3).WithMessage("lütfen en az 3 karakter girişi yapınız.");
			RuleFor(x => x.Subject).MaximumLength(50).WithMessage("lütfen en fazla 50 karakter girişi yapınız.");

		}
	}
}
