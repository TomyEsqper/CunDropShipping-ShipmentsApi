namespace CunDropShipping_Shipments.domain.Entity;

public class DomainShipmentsEntity
{
    public int Id { get; set; }
    public DateTime ShippingDate {get; set;}
    public string TrackingNumber {get; set;}
}