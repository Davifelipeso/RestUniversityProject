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
    [Route("api/Galpao")]
    public class GalpaoController : Controller
    {

        IConfiguration _configuration;

        public GalpaoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Galpao
        [HttpGet]
        public IEnumerable<Galpao> Get()
        {
            DataLayer dataLayer = new DataLayer(_configuration);
            return dataLayer.GetGalpoes(0);
        }

        // GET: api/Galpao/5
        [HttpGet("{id}", Name = "GetGalpaoByID")]
        public Galpao Get(int id)
        {
            DataLayer dataLayer = new DataLayer(_configuration);
            return dataLayer.GetGalpoes(id).ElementAt(0);
        }
        
        // POST: api/Galpao
        [HttpPost]
        public IActionResult Post([FromBody]Galpao galpao)
        {
            DataLayer dataLayer = new DataLayer(_configuration);
            Galpao log = galpao;

            if (galpao == null) return BadRequest();
            else
            {
                try
                {
                    return new ObjectResult(dataLayer.CreateGalpao(galpao));
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
        }
        
        // PUT: api/Galpao/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Galpao galpao)
        {
            DataLayer dataLayer = new DataLayer(_configuration);

            if (galpao == null) return BadRequest();
            else
            {
                try
                {
                    return new ObjectResult(dataLayer.UpdateGalpao(id, galpao));
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DataLayer dataLayer = new DataLayer(_configuration);
            dataLayer.DeleteGalpao(id);
            return NoContent();
        }
    }
}
