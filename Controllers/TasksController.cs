using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TaskApi.Models;

namespace TaskApi.Controllers;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
  private readonly string filePath = "Data/tasks.json";

  private List<TaskItem> ReadTasks()
  {
    if (!System.IO.File.Exists(filePath))
      return new List<TaskItem>();

    var json = System.IO.File.ReadAllText(filePath);
    return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
  }

  private void WriteTasks(List<TaskItem> tasks)
  {
    var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
    System.IO.File.WriteAllText(filePath, json);
  }

  // GET /tasks
  [HttpGet]
  public IActionResult Get()
  {
    return Ok(ReadTasks());
  }

  // POST /tasks
  [HttpPost]
  public IActionResult Post([FromBody] TaskItem newTask)
  {
    var tasks = ReadTasks();

    newTask.Id = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;

    tasks.Add(newTask);
    WriteTasks(tasks);

    return Created($"/tasks/{newTask.Id}", newTask);
  }

  // PUT /tasks/1
  [HttpPut("{id}")]
  public IActionResult Put(int id, [FromBody] TaskItem updatedTask)
  {
    var tasks = ReadTasks();

    var existing = tasks.FirstOrDefault(t => t.Id == id);
    if (existing == null)
      return NotFound();

    existing.Title = updatedTask.Title;
    existing.Description = updatedTask.Description;
    existing.Priority = updatedTask.Priority;
    existing.DueDate = updatedTask.DueDate;
    existing.Status = updatedTask.Status;

    WriteTasks(tasks);

    return Ok(existing);
  }

  // DELETE /tasks/1
  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var tasks = ReadTasks();

    var task = tasks.FirstOrDefault(t => t.Id == id);
    if (task == null)
      return NotFound();

    tasks.Remove(task);
    WriteTasks(tasks);

    return Ok();
  }
}
