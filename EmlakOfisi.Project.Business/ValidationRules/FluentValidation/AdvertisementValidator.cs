using System;
using System.Collections.Generic;
using System.Text;
using EmlakOfisi.Project.Entity.Concrete;
using FluentValidation;

namespace EmlakOfisi.Project.Business.ValidationRules.FluentValidation
{
    public class AdvertisementValidator : AbstractValidator<Advertisement>
    {
        public AdvertisementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen Başlık Alanını Boş Bırakmayınız");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Lütfen Fiyat Alanını Boş Bırakmayınız");

            RuleFor(x => x.SquareMeters).NotEmpty().WithMessage("Lütfen Fiyat Alanını Boş Bırakmayınız");
        }
    }
}
