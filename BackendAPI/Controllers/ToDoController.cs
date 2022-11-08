using Microsoft.AspNetCore.Mvc;
using BackendAPI.Models;

namespace BackendAPI.Controllers
{
    public class ToDoController : ControllerBase
    {
        [HttpGet("category")]
        public IEnumerable<string> GetCat()
        {
            var categories = Database.toDoList.GroupBy(p => p.Category).Select(x => x.FirstOrDefault().Category);
            categories = categories.Append("All");//improve
            return categories;
        }

        [HttpGet("categoryall")]
        public IEnumerable<ToDo> GetDet(string category)
        {
            if (category == "All")
                return Database.toDoList;
            var toDoData = Database.toDoList.Where(x => x.Category == category);
            return toDoData;
        }

        [HttpGet("sort")]
        public IEnumerable<ToDo> GetSort(int id)
        {
            List<ToDo> list = Database.toDoList;
            if (id == 1)
            {
                list = list.OrderBy(x => x.Priority).ToList();
            }
            else if (id == 2)
            {
                list = list.OrderByDescending(x => x.Priority).ToList();
            }
            else if (id == 3)
            {
                list = list.OrderBy(x => x.DueDate).ToList();
            }
            else if (id == 4)
            {
                list = list.OrderByDescending(x => x.DueDate).ToList();
            }
            return list;
        }

        [HttpGet("home")]
        public IEnumerable<ToDo> Get()
        {
            return Database.toDoList;
        }
        [HttpGet("get-one")]
        // GET api/<controller>/5
        public ToDo Get(int id)
        {
            return (ToDo)(from x in Database.toDoList where x.Id == id select x);
        }
        [HttpPost("home")]
        // POST api/<controller>
        public ToDo Post([FromBody] ToDo toDo)
        {
            Database.ids++;
            toDo.Id = Database.ids;
            Database.toDoList.Add(toDo);
            return toDo;
        }

        [HttpPut("home")]
        // PUT api/<controller>/5
        public void Put(int id, [FromBody] ToDo value)
        {
            var uptodo = (from x in Database.toDoList where x.Id == id select x).SingleOrDefault();
            uptodo.Name = value.Name;
            uptodo.Desc = value.Desc;
            uptodo.Status = value.Status;
            uptodo.Category = value.Category;
            uptodo.DueDate = value.DueDate;
            uptodo.Priority = value.Priority;
        }

        [HttpDelete("home")]
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            Database.toDoList.RemoveAll(x => x.Id == id);
        }


    }
}
