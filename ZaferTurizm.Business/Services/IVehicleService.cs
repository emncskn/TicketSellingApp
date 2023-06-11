using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public interface IVehicleService
    {
        VehicleDto GetById(int id);
        IEnumerable<VehicleDto> GetAll();
        IEnumerable<VehicleDto> GetVehicle();
        CommandResult Create(VehicleDto model);
        CommandResult Update(VehicleDto model);
        CommandResult Delete(VehicleDto model);
        CommandResult Delete(int id);

    }
}
