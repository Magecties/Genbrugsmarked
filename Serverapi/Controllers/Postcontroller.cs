using Microsoft.AspNetCore.Mvc;
using Core;
using MongoDB;
using Serverapi.repositories;
using Serverapi.Repositories;

namespace Serverapi.Controllers
{
    

        [ApiController]
        [Route("api/posts")]
        public class PostController : ControllerBase
        {
            private IpostRepository mRepo;

            public PostController(IpostRepository repo)
            {
                mRepo = repo;
            }

            [HttpGet]
            [Route("getall")]
            public IEnumerable<Post> GetAll()
            {
                return mRepo.GetAll();
            }



            [HttpPost]
            [Route("add")]
            public void AddItem(Post product)
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
            public void UpdateItem(Post product)
            {
                mRepo.UpdateItem(product);
            }


        }
    }


