using Microsoft.AspNetCore.Mvc;
using Core;
using MongoDB;
using Serverapi.repositories;
using Serverapi.Repositories;

namespace Serverapi.Controllers
{
    public class Usercontroller
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


}

