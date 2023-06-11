using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DataAccess
{
    internal class DbSettings
    {
        
        
            public const string ConnectionLaptopStringSettings = @"Server=DESKTOP-TJT2JL4;Database= ZaferTurizmDb;
            Integrated Security=true; TrustServerCertificate=True";
            public const string ConnectionPcStringSettings = @"Server=DESKTOP-TJT2JL4;Database= ZaferTurizmDb;
            Integrated Security=true; TrustServerCertificate=True";
            public const string ProductionStringSettings = "";

        
            // const olduğu için instance almadan erişebiliyoruz
    }
}
