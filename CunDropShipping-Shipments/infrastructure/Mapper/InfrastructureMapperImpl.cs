using CunDropShipping_Shipments.domain.Entity;
using CunDropShipping_Shipments.infrastructure.Entity;
using CunDropShipping_Shipments.infrastructure.Mapper;

namespace CunDropShipping_Shipments.infrastructure.Mapper;

public class InfrastructureMapperImpl : IInfrastructureMapper
{
    public ShipmentsEntity ToInfrastructureEntity(DomainShipmentsEntity domainShipments)
    {
        return new ShipmentsEntity
        {
            Id = domainShipments.Id,
            ShippingDate = domainShipments.ShippingDate,
            TrackingNumber = domainShipments.TrackingNumber
        };
    }

    public List<ShipmentsEntity> ToInfrastructureEntityList(List<DomainShipmentsEntity> domainShipmentsList)
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

    public DomainShipmentsEntity ToDomainShipmentsEntity(ShipmentsEntity domainShipments)
    {
        return new DomainShipmentsEntity
        {
            Id = domainShipments.Id,
            ShippingDate = domainShipments.ShippingDate,
            TrackingNumber = domainShipments.TrackingNumber
        };
    }

    public List<DomainShipmentsEntity> ToDomainShipmentsEntityList(List<ShipmentsEntity> shipmentsEntities)
    {
        if (shipmentsEntities.Count() == 0)
        {
            return new List<DomainShipmentsEntity>();
        }

        return shipmentsEntities.Select(p => ToDomainShipmentsEntity(p)).ToList();
    }
}