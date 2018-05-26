using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreRestServer.Models;
using Microsoft.Extensions.Configuration;
using CoreRestServer.DataLayerClasses;
using System.Net.Http;

namespace CoreRestServer.Controllers
{
    [Produces("application/json")]
    [Route("api/Financeiro")]
    public class FinanceiroController : Controller
    {
        IConfiguration _configuration;

        public FinanceiroController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Financeiro
        [HttpGet]
        public IEnumerable<Financeiro> Get()
        {
            DataLayer dataLayer = new DataLayer(_configuration);
            return dataLayer.GetFinanceiros(0);
        }

        // GET: api/Financeiro/{id}
        [HttpGet("{id}", Name = "GetFinanceiroByID")]
        public Financeiro Get(int id)
        {
            DataLayer dataLayer = new DataLayer(_configuration);
            return dataLayer.GetFinanceiros(id).ElementAt(0);
        }

        // GET: api/Financeiro/BySetor?setor={setor}
        [Route("BySetor")]
        [HttpGet("{setor}", Name = "GetFinanceiroBySetor")]
        public IEnumerable<Financeiro> Get(string setor)
        {
            DataLayer dataLayer = new DataLayer(_configuration);
            return dataLayer.GetFinanceirosBySetor(setor);
        }

        // POST: api/Financeiro
        [HttpPost]
        public IActionResult Post([FromBody]Financeiro financeiro)
        {
            DataLayer dataLayer = new DataLayer(_configuration);

            if (financeiro == null) return BadRequest();
            else
            {
                try
                {
                    return new ObjectResult(dataLayer.CreateFinanceiro(financeiro));
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            
        }
        
        // PUT: api/Financeiro/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Financeiro financeiro)
        {
            DataLayer dataLayer = new DataLayer(_configuration);

            if (financeiro == null) return BadRequest();
            else
            {
                try
                {
                    return new ObjectResult(dataLayer.UpdateFinanceiro(id, financeiro));
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }       
        }
        
        // DELETE: api/Financeiro/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DataLayer dataLayer = new DataLayer(_configuration);
            dataLayer.DeleteFinanceiro(id);
            return NoContent();
        }
    }
}
