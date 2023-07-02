using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    public class RouteData
    {
        public static readonly Route Data01_AnkaraIstanbul = new Route()
        {
            Id = 1,
            DepartureCityId = LocationData.Data02_Ankara.Id,
            ArrivalCityId = LocationData.Data01_Istanbul.Id
        };
        public static readonly Route Data02_AnkaraErzincan = new Route()
        {
            Id = 2,
            DepartureCityId = LocationData.Data02_Ankara.Id,
            ArrivalCityId = LocationData.Data03_Erzincan.Id
        };
        public static readonly Route Data03_RizeAntalya = new Route()
        {
            Id = 3,
            DepartureCityId = LocationData.Data05_Rize.Id,
            ArrivalCityId = LocationData.Data04_Antalya.Id
        };
        public static readonly Route Data04_AnkaraSamsun = new Route()
        {
            Id = 4,
            DepartureCityId = LocationData.Data02_Ankara.Id,
            ArrivalCityId = LocationData.Data06_Samsun.Id
        };
    }
}
