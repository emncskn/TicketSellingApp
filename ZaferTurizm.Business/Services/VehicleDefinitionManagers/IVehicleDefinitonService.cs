using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.Business.Services.VehicleDefinitionManagers
{
    public interface IVehicleDefinitonService
    {
        CommandResult Create(VehicleDefinitonDto model);
        CommandResult Update(VehicleDefinitonDto model);
        CommandResult Delete(VehicleDefinitonDto model);
        CommandResult Delete(int id);

        //VehicleDefinitionUpdateType GetById(int id);
        // QueryResult döndürebilirdik
        
        VehicleDefinitonDto? GetById(int id);

        IEnumerable<VehicleDefinitonDto> GetAll();
        IEnumerable<VehicleDefinitonSummary> GetAllSummaries();
    }
}
