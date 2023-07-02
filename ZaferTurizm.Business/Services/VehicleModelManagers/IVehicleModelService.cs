using ZaferTurizm.DTOs;

namespace ZaferTurizm.Business.Services.VehicleModelManagers
{
    public interface IVehicleModelService : ICrudService<VehicleModelDto, VehicleModelSummary>
    {
        IEnumerable<VehicleModelDto> GetByMakeId(int makeId);
    }
}
