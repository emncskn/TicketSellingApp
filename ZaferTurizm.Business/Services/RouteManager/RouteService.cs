using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Services.VehicleDefinitionManagers;
using ZaferTurizm.Business.Validator;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.Business.Services.RouteManager
{
    public class RouteService : CrudService<RouteDto, RouteSummary, Route>, IRouteService
    {
        public RouteService(TourDbContext dbContext, GenericValidator<Route> validator)
           : base(dbContext, validator)
        {
        }

       

        protected override Expression<Func<Route, RouteDto>> DtoMapper =>
             entity => new RouteDto()
             {
                 Id = entity.Id,
                 DepartureCityId = entity.DepartureCityId,
                 ArrivalCityId = entity.ArrivalCityId
             };

        protected override Expression<Func<Route, RouteSummary>> SummaryMapper =>
              entity => new RouteSummary()
              {
                  Id = entity.Id,
                  DepartureName = entity.DepartureCity.Name,
                  ArrivalName = entity.ArrivalCity.Name
              };

        protected override Route MapToEntity(RouteDto dto)
        {
            return new Route()
            {
                Id = dto.Id,
                DepartureCityId = dto.DepartureCityId,
                ArrivalCityId = dto.ArrivalCityId
            };
        }
    }
}
