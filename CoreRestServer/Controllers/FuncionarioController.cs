using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreRestServer.DataLayerClasses;
using CoreRestServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreRestServer.Controllers
{
    [Produces("application/json")]
    [Route("api/Funcionario")]
    public class FuncionarioController : Controller
    {
        IConfiguration _configuration;
        public FuncionarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Funcionario
        [HttpGet]
        public IEnumerable<Funcionario> Get()
        {
            DataLayer dataLayer = new DataLayer(_configuration);
            return dataLayer.GetFuncionarios(0);
        }

        // GET: api/Funcionario/5
        
        [HttpGet("{id}", Name = "GetFuncionarioByID")]
        public Funcionario GetFuncionario(int id)
        {
            DataLayer dataLayer = new DataLayer(_configuration);
            return dataLayer.GetFuncionarios(id).ElementAt(0);
        }
        
        // POST: api/Funcionario
        [HttpPost]
        public IActionResult Post([FromBody]Funcionario funcionario)
        {
            DataLayer dataLayer = new DataLayer(_configuration);

            if (funcionario == null) return BadRequest();
            else
            {
                try
                {
                    return new ObjectResult(dataLayer.CreateFuncionario(funcionario));
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
        }

        // PUT: api/Funcionario/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Funcionario funcionario)
        {
            DataLayer dataLayer = new DataLayer(_configuration);

            if (funcionario == null) return BadRequest();
            else
            {
                try
                {
                    return new ObjectResult(dataLayer.UpdateFuncionario(id, funcionario));
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
        }

        // DELETE: api/Funcionario/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DataLayer dataLayer = new DataLayer(_configuration);
            dataLayer.DeleteFuncionario(id);
            return NoContent();
        }
    }
}
