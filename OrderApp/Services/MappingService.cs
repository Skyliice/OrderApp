using OrderApp.Models;

namespace OrderApp.Services;

public static class MappingService
{
    public static OrderClientDTO MapToDto(this Order? order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));
        OrderClientDTO orderDto = new()
        {
            UserId = order.UserId,
            AddressOfSender = order.AddressOfSender,
            CargoWeight = order.CargoWeight,
            CityOfSender = order.CityOfSender,
            ReceiptDate = order.ReceiptDate,
            RecipientAddress = order.RecipientAddress,
            RecipientCity = order.RecipientCity
        };
        return orderDto;
    }
}