using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly TourDbContext _tourDbContext;
        public VehicleModelService(TourDbContext tourDbContext)
        {
            _tourDbContext = tourDbContext;
        }
        public CommandResult Create(VehicleMakeDto model)
        {
            try
            {
              
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public CommandResult Create(VehicleModelDto model)
        {
            throw new NotImplementedException();
        }

        public CommandResult Delete(VehicleMakeDto model)
        {
            throw new NotImplementedException();
        }

        public CommandResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CommandResult Delete(VehicleModelDto model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleModelDto> GetAll()
        {
            try
            {
                return _tourDbContext.VehicleModels.Select(model => new VehicleModelDto()
                {
                    Id = model.Id,
                    Name = model.Name,
                    VehicleMakeId = model.VehicleMakeId,
                }).ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleModelDto>(); 
            }
            
        }

        public VehicleModelDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleModelDto> GetByMakeId(int vehicleMakeId)
        {
            try
            {
                return _tourDbContext.VehicleModels
                    .Where(entity => entity.VehicleMakeId == vehicleMakeId)
                    .Select(entity => new VehicleModelDto()
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        VehicleMakeId = entity.VehicleMakeId
                    }).ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError (ex.ToString());
                return new List<VehicleModelDto>();
            }
        }

        public IEnumerable<VehicleModelSummary> GetSummaries()
        {
            try
            {
                return _tourDbContext.VehicleModels.Select(model=> new VehicleModelSummary()
                {
                    Id = model.Id,
                    Name = model.Name,
                    VehicleMakeName = model.VehicleMake.Name
                }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return new List<VehicleModelSummary>();
                
            }
            
        }

        public CommandResult Update(VehicleMakeDto model)
        {
            throw new NotImplementedException();
        }

        public CommandResult Update(VehicleModelDto model)
        {
            throw new NotImplementedException();
        }
    }
}
