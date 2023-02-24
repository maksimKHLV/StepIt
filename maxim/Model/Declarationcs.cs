using kargo.Message;

namespace kargo.Model;

public class Declarationcs : ISendable
{

    public string? Warehouse { get; set; } 
    public string? TrackingNumber { get; set; }
    public string? SiteName { get; set; } 
    public string? ProductCategory { get; set; } 
    public string? InvoicePrice { get; set; } 
    public string? Currency { get; set; }
    public string? Note { get; set; } 
    public string? Quantity { get; set; } 
      
}