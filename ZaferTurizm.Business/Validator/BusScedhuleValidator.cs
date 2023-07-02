using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Business.Validator
{

    public class BusScedhuleValidator : IValidator<BusScedhule>
    {
        public ValidationResult Validate(BusScedhule entity)
        {
            var result = new ValidationResult();

            if (entity.RouteId <= 0)
            {
                result.Messages.Add("Lütfen bir rota seçiniz!");
            }

            if (entity.VehicleId <= 0)
            {
                result.Messages.Add("Lütfen araç bilgisini giriniz!");
            }

            if (entity.Price <= 0)
            {
                result.Messages.Add("Bilet fiyatı Hatalı!");
            }

            if (entity.Date < DateTime.Now)
            {
                result.Messages.Add("Tarih geçmiş bir değer olamaz!");
            }

            return result;
        }
    }
}
