using CunDropShipping_Shipments.domain.Entity;
using CunDropShipping_Shipments.infrastructure.Entity;

namespace CunDropShipping_Shipments.infrastructure.Mapper;

public interface IInfrastructureMapper
{
    ShipmentsEntity ToInfrastructureEntity(DomainShipmentsEntity domainShipment);
    List<ShipmentsEntity> ToInfrastructureEntityList(List<DomainShipmentsEntity> domainShipmentsList);
    DomainShipmentsEntity ToDomainShipmentsEntity(ShipmentsEntity domainShipment);
    List<DomainShipmentsEntity> ToDomainShipmentsEntityList(List<ShipmentsEntity> shipmentsEntities);
}