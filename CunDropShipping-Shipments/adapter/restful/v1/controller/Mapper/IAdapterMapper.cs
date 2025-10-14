using CunDropShipping_Shipments.adapter.restful.v1.controller.Entity;
using CunDropShipping_Shipments.domain.Entity;

namespace CunDropShipping_Shipments.adapter.restful.v1.controller.Mapper;

public interface IAdapterMapper
{
    AdapterShipmentEntity ToAdapterShipment(DomainShipmentEntity domainShipment);
    
    List<AdapterShipmentEntity> ToAdapterShipmentList(List<DomainShipmentEntity> domainShipments);
    DomainShipmentEntity ToDomainShipment(AdapterShipmentEntity adapterShipment);
    List<DomainShipmentEntity> ToDomainShipments(List<AdapterShipmentEntity> adapterShipments);
}