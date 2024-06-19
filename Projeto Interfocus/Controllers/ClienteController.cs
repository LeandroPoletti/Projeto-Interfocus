using Microsoft.AspNetCore.Mvc;
using ProjetoInterfocus.Services;
using System.ComponentModel.DataAnnotations;
using ProjetoInterfocus.Entidades;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace ProjetoInterfocus.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        
        private readonly ClienteService clienteService;

        public ClienteController(ClienteService clienteService){
            this.clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult Listar(string query = null){
            var clientes = query == null ? clienteService.Listar() : clienteService.Listar(query);
            
        

        return Ok(clientes);
            
        }

        [HttpGet("{id}")]
        public IActionResult GetOneClient(int id){
            var cliente = clienteService.GetCliente(id);
            if (cliente == null){
                return NotFound();
            }else{
                return Ok(cliente);
            }
        }

        [HttpPost]
        public IActionResult Registrar([FromBody] Cliente cliente){
            if (cliente == null)
            {
                return BadRequest(ModelState);
            }
            var sucess = clienteService.Registrar(cliente, out List<ValidationResult> erros);
            if(!sucess){
                return UnprocessableEntity(erros);
            }

            return Ok(cliente);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Cliente cliente){
            if(cliente == null){
                return BadRequest(ModelState);
            }
            var sucesso = clienteService.Editar(cliente,
                out List<ValidationResult> erros);
            if (sucesso == false)
            {
                return UnprocessableEntity(erros);
            }
                return Ok(cliente);
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var cliente = clienteService.Excluir(id, out _);
            if (cliente == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cliente);
            }
        }

    }
}

