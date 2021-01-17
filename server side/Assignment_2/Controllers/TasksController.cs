using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_2.Contracts;
using Assignment_2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        //declare the db manager 
        TasksManager WebDb = new TasksManager();

        //get list of Tasks
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(WebDb.GetAllTasks());
            }
            catch (Exception ex)
            {
                return NotFound("Couldn't get tasks list - error: " + ex.Message);
            }
        }
        //get task by task id
        [HttpGet("{id}")]
        public ActionResult<Task> GetById(int id)
        {

            Tasks CurrentTask;
            try
            {
                CurrentTask = WebDb.GetAllTasks().FirstOrDefault(Task => Task.Id == id);
                if (CurrentTask != null)
                {
                    return Ok(CurrentTask);
                }
            }
            catch (Exception ex)
            {
                return NotFound("Couldn't get task  for id: " + id + " error: " + ex.Message);
            }
            return NotFound();
        }

        //create a new Task
        [HttpPost("AddTask")]
        public IActionResult AddTask(Tasks Task)
        {

            try
            {
                if (Task != null)
                {
                    WebDb.AddTasks(Task);
                    WebDb.SaveChanges();
                    return Created("rentinfo/" + Task.Id, Task);
                }
            }
            catch (Exception ex)
            {
                return NotFound("Couldn't add task - error: " + ex.Message);
            }
            return NotFound();
        }
        //Update task
        [HttpPut("UpdateTask")]
        public IActionResult UpdateTask([FromBody] Tasks value)
        {
            try
            {
                if (value != null)
                {
                    WebDb.UpdateTasks(value);
                    WebDb.SaveChanges();
                    return Ok(value);
                }
            }
            catch (Exception ex)
            {
                return NotFound("Couldn't add  new task - error: " + ex.Message);
            }
            return NotFound();
        }
        //delete task
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {

            Tasks CurrentTask;
            try
            {
                CurrentTask = WebDb.GetAllTasks().FirstOrDefault(Task => Task.Id == id);
                if (CurrentTask != null)
                {
                    WebDb.DeleteTasks(CurrentTask);
                    WebDb.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return NotFound("Couldn't delete  task -  error: " + ex.Message);
            }
            return NotFound();
        }
    }
}