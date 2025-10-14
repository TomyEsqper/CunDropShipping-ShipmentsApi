using CunDropShipping_Shipments.adapter.restful.v1.controller.Entity;
using CunDropShipping_Shipments.domain.Entity;

namespace CunDropShipping_Shipments.adapter.restful.v1.controller.Mapper;

public class AdapterMapper : IAdapterMapper
{
    public AdapterShipmentEntity ToAdapterShipment(DomainShipmentEntity domainShipments)
    {
        return new AdapterShipmentEntity
        {
            Id = domainShipments.Id,
            ShippingDate = domainShipments.ShippingDate,
            TrackingNumber = domainShipments.TrackingNumber
        };
    }
    public List<AdapterShipmentEntity> ToAdapterShipmentList(List<DomainShipmentEntity> domainShipments)
    {
        return domainShipments.Count == 0
            ? new List<AdapterShipmentEntity>()
            : domainShipments.Select(ToAdapterShipment).ToList();
    }
    public DomainShipmentEntity ToDomainShipment(AdapterShipmentEntity adapterShipment)
    {
        return new DomainShipmentEntity
        {
            Id = adapterShipment.Id,
            ShippingDate = adapterShipment.ShippingDate,
            TrackingNumber = adapterShipment.TrackingNumber,
        };
    }

    public List<DomainShipmentEntity> ToDomainShipments(List<AdapterShipmentEntity> adapterShipments)
    {
        return adapterShipments.Count == 0
            ? new List<DomainShipmentEntity>()
            : adapterShipments.Select(ToDomainShipment).ToList();
    }
}