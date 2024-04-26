using Microsoft.AspNetCore.Mvc;
using Core;
using MongoDB;
using Serverapi.repositories;
using Serverapi.Repositories;

namespace Serverapi.Controllers
{
   

        [ApiController]
        [Route("api/users")]
        public class UserController : ControllerBase
        {
            private IUserRepository mRepo;

            public UserController(IUserRepository repo)
            {
                mRepo = repo;
            }

            [HttpGet]
            [Route("getall")]
            public IEnumerable<User> GetAll()
            {
                return mRepo.GetAll();
            }

        [HttpGet]
        [Route("checklogin")]
        public bool CheckLogin([FromQuery] string email, [FromQuery] string password)
        {
            return mRepo.CheckLogin(email, password);
        }



        [HttpPost]
            [Route("add")]
            public void AddItem(User product)
            {
                mRepo.AddItem(product);
            }

            [HttpDelete]
            [Route("delete/{id:int}")]
            public void DeleteItem(int id)
            {
                mRepo.DeleteById(id);
            }

            [HttpPut]
            [Route("update")]
            public void UpdateItem(User product)
            {
                mRepo.UpdateItem(product);
            }


        }
    }




