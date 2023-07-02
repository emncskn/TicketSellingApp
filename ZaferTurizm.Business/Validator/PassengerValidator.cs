using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Business.Validator
{
    internal class PassengerValidator : IValidator<Passenger>
    {
        public ValidationResult Validate(Passenger entity)
        {
            var result = new ValidationResult();

            if (entity.NationalNumber ==null || entity.NationalNumber.Length != 11)
            {
                result.Messages.Add("Kimlik Numarası 11 hane olmalı!");
            }

            if (entity.Name == null || entity.Name.ToString().Length < 3)
            {
                result.Messages.Add("Yolcu ismi hatalı!");
            }

            if (entity.Surname == null || entity.Surname.ToString().Length < 3)
            {
                result.Messages.Add("Yolcu Soyadı hatalı!");
            }

           

            return result;
        }
    }
}

