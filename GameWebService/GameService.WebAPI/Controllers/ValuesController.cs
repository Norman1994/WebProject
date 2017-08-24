using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameWebService.DAL.Models;
using GameWebService.DAL.EntityFramework;
using GameService.WebAPI.Context;

namespace GameService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private WebAPIContext gameContext;

        public ValuesController(WebAPIContext context)
        {
            gameContext = context;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Cервер подключён", "value2" };
        }

        // GET api/values/5
        [HttpGet("{login}/{password}")]
        public bool Get(string login, string password)
        {
            User currentUser = gameContext.Users.Where(x => x.Login == login).FirstOrDefault();
            if (currentUser != null)
            {
                if (currentUser.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]ResultData value)
        {
            User currentUser = gameContext.Users.Where(x => x.Login == value.Login).FirstOrDefault();
            Result currentResult = new Result
            {
                Score = value.Score,
                Time = value.Time,
                UserId = currentUser.UserId
            };

            gameContext.Results.Add(currentResult);
            gameContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class ResultData
    {
        public string Login { get; set; }
        public int Score { get; set; }
        public string Time { get; set; }
    }
}
