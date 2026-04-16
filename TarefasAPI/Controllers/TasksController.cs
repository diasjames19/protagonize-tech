

using TarefasAPI.Models;
using TarefasAPI.Data;
using TarefasAPI.DTOs;
using TarefasAPI.Services;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace TarefasAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TasksService _service;

    public TasksController(TasksService service)
    {
        _service = service;
    }

[Authorize]
[HttpGet]
public async Task<IActionResult> GetAll()
{
    var claim = User.FindFirst("Id")?.Value;

    if (!int.TryParse(claim, out int checkuserId))
        return StatusCode(400, "ID do usuário inválido!"); // Retorna um erro de solicitação para o cliente

    var allTasks = await _service.GetAll();

    var tasks = allTasks
        .Where(t => t.UserId == checkuserId)
        .Select(t => new TasksItemResponseDto
        {
            Id = t.Id,
            Title = t.Title,
            Completed = t.Completed
        })
        .ToList();

    return Ok(new
    {
        message = "Tarefas encontradas com sucesso!",
        total = tasks.Count,
        data = tasks,
        statusCode = 201
    });
}

    [Authorize]  
    [HttpGet("{id}")]
    public  async Task<IActionResult> GetTaskById(int id)
    {

         var claim = User.FindFirst("Id")?.Value;
        
        
        if (!int.TryParse(claim, out int checkuserId))
            return StatusCode(400, "ID do usuário inválido!"); // Retorna um erro de solicitação para o cliente

        var taskItemId = await _service.GetTaskById(id);
        var tasks = taskItemId;
    if (tasks != null && tasks.UserId == checkuserId)
    {
        return Ok(new
        {
             message = "Tarefa encontradas com sucesso!",
             data = tasks,
             statusCode = 201
       });
    }
    
    return StatusCode(404, "Tarefa não encontrada!");
    }

    [Authorize]
    [HttpPost]
    public  IActionResult Post(TasksItemDto dto)
    {
        var claim = User.FindFirst("Id")?.Value;


        if (!int.TryParse(claim, out int checkuserId))
            return StatusCode(400, "ID do usuário inválido!"); // Retorna um erro de solicitação para o cliente

        var taskItemId =  _service.Create(new TasksItem
        {
            Title = dto.Title,
            Completed = false,
            UserId = checkuserId
        });
        var tasks = taskItemId;
    if (tasks != null && tasks.UserId == checkuserId)
    {
        return Ok(new
        {
             message = "Tarefa Criada com sucesso!",
             data = tasks,
             statusCode = 201
       });
    }
    
     return StatusCode(404, "Não foi possivel criar Tarefa!");

    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, TasksItem task)
    {
       var claim = User.FindFirst("Id")?.Value;
       
        if (!int.TryParse(claim, out int checkuserId))
            return StatusCode(400, "ID do usuário inválido!"); 

        var taskItemId = await _service.Update(id, task);
        var tasksUpdate = taskItemId;
    if (tasksUpdate != null && tasksUpdate.UserId == checkuserId)
    {
        return Ok(new
        {
             message = "Tarefa Atualizada com sucesso!",
             data = tasksUpdate,
             statusCode = 201
       });   
        
       
    }
    
     return StatusCode(404, "Tarefa não encontrada!");

    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var claim = User.FindFirst("Id")?.Value;
       
        if (!int.TryParse(claim, out int checkuserId))
            return StatusCode(400, "ID do usuário inválido!"); 

        var taskItemId = await _service.Delete(id);
        var tasksDelete = taskItemId;
    if (tasksDelete != null && tasksDelete.UserId == checkuserId)
    {
        return Ok(new
        {
             message = "Tarefa Deletada com sucesso!",
             data = tasksDelete,
             statusCode = 201
        });   
        
       
        }
    
            return StatusCode(404, "Tarefa não encontrada!");

        }

    }



       