using System.ComponentModel.DataAnnotations;
using static OrderInfrastructure.Entities.CartItemOrderEntity;

namespace OrderInfrastructure.Entities;

public class OrderEntity
{
    [Key]
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public double? TotalAmount { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Phonenumber { get; set; }

    public string? ZipCode { get; set; }

    public string? CountryCode { get; set; }

    public string? Country { get; set; }

    public string? ShippingDate { get; set; }

    public string? ShippingStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public ICollection<CartItemOrderEntity> Items { get; set; } = new List<CartItemOrderEntity>();
}
