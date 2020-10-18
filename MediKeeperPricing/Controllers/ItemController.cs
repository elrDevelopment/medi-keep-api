using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace MediKeeperPricing.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/item")]
    public class ItemController : Controller
    {
        private IItemService _service;

        public ItemController(IItemService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetItemByItemName(string name)
        {
            var result = _service.GetAllItemByName(name);
            return Ok(result);
        }
        [HttpPost]
        [Route("")]
        public IActionResult CreateItem(ItemDTO dto)
        {
            var result = _service.CreateItem(dto);
            return Ok(result);
        }
        [HttpPut]
        [Route("")]
        public IActionResult UpdateItems(ItemDTO dto)
        {
            var result = _service.UpdateItem(dto);
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetItemById(int id)
        {
            var result = _service.GetItemById(id);
            return Ok(result);
        }
        
        [HttpGet]
        [Route("list")]
        public IActionResult GetItems()
        {
            var result = _service.GetAllItems();
            return Ok(result);
        }
        [HttpGet]
        [Route("maxcost/{name}")]
        public IActionResult MaxCostByItemName(string name)
        {
            var result = _service.GetMaxCostForItemName(name);
            return Ok(result);
        }
        [HttpGet]
        [Route("maxcost")]
        public IActionResult MaxCostByItems()
        {
            var result = _service.GetMaxCostForItems();
            return Ok(result);
        }

        
    }
}