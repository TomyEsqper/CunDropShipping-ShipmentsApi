using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CunDropShipping_Shipments.infrastructure.Entity;

[Table("Shipments")]
public class ShipmentsEntity
{
    public int Id { get; set; }
    [Required]
    public DateTime ShippingDate {get; set;}
    [Required]
    public string TrackingNumber {get; set;}
    
}