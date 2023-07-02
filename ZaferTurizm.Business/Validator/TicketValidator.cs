using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Business.Validator
{
    public class TicketValidator : IValidator<Ticket>
    {
        public ValidationResult Validate(Ticket entity)
        {
            var result = new ValidationResult();

            if (entity.BusScedhuleId <= 0)
            {
                result.Messages.Add("Lütfen bir rota seçiniz!");
            }

            if (entity.PassengerId <= 0)
            {
                result.Messages.Add("Lütfen yolcu bilgilerini giriniz!");
            }

            if (entity.Price <= 0)
            {
                result.Messages.Add("Bilet fiyatı Hatalı!");
            }
            if (entity.SeatNumber == null)
            {
                result.Messages.Add("Lütfen Koltuk seçimi Yapınız!");
            }

            return result;
        }
    }
}
