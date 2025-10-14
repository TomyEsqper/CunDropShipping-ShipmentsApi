namespace CunDropShipping_Shipments.adapter.restful.v1.controller.Entity;

public class AdapterShipmentEntity
{
    public int Id { get; set; }
    public DateTime ShippingDate {get; set; }
    public string TrackingNumber {get; set; }
}