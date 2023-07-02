using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Services.VehicleMakeManagers;
using ZaferTurizm.Business.Validator;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.Business.Services.VehicleManagers
{
    public class VehicleService : CrudService<VehicleDto, VehicleSummary, Vehicle>, IVehicleService
    {
        public VehicleService(TourDbContext dbContext, GenericValidator<Vehicle> validator)
           : base(dbContext, validator)
        {
        }

        protected override Expression<Func<Vehicle, VehicleDto>> DtoMapper =>
            entity => new VehicleDto()
            {
                Id = entity.Id,
                PlateNumber = entity.PlateNumber,
                VehicleDefinitionId = entity.VehicleDefinitionId,
            };

        protected override Expression<Func<Vehicle, VehicleSummary>> SummaryMapper =>
             entity => new VehicleSummary()
             {
                 Id = entity.Id,
                 PlateNumber = entity.PlateNumber,
                 VehicleMakeName = entity.VehicleDefinition.VehicleModel.VehicleMake.Name,
                 VehicleModelName = entity.VehicleDefinition.VehicleModel.Name
             };

        protected override Vehicle MapToEntity(VehicleDto dto)
        {
            return new Vehicle()
            {
            
                Id = dto.Id,
                PlateNumber = dto.PlateNumber,
                VehicleDefinitionId = dto.VehicleDefinitionId,
            };
        }
        
    }
}
