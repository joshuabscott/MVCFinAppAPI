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
    public class HouseholdsController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public HouseholdsController(ApiDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpGet("GetAllHouseholds")]
        public IEnumerable<HouseHold> GetAllHouseHolds()
        {
            return _dbContext.GetAllHouseHoldData(_configuration);
        }
    }
}