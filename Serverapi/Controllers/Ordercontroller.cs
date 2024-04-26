using Microsoft.AspNetCore.Mvc;
using Core;
using MongoDB;
using Serverapi.repositories;
using Serverapi.Repositories;

namespace Serverapi.Controllers
{
    
       
        [ApiController]
        [Route("api/orders")]
        public class OrderController : ControllerBase
        {
            private IOrderRepository mRepo;

            public OrderController(IOrderRepository repo)
            {
                mRepo = repo;
            }

            [HttpGet]
            [Route("getall")]
            public IEnumerable<Order> GetAll()
            {
                return mRepo.GetAll();
            }

        [HttpGet]
        [Route("getbyemail/{email}")]
        public List<Order> GetOrderByEmail(string email)
        {
            return mRepo.GetOrdersByEmail(email);
        }


        [HttpPost]
            [Route("add")]
            public void AddItem(Order item)
            {
                mRepo.AddItem(item);
            }

            [HttpDelete]
            [Route("delete/{id:int}")]
            public void DeleteItem(int id)
            {
                mRepo.DeleteById(id);
            }

            [HttpPut]
            [Route("update")]
            public void UpdateItem(Order product)
            {
                mRepo.UpdateItem(product);
            }


        }
    }




