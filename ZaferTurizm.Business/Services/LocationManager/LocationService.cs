using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs;

namespace ZaferTurizm.Business.Services.LocationManager
{
    public class LocationService : ILocationService
    {
        private readonly TourDbContext _tourDbContext;
     
        public LocationService(TourDbContext tourDbContext)
        {

            if (tourDbContext == null)
            {
                throw new ArgumentNullException("tourDbContext");
                //throw new ArgumentNullException(nameof(tourDbContext)
            }
            _tourDbContext = tourDbContext;

        }
        public CommandResult Create(LocationDto model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                {
                    return CommandResult.Failure();
                }
                 
                var locationEntity = new Location()

                {
                    Name = model.Name,
                };
                _tourDbContext.Add(locationEntity);
                _tourDbContext.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex) 
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();

            }
        }

        public CommandResult Delete(LocationDto model)
        {
            if (model == null)
            {
                throw new ArgumentException(nameof(model), "Model null olamaz");
            }
            return Delete(model.Id);
        }

        public CommandResult Delete(int id)
        {
            var entity = new Location() { Id = id };

            try
            {
                
                _tourDbContext.Locations.Remove(entity);
                _tourDbContext.SaveChanges();                 
                return CommandResult.Success();             

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();
            }
        }

        public IEnumerable<LocationDto> GetAll()
        {
            try
            {
                var locationList = _tourDbContext.Locations.ToList();
                var locationDtoList = new List<LocationDto>();
                foreach (var location in locationList)
                {
                    locationDtoList.Add(new LocationDto()
                    {
                        Id = location.Id,
                        Name = location.Name,
                    });
                }
                return locationDtoList;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<LocationDto>();
            }
        }

        public LocationDto GetById(int id)
        {
            var location = _tourDbContext.Locations.FirstOrDefault(x => x.Id == id);

            try
            {
                if (location == null)
                {
                    return null;
                }
                var locationDto = new LocationDto()
                {
                    Id = location.Id,
                    Name = location.Name
                };
                return locationDto;

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;

            }
        }

        public CommandResult Update(LocationDto model)
        {
            if (model == null)
            {
               
                throw new ArgumentNullException(nameof(model), "LocationDto nesnesi null değer olamaz");
            }
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return CommandResult.Failure("Şehir adı boş geçilemez");
            }
            var entity = new Location()
            {
                Id = model.Id,
                Name = model.Name,
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
