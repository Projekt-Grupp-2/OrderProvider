using Microsoft.EntityFrameworkCore;
using OrderInfrastructure.Contexts;
using OrderInfrastructure.Entities;
using OrderInfrastructure.Factories;
using OrderInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderInfrastructure.Repositories
{
    public class OrderRepository(OrderContext context) : Repo<OrderEntity>(context)
    {
        private readonly OrderContext _context = context;

        public override async Task<ResponseResult> GetAllAsync()
        {
            try
            {
                var result = await _context.Set<OrderEntity>()
                    .Include(x => x.Items)
                    .ToListAsync();

                if (!result.Any())
                    return ResponseFactory.NotFound();

                return ResponseFactory.Ok(result);

            }

            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }


        public override async Task<ResponseResult> GetOneAsync(Expression<Func<OrderEntity, bool>> predicate)
        {
            try
            {
                var result = await _context.Set<OrderEntity>()
                    .Include(x => x.Items)
                    .FirstOrDefaultAsync(predicate);

                if (result == null)
                    return ResponseFactory.NotFound();

                return ResponseFactory.Ok(result);

            }

            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }
    }
}
