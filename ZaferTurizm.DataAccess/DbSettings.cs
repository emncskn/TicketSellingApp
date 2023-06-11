using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DataAccess
{
    internal class DbSettings
    {
        
        
            public const string ConnectionLaptopStringSettings = @"Server=DESKTOP-S7P89NR\MSSQLSERVER01;Database= ZaferTurizm;
            Integrated Security=true; TrustServerCertificate=True";
            public const string ConnectionPcStringSettings = @"Server=DESKTOP-SH3EO74;Database= ZaferTurizm;
            Integrated Security=true; TrustServerCertificate=True";
            public const string ProductionStringSettings = "";

        
            // const olduğu için instance almadan erişebiliyoruz
    }
}
