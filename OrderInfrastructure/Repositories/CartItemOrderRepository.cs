using Microsoft.EntityFrameworkCore;
using OrderInfrastructure.Contexts;
using OrderInfrastructure.Entities;
using OrderInfrastructure.Factories;
using OrderInfrastructure.Models;
using System.Linq.Expressions;

namespace OrderInfrastructure.Repositories
{
    public class CartItemOrderRepository(OrderContext context) : Repo<CartItemOrderEntity>(context)
    {
        private readonly OrderContext _context = context;
    }
}
