using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    public class LocationData
    {
        public static readonly Location Data01_Istanbul = new Location() { Id = 1, Name = "Istanbul" };
        public static readonly Location Data02_Ankara = new Location() { Id = 2, Name = "Ankara" };
        public static readonly Location Data03_Erzincan = new Location() { Id = 3, Name = "Erzincan" };
        public static readonly Location Data04_Antalya = new Location() { Id = 4, Name = "Antalya" };
        public static readonly Location Data05_Rize = new Location() { Id = 5, Name = "Rize" };
        public static readonly Location Data06_Samsun = new Location() { Id = 6, Name = "Samsun" };
    }
}
