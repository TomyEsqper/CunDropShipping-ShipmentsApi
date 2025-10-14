using CunDropShipping_Shipments.domain.Entity;
using CunDropShipping_Shipments.infrastructure.Entity;
using CunDropShipping_Shipments.infrastructure.Mapper; // Asegúrate que este using sea el correcto
using Microsoft.EntityFrameworkCore;

namespace CunDropShipping_Shipments.infrastructure.DbContext
{
    public class Repository 
    {
        private readonly AppDbContext _context;
        private readonly IInfrastructureMapper _mapper;

        public Repository(AppDbContext context, IInfrastructureMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DomainShipmentEntity> GetAllShipments()
        {
            var dbEntities = _context.Shipments.AsNoTracking().ToList();
            // CORREGIDO: Usamos el método correcto del mapper de infraestructura
            return _mapper.ToDomainShipmentsEntityList(dbEntities);
        }

        public DomainShipmentEntity GetShipmentByTrakingNumber(string trakingNumber)
        {
            var dbEntity = _context.Shipments
                .AsNoTracking()
                .FirstOrDefault(s => s.TrackingNumber == trakingNumber);

            if (dbEntity == null)
            {
                return null;
            }
            // CORREGIDO: Usamos el método correcto del mapper de infraestructura
            return _mapper.ToDomainShipmentsEntity(dbEntity);
        }

        public DomainShipmentEntity CreateShipment(DomainShipmentEntity shipment)
        {
            string nextTrackingNumber = GenerateNextTrackingNumber();
            
            var newShipmentEntity = new ShipmentsEntity
            {
                TrackingNumber = nextTrackingNumber,
                ShippingDate = DateTime.UtcNow
            };

            _context.Shipments.Add(newShipmentEntity);
            _context.SaveChanges();

            // CORREGIDO: Usamos el método correcto del mapper de infraestructura
            return _mapper.ToDomainShipmentsEntity(newShipmentEntity);
        }
        
        // --- El método para generar el Tracking Number se queda igual ---
        private string GenerateNextTrackingNumber()
        {
            // ... (la lógica que ya teníamos)
            var lastShipment = _context.Shipments
                                     .OrderByDescending(s => s.Id)
                                     .FirstOrDefault();
            if (lastShipment == null || string.IsNullOrEmpty(lastShipment.TrackingNumber))
            {
                return "AAA000";
            }
            string letters = lastShipment.TrackingNumber.Substring(0, 3);
            int numbers = int.Parse(lastShipment.TrackingNumber.Substring(3));
            numbers++;
            if (numbers > 999)
            {
                numbers = 0;
                char[] letterChars = letters.ToCharArray();
                for (int i = letterChars.Length - 1; i >= 0; i--)
                {
                    if (letterChars[i] < 'Z')
                    {
                        letterChars[i]++;
                        break;
                    }
                    else
                    {
                        letterChars[i] = 'A';
                    }
                }
                letters = new string(letterChars);
            }
            return $"{letters}{numbers:D3}";
        }
    }
}