using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.Business.Services.PassengerManager
{
    public interface IPassengerService
    {
        CommandResult Create(PassengerDto model);
        CommandResult Update(PassengerDto model);
        CommandResult Delete(PassengerDto model);
        CommandResult Delete(int id);
        PassengerDto? GetById(int id);

        IEnumerable<PassengerDto> GetAll();
        IEnumerable<TicketDto> GetTickets();
        PassengerDto? GetByNationalNumber(string id);
    }
}
