using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/item/[action]")]
    public class ItemController : Controller
    {
        private readonly ModelItemContext _context;

        public ItemController(ModelItemContext context)
        {
            _context = context;

            if (_context.ModelItemsData.Count() == 0)
            {
                _context.ModelItemsData.Add(new ModelItem { Name = "Item" });
                _context.SaveChanges();
            }
        }

        /*Getting model items*/
        [HttpGet]
        public IEnumerable<ModelItem> GetAll()
        {
            return _context.ModelItemsData.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var item_1 = _context.ModelItemsData.FirstOrDefault(t => t.Id == id);
            if (item_1 == null)
            {
                return NotFound();
            }
            return Ok(item_1);
        }
        [HttpGet("{name}")]
        public ActionResult GetByName(string name)
        {
            var item_1 = _context.ModelItemsData.FirstOrDefault(t => t.Name == name);
            if (item_1 == null)
            {
                return NotFound();
            }
            return Ok(item_1);
        }
        [HttpGet("{description}")]
        public ActionResult GetByDescription(string description)
        {
            var item_1 = _context.ModelItemsData.FirstOrDefault(t => t.Description == description || t.Name == description);
            if (item_1 == null)
            {
                return NotFound();
            }
            return Ok(item_1);
        }

        [HttpPost]
        public ActionResult Create([FromBody] ModelItem item_2)
        {
            string Date1 = DateTime.Now.ToString("dddd, dd MMMM yyyy");

            if (item_2 == null)
            {                
                return BadRequest();
            }

            ModelItem model = new ModelItem
            {
                Name = item_2.Name,
                Description = item_2.Description,
                UnitPrice = item_2.UnitPrice,
                UnitAvailable =item_2.UnitAvailable,
                Date = Date1
            };

            _context.ModelItemsData.Add(model);
            _context.SaveChanges();

            return CreatedAtRoute("GetItem", new { id = item_2.Id }, item_2);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] ModelItem item_3)
        {
            if (item_3 == null || item_3.Id != id)
            {
                return BadRequest();
            }

            var item_4 = _context.ModelItemsData.FirstOrDefault(t => t.Id == id);
            if (item_4 == null)
            {
                return NotFound();
            }

            item_4.Name = item_3.Name;
            item_4.Description = item_3.Description;
            // item_4.Date = item_3.Date;
            item_4.UnitPrice = item_3.UnitPrice;
            item_4.UnitAvailable = item_3.UnitAvailable;
            _context.ModelItemsData.Update(item_4);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var item_4 = _context.ModelItemsData.FirstOrDefault(t => t.Id == id);
            if (item_4 == null)
            {
                return NotFound();
            }

            _context.ModelItemsData.Remove(item_4);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // GET: api/<controller>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}


        // GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        
    }
}


















