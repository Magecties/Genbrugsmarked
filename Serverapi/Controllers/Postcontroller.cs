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

        [HttpGet]
        [Route("getbyemail/{email}")]
        public List<Post> GetPostsByEmail(string email)
        {
            return mRepo.GetPostsByEmail(email);
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
            public void UpdateItem(int id, Post product)
            {
                mRepo.UpdateItem(id, product);
            }


        }
    }


