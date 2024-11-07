using System.ComponentModel.DataAnnotations;
namespace OrderInfrastructure.Entities;

public class CartItemOrderEntity
{
    [Key]
    public int CartItemOrderId { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public OrderEntity? Order { get; set; }

}
