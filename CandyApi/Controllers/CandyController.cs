using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyApi.DataAccess;
using CandyApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace CandyApi.Controllers
{
    [Route("api/candies")]
    [ApiController]
    public class CandyController : ControllerBase
    {
        CandyRepository _repository;

        public CandyController(CandyRepository repository)
        {
            _repository = repository;
        }

        //api/candies
        [HttpGet]
        public IActionResult GetAllCandy()
        {
            var allCandies = _repository.GetAll();

            return Ok(allCandies);
        }
    }
}
