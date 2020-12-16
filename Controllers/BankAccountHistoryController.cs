using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVCFinAppAPI.Data;
using MVCFinAppAPI.Models;

namespace MVCFinAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountHistoryController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IConfiguration _configuration;

        public BankAccountHistoryController(ApiDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<History> Get()
        {
            return _context.GetAllBankAccountHistory(_configuration);
        }
    }
}
