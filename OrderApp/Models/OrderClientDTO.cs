namespace OrderApp.Models;

public class OrderClientDTO
{
    public int? UserId { get; set; }
    public string? CityOfSender { get; set; }
    public string? AddressOfSender { get; set; }
    public string? RecipientCity { get; set; }
    public string? RecipientAddress { get; set; }
    public double CargoWeight { get; set; }
    public DateTime ReceiptDate { get; set; }
}