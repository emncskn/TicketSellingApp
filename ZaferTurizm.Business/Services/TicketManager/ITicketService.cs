using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.Business.Services.TicketManager
{
    public interface ITicketService : ICrudService<TicketDto, TicketSummary>
    {
        public IEnumerable<TicketDto> GetByBusScedhule(int busScedhuleId);
    }
}
