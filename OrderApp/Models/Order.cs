using System.ComponentModel.DataAnnotations;

namespace OrderApp.Models;

public class Order
{
    public string? Id { get; set; }
    [Required(ErrorMessage= "This field must be filled in")]
    [StringLength(30, ErrorMessage = "Field length can't be more than 30.")]
    public string? CityOfSender { get; set; }
    [Required(ErrorMessage= "This field must be filled in")]
    [StringLength(50, ErrorMessage = "Field length can't be more than 50.")]
    public string? AddressOfSender { get; set; }
    [Required(ErrorMessage= "This field must be filled in")]
    [StringLength(30, ErrorMessage = "Field length can't be more than 30.")]
    public string? RecipientCity { get; set; }
    [Required(ErrorMessage= "This field must be filled in")]
    [StringLength(50, ErrorMessage = "Field length can't be more than 50.")]
    public string? RecipientAddress { get; set; }
    [Required(ErrorMessage= "This field must be filled in")]
    public double CargoWeight { get; set; }
    [Required(ErrorMessage= "This field must be filled in")]
    public DateTime ReceiptDate { get; set; }
}