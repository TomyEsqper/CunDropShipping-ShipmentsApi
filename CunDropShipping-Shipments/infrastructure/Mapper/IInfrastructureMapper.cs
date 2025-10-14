using CunDropShipping_Shipments.domain.Entity;
using CunDropShipping_Shipments.infrastructure.Entity;

namespace CunDropShipping_Shipments.infrastructure.Mapper;

public interface IInfrastructureMapper
{
    ShipmentsEntity ToInfrastructureEntity(DomainShipmentEntity domainShipment);
    List<ShipmentsEntity> ToInfrastructureEntityList(List<DomainShipmentEntity> domainShipmentsList);
    DomainShipmentEntity ToDomainShipmentsEntity(ShipmentsEntity domainShipment);
    List<DomainShipmentEntity> ToDomainShipmentsEntityList(List<ShipmentsEntity> shipmentsEntities);
}