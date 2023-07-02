using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs;
using ZaferTurizm.Business.Services.VehicleDefinitionManagers;
using System.Diagnostics;
using ZaferTurizm.Business.Validator;

namespace ZaferTurizm.Business.Services.VehicleDefinitionManagers
{
    public class VehicleDefinitionService : CrudService<VehicleDefinitonDto, VehicleDefinitonSummary, VehicleDefinition> , IVehicleDefinitionService
    {
        public VehicleDefinitionService(TourDbContext dbContext, GenericValidator<VehicleDefinition> validator)
           : base(dbContext, validator)
        { }

        protected override Expression<Func<VehicleDefinition, VehicleDefinitonDto>> DtoMapper =>
            entity => new VehicleDefinitonDto()
            {
                Id = entity.Id,
                Year = entity.Year,
                SeatCount = entity.SeatCount,
                VehicleModelId = entity.VehicleModelId,
                VehicleMakeId = entity.VehicleModel.VehicleMakeId,
                HasWifi = entity.HasWifi,
                HasToilet = entity.HasToilet
            };

        protected override Expression<Func<VehicleDefinition, VehicleDefinitonSummary>> SummaryMapper =>
            entity => new VehicleDefinitonSummary()
            {
                Id = entity.Id,
                Year = entity.Year,
                SeatCount = entity.SeatCount,
                HasToilet = entity.HasToilet,
                HasWifi = entity.HasWifi,
                VehicleMakeName = entity.VehicleModel.VehicleMake.Name,
                VehicleModelName = entity.VehicleModel.Name
            };

        protected override VehicleDefinition MapToEntity(VehicleDefinitonDto dto)
        {
            return new VehicleDefinition()
            {
                Id = dto.Id,
                Year = dto.Year,
                SeatCount = dto.SeatCount,
                VehicleModelId = dto.VehicleModelId,
                HasWifi = dto.HasWifi,
                HasToilet = dto.HasToilet
            };
        }
    }
}
