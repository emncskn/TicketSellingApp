using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Business.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        // parametre -> metotta tanımlanmış, dışardan gelen değerleri karşılayacak olan değişken
        //argüman ->parametreye gönderilmiş değer
        //command: create,update,delete
        //query:read

        private readonly TourDbContext _tourDbContext;
        public VehicleMakeService(TourDbContext tourDbContext)
        {
            if (tourDbContext==null )
            {
                //  throw new ArgumentNullException("tourDbContext");
                throw new ArgumentNullException(nameof(tourDbContext));
            }
            _tourDbContext = tourDbContext;
        }
        public CommandResult Create(VehicleMakeDto model)
        {
            try
            {
                //mapping -> bir nesneden başka bir nesneye verileri aktarma. çeşitlendirilebilir.eşleştirme.
                var vehicleMakeEntity = new VehicleMake()
                {
                    Name = model.Name,
                };

                _tourDbContext.VehicleMakes.Add(vehicleMakeEntity);
                _tourDbContext.SaveChanges();

                return CommandResult.Success();
               

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();
                
            }
        }

        public CommandResult Delete(VehicleMakeDto model)
        {
            if (model==null)
            {
                throw new ArgumentNullException(nameof(model), "model null olamaz");
            }
            //bu metot içerisinde tüm delete akışını ayrıca implement etmeye gerek yok
            //zaten bu işi ID üzerinden yapabilen Delete(id) implementation u mevcut
            //o yüzden bu metot çağırıldığında model.id değerini aşağıdaki metota göndererek
            //pratik bir kodlama yapılabilir.
            return Delete(model.Id);
        }

        public CommandResult Delete(int id)
        {
            var entity = new VehicleMake() { Id = id };

            //klasik yöntem
            //önce kaydı oku (entity izlemeye başlıyor), sonra remove ile context nesnesine silinmesi
            //gerektiğini bildir (state i deleted olarak işaretlenecek)
            //entity = _tourDbContext.VehicleMakes.Find(id);
            

            try
            {
                _tourDbContext.VehicleMakes.Remove(entity);
                _tourDbContext.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("bir hata meydana geldi, sistem yöneticisine başvurun");
               
            }
        }

        public IEnumerable<VehicleMakeDto> GetAll()
        {
            try
            {
              return  _tourDbContext.VehicleMakes
                    .Select(vm => new VehicleMakeDto()
                    {
                        Id = vm.Id,
                        Name = vm.Name
                    })
                    .ToList();

              //var allVehicleMakes =  _tourDbContext.VehicleMakes.ToList();

              //  var dtoList = new List<VehicleMakeDto>();
              //  foreach (var vehicleMake in allVehicleMakes)
              //  {
              //      dtoList.Add(new VehicleMakeDto()
              //      {
              //          Id = vehicleMake.Id,
              //          Name = vehicleMake.Name
              //      });
                   
              //  }

              //  return dtoList;
            }
            catch (Exception ex)
            {
                //Tekil bir kayıt için;
                //kaydın olma durumuna instance,
                //kaydın olmama durumuna null 

                //koleksiyon titpindeki bir veri için
                //verinin olma drumu instance (1 veya 1den fazla kayıt içerir şrkilde)
                //verinin olmama durumu boş koleksiyon

                //koleksiyonlar için null değerinden mümkün olduğunca kaçınmak gerekir. null durumu
                // bir koleksiyon boş olduğu anlamını taşımamalı.

                Trace.TraceError(ex.ToString());
              //  return new List<VehicleMakeDto>();

                return Enumerable.Empty<VehicleMakeDto>();
            }

        }

        public VehicleMakeDto GetById(int id)
        {
            // Find->DbSet üzerinde PrimaryKey ile bir kaydı bulmaya yarayan metot
            

            //Single -> yazılan kritere göre mutlaka 1 adet kayıt olmalı
            //SingleorDefault-> yazılan kriter karşılığında bir veya hiç kayıt olmalı.
            //First-> yazılan kriter karşılığında mutlaka 1 veya daha fazla kayıt olmalı, First metodu
            //bu kayıtlardan birincisini döndürecek.

            //Özetle; Linq metotlarında Tekil Kayıt döndürmeye yarayan Single, First, Last metotlarının
            //filtre kriterlerine yazılan ifadenin karşılığında kayıt dönmeme ihtimali varsa o durumda
            //bu metotların orDefault versiyonunu kullanın.

            //aşağıda singleordefault kullanarak ID değerine göre tek kayıt okuma örneği
            //teknik olarak yukarıdaki Find metotu ile aynı işi yapıyor. Sentax olarak çağırma şrkli farklı.

            //vehicleMake = _tourDbContext.VehicleMakes.SingleOrDefault(vm => vm.Id == id);

            try
            {
                var vehicleMake = _tourDbContext.VehicleMakes.Find(id);

                if (vehicleMake==null)
                {
                    return null;
                }

                var vehicleMakeDto = new VehicleMakeDto()
                {
                    Id = vehicleMake.Id,
                    Name = vehicleMake.Name
                };

                return vehicleMakeDto;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
            
        }

        public CommandResult Update(VehicleMakeDto model)
        {
            if (model==null)
            {
                //genel olarak bu tkniğe Guard veya Defensive Coding denir.
                // throw new ArgumentNullException(nameof(model), "VehicleMakeDto nesnesi null değer olamaz");
                return CommandResult.Failure("model nesnesi null olamaz");
            }

            //validation
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return CommandResult.Failure("marka adı boş geçilemez");
            }

            var entity = new VehicleMake()
            {
                Id = model.Id,
                Name = model.Name
            };

            try
            {
                _tourDbContext.VehicleMakes.Update(entity);
                _tourDbContext.SaveChanges();

              //  //eğer dotnet core değil de klasik .net framework ile ef kullanılıyor olsaydı
              //  //1.en klasik yöntem

              //  var vehicleMake1 = _tourDbContext.VehicleMakes.Find(model.Id);
              //  vehicleMake1.Name = model.Name;
              //  _tourDbContext.SaveChanges();

              //  //2.yöntem attach(db den kaydı okumaya gerek kalmadan)
              //  var vehicleMake2 = new VehicleMake()
              //  {
              //      Id = model.Id,
              //      Name = model.Name
              //  };

              //var entry =  _tourDbContext.Attach(vehicleMake2);
              //  entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
              //  _tourDbContext.SaveChanges();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("bir hata meydana geldi. sistem yöneticisine başvurun");
            }
         
        }

    }
}
