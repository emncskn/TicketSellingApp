using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public interface IVehicleModelService
    {
        VehicleModelDto GetById(int id);
        IEnumerable<VehicleModelDto> GetAll();
        IEnumerable<VehicleModelSummary> GetSummaries();
        IEnumerable<VehicleModelDto>GetByMakeId(int VehicleMakeId);
        CommandResult Create(VehicleModelDto model);
        CommandResult Update(VehicleModelDto model);
        CommandResult Delete(VehicleModelDto model);
        CommandResult Delete(int id);

    }
}
