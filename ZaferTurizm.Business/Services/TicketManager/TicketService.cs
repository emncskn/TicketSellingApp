using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Services.PassengerManager;
using ZaferTurizm.Business.Services.VehicleDefinitionManagers;
using ZaferTurizm.Business.Validator;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.Business.Services.TicketManager
{
    public class TicketService : CrudService<TicketDto, TicketSummary, Ticket>, ITicketService
    {
        public TicketService(TourDbContext dbContext, TicketValidator validator)
           : base(dbContext, validator)
        {

        }

        protected override Expression<Func<Ticket, TicketDto>> DtoMapper =>
            entity => new TicketDto()
        {
            Id = entity.Id,
            BusScedhuleId = entity.BusScedhuleId,
            SeatNumber = entity.SeatNumber,
            Price = entity.Price,
            PassengerIdentityNumber = entity.Passenger.NationalNumber
        };

        protected override Expression<Func<Ticket, TicketSummary>> SummaryMapper =>
            entity => new TicketSummary()
                {
                Id = entity.Id,
                BusScedhuleId = entity.BusScedhuleId,
                PassengerId = entity.PassengerId,
                SeatNumber = entity.SeatNumber,
                Price = entity.Price,
            };

        protected override Ticket MapToEntity(TicketDto dto)
        {
            return new Ticket()
            {
              BusScedhuleId = dto.BusScedhuleId,
              SeatNumber = dto.SeatNumber,
              Price = dto.Price,

            };
        }

        public override CommandResult Create(TicketDto model)
        {
            try
            {
                var passenger = _dbContext.Passengers
                    .FirstOrDefault(pass => pass.Name == model.PassengerName &&
                                            pass.Surname == model.PassengerSurname &&
                                            pass.NationalNumber == model.PassengerIdentityNumber);

                if (passenger == null)
                {
                    passenger = new Passenger()
                    {
                        Name = model.PassengerName,
                        Surname = model.PassengerSurname,
                        NationalNumber = model.PassengerIdentityNumber,
                        Gender = model.PassengerGender
                    };

                    ValidationResult validationResult = new PassengerValidator().Validate(passenger);

                    if (!validationResult.IsValid)
                    {
                        var validationMessages = string.Join('\n', validationResult.Messages);

                        return CommandResult.Failure(validationMessages);
                    }

                    _dbContext.Passengers.Add(passenger);
                    _dbContext.SaveChanges();
                }

                var ticket = new Ticket()
                {
                    BusScedhuleId = model.BusScedhuleId,
                    PassengerId = passenger.Id,
                    Price = model.Price,
                    SeatNumber = model.SeatNumber
                };

                ValidationResult validation = new TicketValidator().Validate(ticket);

                if (!validation.IsValid)
                {
                    var validationMessages = string.Join('\n', validation.Messages);

                    return CommandResult.Failure(validationMessages);
                }

                _dbContext.Tickets.Add(ticket);
                _dbContext.SaveChanges();

                return CommandResult.Success("Bilet başarıyla kaydedildi");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();
            }
        }

        public IEnumerable<TicketDto> GetByBusScedhule(int busScedhuleId)
        {
            try
            {
                return _dbContext.Tickets
                    .Where(entity => entity.BusScedhuleId == busScedhuleId)
                    .Select(DtoMapper)
                    .ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<TicketDto>();
            }
        }
    }

}
