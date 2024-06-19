using Microsoft.AspNetCore.Mvc;
using ProjetoInterfocus.Services;
using System.ComponentModel.DataAnnotations;
using ProjetoInterfocus.Entidades;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace ProjetoInterfocus.Controllers
{
    [Route("api/[controller]")]
    public class DividaController : ControllerBase
    {
        
        private readonly DividaService dividaService;

        public DividaController(DividaService dividaService){
            this.dividaService = dividaService;
        }

        [HttpGet]
        public IActionResult Listar(string query = null){
            var clientes = query == null ? dividaService.Listar() : dividaService.Listar(query);
            
        return Ok(clientes);
            
        }

        [HttpGet("{id}")]
        public IActionResult GetOneClient(int id){
            var cliente = dividaService.GetDivida(id);
            if (cliente == null){
                return NotFound();
            }else{
                return Ok(cliente);
            }
        }

        //FIXME possible problem
        [HttpPost]
        public IActionResult Registrar([FromBody] Divida divida){
            if (divida == null)
            {
                return BadRequest(ModelState);
            }
            var sucess = dividaService.Registrar(divida, out List<ValidationResult> erros);
            if(!sucess){
                return UnprocessableEntity(erros);
            }

            return Ok(divida);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Divida divida){
            if(divida == null){
                return BadRequest(ModelState);
            }
            var sucesso = dividaService.Editar(divida,
                out List<ValidationResult> erros);
            if (sucesso == false)
            {
                return UnprocessableEntity(erros);
            }
                return Ok(divida);
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var divida = dividaService.Excluir(id, out _);
            if (divida == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(divida);
            }
        }

    }
}

