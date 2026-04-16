
using TarefasAPI.Models;
using TarefasAPI.Data;
using TarefasAPI.DTOs;
using Microsoft.EntityFrameworkCore;



namespace TarefasAPI.Services;
public class TasksService
{
    private readonly AppDbContext _context;

    public TasksService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TasksItem>> GetAll()
    {
       
        
        return  await _context.TasksItems.ToListAsync();
    }

    public async Task<TasksItem> GetTaskById(int id)
    {
        return await _context.TasksItems.FirstOrDefaultAsync(t => t.Id == id && t.UserId == t.UserId);
    } 
    public TasksItem Create(TasksItem newTask)
    {
        _context.TasksItems.Add(newTask);
        _context.SaveChanges();
        return newTask;
    }

    public async Task<TasksItem> Update(int id, TasksItem updatedTask)
    {
        var startusTasks = await _context.TasksItems.FirstOrDefaultAsync(t => t.Id == id && t.UserId == t.UserId);
        if (startusTasks == null)
        {
            var errorMessage = $"ID {id} não encontrada.";
            Console.WriteLine(errorMessage); // Log do erro para depuração
            return null;
        }
        else
        {
            startusTasks.Title = updatedTask.Title;
            startusTasks.Completed = updatedTask.Completed;

            _context.SaveChanges();
            return startusTasks;    
        }

        
    }
    public async Task<TasksItem> Delete(int id)
    {
        var deleteTask = await _context.TasksItems.FirstOrDefaultAsync(t => t.Id == id && t.UserId == t.UserId);
        if (deleteTask == null)
        {
             var errorMessage = $"ID {id} não encontrada.";
            Console.WriteLine(errorMessage); // Log do erro para depuração
            return null;
        }
        else
        {
            _context.TasksItems.Remove(deleteTask);
            _context.SaveChanges();
            return deleteTask;
        }
    }
}
    