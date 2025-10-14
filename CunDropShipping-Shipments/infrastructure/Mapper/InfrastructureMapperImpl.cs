using CunDropShipping_Shipments.domain.Entity;
using CunDropShipping_Shipments.infrastructure.Entity;
using CunDropShipping_Shipments.infrastructure.Mapper;

namespace CunDropShipping_Shipments.infrastructure.Mapper;

public class InfrastructureMapperImpl : IInfrastructureMapper
{
    public ShipmentsEntity ToInfrastructureEntity(DomainShipmentEntity domainShipments)
    {
        return new ShipmentsEntity
        {
            Id = domainShipments.Id,
            ShippingDate = domainShipments.ShippingDate,
            TrackingNumber = domainShipments.TrackingNumber
        };
    }

    public List<ShipmentsEntity> ToInfrastructureEntityList(List<DomainShipmentEntity> domainShipmentsList)
    {
        if (domainShipmentsList.Count() == 0)
        {
            return new List<ShipmentsEntity>();
        }
        else
        {
            return domainShipmentsList.Select(ToInfrastructureEntity).ToList();
        }
    }

    public DomainShipmentEntity ToDomainShipmentsEntity(ShipmentsEntity domainShipments)
    {
        return new DomainShipmentEntity
        {
            Id = domainShipments.Id,
            ShippingDate = domainShipments.ShippingDate,
            TrackingNumber = domainShipments.TrackingNumber
        };
    }

    public List<DomainShipmentEntity> ToDomainShipmentsEntityList(List<ShipmentsEntity> shipmentsEntities)
    {
        if (shipmentsEntities.Count() == 0)
        {
            return new List<DomainShipmentEntity>();
        }

        return shipmentsEntities.Select(p => ToDomainShipmentsEntity(p)).ToList();
    }
}