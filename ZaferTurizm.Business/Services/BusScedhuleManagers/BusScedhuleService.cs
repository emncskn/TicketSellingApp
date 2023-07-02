using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Validator;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.Business.Services.BusScedhuleManagers
{

    public class BusScedhuleService : CrudService<BusScedhuleDto, BusScedhuleSummery, BusScedhule>, IBusScedhuleService
    {
        public BusScedhuleService(TourDbContext dbContext, BusScedhuleValidator validator)
           : base(dbContext, validator)
        {
        }

        protected override Expression<Func<BusScedhule, BusScedhuleDto>> DtoMapper =>
             entity => new BusScedhuleDto()
             {
                 Id = entity.Id,
                 RouteId = entity.RouteId,
                 VehicleId = entity.VehicleId,
                 Price = entity.Price,
                 Date = entity.Date
             };

        protected override Expression<Func<BusScedhule, BusScedhuleSummery>> SummaryMapper =>
             entity => new BusScedhuleSummery()
             {
                 Id = entity.Id,
                 Date = entity.Date,
                 Price = entity.Price,
                 DepartureName = entity.Route.DepartureCity.Name,
                 ArrivalName = entity.Route.ArrivalCity.Name,
                 VehicleMakeName = entity.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name,
                 VehicleModelName = entity.Vehicle.VehicleDefinition.VehicleModel.Name,
                 PlateNumber = entity.Vehicle.PlateNumber,
                 SeatCount = entity.Vehicle.VehicleDefinition.SeatCount
             };



        protected override BusScedhule MapToEntity(BusScedhuleDto dto)
        {
            return new  BusScedhule()
            {
                Id = dto.Id,
                RouteId = dto.RouteId,
                VehicleId = dto.VehicleId,
                Price = dto.Price,
                Date = dto.Date
            };
        }
        public BusScedhuleDetail? GetBusScedhuleDetails(int id)
        {
            try
            {
                return _dbContext.BusScedhules
                    .Where(busScedhule => busScedhule.Id == id)
                    .Select(busScedhule => new BusScedhuleDetail()
                    {
                        BusScedhuleId = busScedhule.Id,
                        Date = busScedhule.Date,
                        TicketPrice = busScedhule.Price,
                        SeatCount = busScedhule.Vehicle.VehicleDefinition.SeatCount,
                        VehicleMakeName = busScedhule.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name,
                        VehicleModelName = busScedhule.Vehicle.VehicleDefinition.VehicleModel.Name,
                        PlateNumber = busScedhule.Vehicle.PlateNumber,
                        DepartureName = busScedhule.Route.DepartureCity.Name,
                        ArrivalName = busScedhule.Route.ArrivalCity.Name,
                        
                    })
                    .SingleOrDefault();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return default;
            }
        }
    }
}
