using CarBookProject.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Validator.ReviewValidator
{
	public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
	{
		public CreateReviewValidator()
		{
			RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Müşteri Adı Boş Bırakılamaz..!");
			RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Girişi Yapınız..!");
			RuleFor(x => x.RaitingValue).NotEmpty().WithMessage("Puan Değeri Boş Bırakılamaz..!");
			RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen Yorumunuzu Giriniz..!");
			RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Yorum En Az 50 Karakterden Oluşmalıdır..!");
			RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Yorum En Fazla 500 Karakterden Oluşabilir..!");
		}
	}
}
