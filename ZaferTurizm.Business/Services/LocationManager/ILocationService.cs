using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.Business.Services.LocationManager
{
    public interface ILocationService
    {
        CommandResult Create(LocationDto model);
        CommandResult Update(LocationDto model);
        CommandResult Delete(LocationDto model);
        CommandResult Delete(int id);

        LocationDto GetById(int id); 
        IEnumerable<LocationDto> GetAll();
    }
}
