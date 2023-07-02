﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Validator;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.Business.Services.VehicleMakeManagers
{
    public class VehicleMakeService : CrudService<VehicleMakeDto, VehicleMakeSummary,VehicleMake>, IVehicleMakeService
    {
        public VehicleMakeService(TourDbContext dbContext, GenericValidator<VehicleMake> validator)
           : base(dbContext, validator)
        { }

        protected override Expression<Func<VehicleMake, VehicleMakeDto>> DtoMapper =>
            entity => new VehicleMakeDto()
            {
                Id = entity.Id,
                Name = entity.Name
            };

        protected override Expression<Func<VehicleMake, VehicleMakeSummary>> SummaryMapper =>
            entity => new VehicleMakeSummary()
            {
                Id = entity.Id,
                Name = entity.Name
            };

   

        protected override VehicleMake MapToEntity(VehicleMakeDto dto)
        {
            return new VehicleMake()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
