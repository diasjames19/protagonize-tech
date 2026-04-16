

using TarefasAPI.Models;
using TarefasAPI.Data;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace TarefasAPI.Services;
public class UsersService
{
    private readonly AppDbContext _context;

    public UsersService(AppDbContext context)
    {
        _context = context;
    }

    public async  Task<List<Users>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<Users> GetUserById(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }  

    public Users Create(Users newUser)
    {
        newUser.Pass = BCrypt.Net.BCrypt.HashPassword(newUser.Pass);
        _context.Users.Add(newUser);
        _context.SaveChanges();
        return newUser;
    }

     public async Task<Users> Update(int id, Users updatedUser)
    {
        var startusUpdatedUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (startusUpdatedUser == null)
        {
            var errorMessage = $"ID {id} não encontrada.";
            Console.WriteLine(errorMessage); // Log do erro para depuração
            return null;
        }
        else
        {
            startusUpdatedUser.Name = updatedUser.Name;
            startusUpdatedUser.Email = updatedUser.Email;
            startusUpdatedUser.Pass = BCrypt.Net.BCrypt.HashPassword(updatedUser.Pass);

            _context.SaveChanges();
            return startusUpdatedUser;    
        }

        
    }
     public async Task<Users> Delete(int id)
    {
        var deleteUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (deleteUser == null)
        {
             var errorMessage = $"ID {id} não encontrada.";
            Console.WriteLine(errorMessage); // Log do erro para depuração
            return null;
        }
        else
        {
            _context.Users.Remove(deleteUser);
            _context.SaveChanges();
            return deleteUser;
        }
    }
}
    