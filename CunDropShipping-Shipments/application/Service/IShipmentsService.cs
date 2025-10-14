using System.Runtime.Intrinsics.Arm;
using CunDropShipping_Shipments.domain.Entity;
namespace CunDropShipping_Shipments.application.Service;

public interface IShipmentsService
{
    List<DomainShipmentEntity> GetAllShipments();
    DomainShipmentEntity GetShipmentByTrakingNumber(string TrakingNumber);
    
    DomainShipmentEntity CreateShipment(DomainShipmentEntity shipment);
    
    
}