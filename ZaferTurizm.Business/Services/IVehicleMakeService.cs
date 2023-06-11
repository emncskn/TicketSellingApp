using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    //CREATE READ UPDATE DELETE --- CRUD EKRANI
    public interface IVehicleMakeService
    {
        CommandResult Create(VehicleMakeDto model);
        CommandResult Update(VehicleMakeDto model);
        CommandResult Delete(VehicleMakeDto model);
        CommandResult Delete(int id);

        VehicleMakeDto GetById(int id);
        IEnumerable<VehicleMakeDto> GetAll();
    }
}
