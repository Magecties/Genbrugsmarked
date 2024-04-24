using Microsoft.AspNetCore.Mvc;
using Core;
using MongoDB;
using Serverapi.repositories;
using Serverapi.Repositories;

namespace Serverapi.Controllers
{
    

        [ApiController]
        [Route("api/rooms")]
        public class RoomController : ControllerBase
        {
            private IRoomRepository mRepo;

            public RoomController(IRoomRepository repo)
            {
                mRepo = repo;
            }

            [HttpGet]
            [Route("getall")]
            public IEnumerable<Room> GetAll()
            {
                return mRepo.GetAll();
            }



            [HttpPost]
            [Route("add")]
            public void AddItem(Room product)
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
            public void UpdateItem(Room product)
            {
                mRepo.UpdateItem(product);
            }


        }
    }




