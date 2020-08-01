using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;
using WebApi.Service;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("GetFlatRows")]
    [Route("[controller]")]

    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Obter um usuário específico por ID.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <response code="200">O usuário foi obtido com sucesso.</response>
        /// <response code="404">Não foi encontrado usuário com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter o usuário.</response>
        [HttpGet]
        public async Task<ActionResult<List<Clientes>>> Get([FromServices] DataContext context)
        {
            var clientes = await context.Clientes.ToListAsync();
            return clientes;
        }

        /// <summary>
        /// Obter um Sistema específico por ID.
        /// </summary>
        /// <param name="id">ID do Sistema.</param>
        /// <response code="200">O Sistema foi obtido com sucesso.</response>
        /// <response code="404">Não foi encontrado Sistema com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter o usuário.</response>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Clientes>> GetSistema([FromServices] DataContext context, int id)
        {
            var clientes = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if(clientes == null)
            {
                return NotFound();
            }

            return clientes;
        }

        /// <summary>
        /// Cadastrar sistema.
        /// </summary>
        /// <param name="model">Modelo do sistema.</param>
        /// <response code="200">O sistema foi cadastrado com sucesso.</response>
        /// <response code="400">O modelo do sistema enviado é inválido.</response>
        /// <response code="500">Ocorreu um erro ao cadastrar o sistema.</response>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Clientes>> Post([FromServices] DataContext context, Clientes model)
        {
            if(ModelState.IsValid)
            {
                context.Clientes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Modificar um sistema específico por ID.
        /// </summary>
        /// <param name="model">Modelo do sistema.</param>
        /// <response code="200">O sistema foi obtido com sucesso.</response>
        /// <response code="404">Não foi encontrado sistema com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter o sistema.</response>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Clientes>> Update([FromServices] DataContext context, Clientes model)
        {
            if (ModelState.IsValid)
            {
                context.Clientes.Update(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Deletar um Sistema específico por ID.
        /// </summary>
        /// <param name="model">Modelo do sistema.</param>
        /// <response code="200">O Sistema foi obtido com sucesso.</response>
        /// <response code="404">Não foi encontrado Sistema com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter o Sistema.</response>
        [HttpPost]
        [Route("{id:int}")]
        public async Task<ActionResult<Clientes>> Delete([FromServices] DataContext context, int id)
        {
            if (ModelState.IsValid)
            {
                var model = context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

                context.Clientes.Remove(await model);
                await context.SaveChangesAsync();

                return NoContent();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
