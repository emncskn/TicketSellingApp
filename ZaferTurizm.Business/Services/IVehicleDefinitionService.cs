using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public interface IVehicleDefinitionService
    {
        VehicleDefinitionDto? GetById(int id);
        IEnumerable<VehicleDefinitionDto> GetAll();
        IEnumerable<VehicleDefinitionSummary> GetSummaries();
        CommandResult Create(VehicleDefinitionDto model);
        CommandResult Update(VehicleDefinitionDto model);
        CommandResult Delete(VehicleDefinitionDto model);
        CommandResult Delete(int id);
    }
}
