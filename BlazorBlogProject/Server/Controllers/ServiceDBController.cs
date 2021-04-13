using BlazorBlogProject.Server.Data;
using BlazorBlogProject.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBlogProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceDBController : ControllerBase
    {
        private readonly DbContextClass _dbContextClass;
        public ServiceDBController(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        [HttpGet]
        public ActionResult<List<EIGENAAR>> TotaalAantal()
        {
            return Ok(_dbContextClass.EIGENAAR);
        }

        [HttpPost]
        public async Task<EIGENAAR> VoegToe(EIGENAAR eigenaar)
        {
            _dbContextClass.Add(eigenaar);
            await _dbContextClass.SaveChangesAsync();
            return eigenaar;
        }
    }
}
