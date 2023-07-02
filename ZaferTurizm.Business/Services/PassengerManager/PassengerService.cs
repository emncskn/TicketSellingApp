using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Validator;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.Business.Services.PassengerManager
{
    public class PassengerService : IPassengerService
    {
        private readonly TourDbContext _tourDbContext;
        public PassengerService(TourDbContext tourDbContext)
        {
            _tourDbContext = tourDbContext;
        }
        public CommandResult Create(PassengerDto model)
        {
            try
            {
                var passenger = new Passenger()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    NationalNumber = model.NationalNumber,
                    Gender = model.Gender


                };

                ValidationResult validationResult = new PassengerValidator().Validate(passenger);

                if (!validationResult.IsValid)
                {
                    var validationMessages = string.Join('\n', validationResult.Messages);

                    return CommandResult.Failure(validationMessages);
                }

                _tourDbContext.Add(passenger);
                _tourDbContext.SaveChanges();
                return CommandResult.Success();
            }
            catch
            {

                return CommandResult.Failure();
            }
        }

        public CommandResult Delete(PassengerDto model)
        {
            if (model == null)
            {
                throw new ArgumentException(nameof(model), "Model null olamaz");
            }

            return Delete(model.Id);
        }

        public CommandResult Delete(int id)
        {
            var entity = new Passenger() { Id = id };

            try
            {
              
                _tourDbContext.Passengers.Remove(entity);
                _tourDbContext.SaveChanges();                
                return CommandResult.Success();               

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();
            }
        }

        public IEnumerable<PassengerDto> GetAll()
        {
            try
            {
                var passengerList = _tourDbContext.Passengers.ToList();
                var passengerDtoList = new List<PassengerDto>();
                foreach (var passenger in passengerList)
                {
                    passengerDtoList.Add(new PassengerDto()
                    {
                        Id = passenger.Id,
                        Name = passenger.Name,
                        Surname = passenger.Surname,
                        Gender = passenger.Gender,
                        NationalNumber= passenger.NationalNumber
                    });
                }
                return passengerDtoList;

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
         
                return Enumerable.Empty<PassengerDto>();
            }
        }

        public PassengerDto? GetById(int id)
        {
            var passenger = _tourDbContext.Passengers.FirstOrDefault(x => x.Id == id);

            try
            {
                if (passenger == null)
                {
                    return null;
                }
                var passengerDto = new PassengerDto()
                {
                    Id = passenger.Id,
                    Name = passenger.Name,
                    Surname=passenger.Surname,
                    Gender = passenger.Gender,
                    NationalNumber=passenger.NationalNumber
                };
                return passengerDto;

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;

            }
        }   
        public PassengerDto? GetByNationalNumber(string id)
        {
            var passenger = _tourDbContext.Passengers.FirstOrDefault(x => x.NationalNumber == id);

            try
            {
                if (passenger == null)
                {
                    return null;
                }
                var passengerDto = new PassengerDto()
                {
                    Id = passenger.Id,
                    Name = passenger.Name,
                    Surname=passenger.Surname,
                    Gender = passenger.Gender,
                    NationalNumber=passenger.NationalNumber
                };
                return passengerDto;

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;

            }
        }

        public IEnumerable<TicketDto> GetTickets()
        {
            throw new NotImplementedException();
        }

        public CommandResult Update(PassengerDto model)
        {
            if (model == null)
            {
                //GENEL OLARAK BU TEKNİĞE Guard veya Defensive Coding denir.
                throw new ArgumentNullException(nameof(model), "Passenger nesnesi null değer olamaz");
            }
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return CommandResult.Failure("Yolcu adı boş geçilemez");
            }
            var entity = new Passenger()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Gender = model.Gender,
                NationalNumber = model.NationalNumber
            };
            try
            {
                _tourDbContext.Update(entity);
                _tourDbContext.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("Bir hata meydana geldi. Sistem yöneticisine başvurun");
            }
        }
    }
}
