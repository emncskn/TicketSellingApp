using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.Business.Services.VehicleDefinitionManagers
{
    public class VehicleDefinitionService : IVehicleDefinitonService
    {
        private readonly TourDbContext _tourDbContext;

        public VehicleDefinitionService(TourDbContext tourDbContext)
        {
            _tourDbContext = tourDbContext;
        }



        public CommandResult Create(VehicleDefinitonDto model)
        {
            throw new NotImplementedException();
        }

        public CommandResult Delete(VehicleDefinitonDto model)
        {
            throw new NotImplementedException();
        }

        public CommandResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleDefinitonDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleDefinitonSummary> GetAllSummaries()
        {
            try
            {
                return _tourDbContext.VehicleDefinitions.Select(def => new VehicleDefinitonSummary()
                {
                    Id = def.Id,
                    HasToilet = def.HasToilet,
                    HasWifi = def.HasWifi,
                    SeatCount = def.SeatCount,
                    Year = def.Year,
                    VehicleMakeName = def.VehicleModel.VehicleMake.Name,
                    VehicleModelName = def.VehicleModel.Name


                }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleDefinitonSummary>();
            }
        }

        public VehicleDefinitonDto? GetById(int id)
        {
            try
            {
                return _tourDbContext.VehicleDefinitions.Select(model => new VehicleDefinitonDto()
                {
                    Id = model.Id,
                    VehicleModelId=model.VehicleModelId,
                    Year=model.Year,
                    HasToilet=model.HasToilet,
                    SeatCount=model.SeatCount,
                    HasWifi=model.HasWifi,
                    VehicleMakeId = model.VehicleModel.VehicleMakeId

                }).SingleOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }

      

        public CommandResult Update(VehicleDefinitonDto model)
        {
            throw new NotImplementedException();
        }
    }





}
