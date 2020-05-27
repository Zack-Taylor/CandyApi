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

        [HttpGet("user/{uid}/")]
        public IActionResult GetCandyByOwner(int uid)
        
        {
            var owner = _repository.GetCandyByOwner(uid);
            var isEmpty = !owner.Any();
            if (isEmpty)
            {
                return NotFound("This owner doesn't like candy. He flosses!");
            }
            return Ok(owner);
        }

        [HttpGet("user/{uid}/ate")]
        public IActionResult GetEatenCandy(int uid)
        {
            var usersCandyEaten = _repository.GetEatenCandy(uid);
            var change = !usersCandyEaten.Any();
            if (change)
            {
                return NotFound("You've not eaten any candy.");
            }
            return Ok(usersCandyEaten);
        }

        [HttpPost("user/{uid}/eat/{name}")]
        public IActionResult EatCandy(int uid, string name)
        {
            var CandyToEat = _repository.CandyToEat(uid,name);
            /// CandyToEat is not returning a value.
            var emptyBag = !CandyToEat.Any();
            if (emptyBag)
            {
                return NotFound("You ain't got nomo candy. Eat a salad!");
            }
            return Ok(CandyToEat);
        }
    }
}
