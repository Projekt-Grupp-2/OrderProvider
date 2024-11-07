using Microsoft.EntityFrameworkCore;
using OrderInfrastructure.Contexts;
using OrderInfrastructure.Factories;
using OrderInfrastructure.Models;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace OrderInfrastructure.Repositories;

public class Repo<TEntity>(OrderContext context) where TEntity : class
{
    private readonly OrderContext _context = context;


    //Create One in database

    public virtual async Task<ResponseResult> CreateOneAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return ResponseFactory.Ok(entity);

        }

        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }


    //Get all from database
    public virtual async Task<ResponseResult> GetAllAsync()
    {
        try
        {
            IEnumerable<TEntity> result = await _context.Set<TEntity>().ToListAsync();
            return ResponseFactory.Ok(result);

        }

        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }


    //Get one from databse --- expression gör att det går att söka ut --> x => x.Id == id
    public virtual async Task<ResponseResult> GetOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (result == null)
                return ResponseFactory.NotFound();

            return ResponseFactory.Ok(result);

        }

        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }


    //Update one  --- expression gör att det går att söka ut --> x => x.Id == id
    public virtual async Task<ResponseResult> UpdateOneAsync(Expression<Func<TEntity, bool>> predicate, TEntity updatedEntity)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();

                return ResponseFactory.Ok(result);
            }

            return ResponseFactory.NotFound();

        }

        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }



    //Delete one --- expression gör att det går att söka ut --> x => x.Id == id
    public virtual async Task<ResponseResult> DeleteOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (result != null)
            {
                _context.Set<TEntity>().Remove(result);
                await _context.SaveChangesAsync();

                return ResponseFactory.Ok("Successfully Removed");
            }

            return ResponseFactory.NotFound();

        }

        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }



    //Search one --- expression gör att det går att söka ut --> x => x.Id == id
    public virtual async Task<ResponseResult> AlreadyExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().AnyAsync(predicate);
            if (result)
                return ResponseFactory.Exists();

            return ResponseFactory.NotFound();

        }

        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

}
