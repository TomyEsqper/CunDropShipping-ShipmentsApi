using CunDropShipping_Shipments.application.Service;
using CunDropShipping_Shipments.domain.Entity;
// ¡IMPORTANTE! Necesitas usar el Repository aquí.
using CunDropShipping_Shipments.infrastructure.DbContext; 

namespace CunDropShipping_Shipments.domain
{
    public class ShipmentServiceImp : IShipmentsService
    {
        // El servicio necesita una instancia del repositorio para darle órdenes.
        private readonly Repository _repository;

        // Se inyecta a través del constructor.
        public ShipmentServiceImp(Repository repository)
        {
            _repository = repository;
        }

        public List<DomainShipmentEntity> GetAllShipments()
        {
            // --- ¡AQUÍ ESTÁ LA CORRECCIÓN! ---
            // Simplemente llamamos al método del repositorio que hace el trabajo real.
            return _repository.GetAllShipments();
        }

        public DomainShipmentEntity GetShipmentByTrakingNumber(string TrakingNumber)
        {
            // Hacemos lo mismo para los otros métodos.
            return _repository.GetShipmentByTrakingNumber(TrakingNumber);
        }

        public DomainShipmentEntity CreateShipment(DomainShipmentEntity shipment)
        {
            return _repository.CreateShipment(shipment);
        }
    }
}