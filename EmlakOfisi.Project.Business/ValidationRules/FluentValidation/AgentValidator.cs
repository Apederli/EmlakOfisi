using System;
using System.Collections.Generic;
using System.Text;
using EmlakOfisi.Project.Entity.Concrete;
using FluentValidation;

namespace EmlakOfisi.Project.Business.ValidationRules.FluentValidation
{
    public class AgentValidator : AbstractValidator<Agent>
    {
        public AgentValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Lütfen Kullanıcı Adını Alanını Boş Bırakmayınız");

            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Lütfen Şirket Alanını Boş Bırakmayınız");

            RuleFor(x => x.PasswordVerify).Equal(x => x.Password).WithMessage("Şifre Tekrarı ile Şifre uyuşmuyor.");
        }
    }
}
