

using TarefasAPI.Models;
using TarefasAPI.Data;
using TarefasAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace TarefasAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UsersService _service;

        public UsersController(UsersService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAll();
            if(users == null){
                return StatusCode(500, "Ocorreu um erro ao buscar os usuários!"); // Retorna um erro genérico para o cliente
            }else{
               
                return StatusCode(200, $"Usuários encontrados com sucesso! Total de usuários: {users.Count}"); // Retorna uma mensagem de sucesso para o cliente
            
            }
            
        }

        [HttpGet("{id}")]
        public  async Task<IActionResult> Get(int id)
        {
            var users = await _service.GetUserById(id);
            if (users == null){
                         var errorMessage = $"ID {id} não encontrada.";
                         Console.WriteLine(errorMessage); // Log do erro para depuração
                         return StatusCode(500,$"Ocorreu um erro ao buscar a tarefa, {errorMessage}!"); // Retorna um erro genérico para o cliente  :
        }
            else{
                         return StatusCode(201, $"Usuário:{users.Name} com ID {id} encontrado com sucesso!"); // Retorna uma mensagem de sucesso para o cliente
            }
        }
        [HttpPost]
        public IActionResult Post(Users newUser)
        {
           
           
            var created = _service.Create(newUser);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Users updatedUser)
        {
            
            var updated = await _service.Update(id, updatedUser);
            if (updated == null)
             {
                var errorMessage = $"ID {id} não encontrada.";
                Console.WriteLine(errorMessage); // Log do erro para depuração
                return StatusCode(500,$"Ocorreu um erro ao atualizar o usuário, {errorMessage}!"); // Retorna um erro genérico para o cliente  :
             }
          else
             {
                return StatusCode(201, $"Usuário:{updated.Name} com ID {id} atualizado com sucesso!"); // Retorna uma mensagem de sucesso para o cliente
                
             } 

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedUser = await _service.Delete(id);
            if (deletedUser == null)
             {
                var errorMessage = $"ID {id} não encontrada.";
                Console.WriteLine(errorMessage); // Log do erro para depuração
                return StatusCode(500,$"Ocorreu um erro ao deletar o usuário, {errorMessage}!"); // Retorna um erro genérico para o cliente  :
             }
          else
             {
                return StatusCode(201, $"Usuário:{deletedUser.Name} com ID {id} deletado com sucesso!"); // Retorna uma mensagem de sucesso para o cliente
                
             } 

        }

}