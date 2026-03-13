using SecureTaskAPI.Models;
using SecureTaskAPI.DTOs;
using SecureTaskAPI.Data;

namespace SecureTaskAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public User CreateUser(CreateUserDTO dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public TaskItem CreateTask(CreateTaskDTO dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                UserId = dto.UserId,
                IsCompleted = false
            };

            _context.Tasks.Add(task);
            _context.SaveChanges();

            return task;
        }

        public List<TaskItem> GetTasksByUser(int userId)
        {
            return _context.Tasks
                .Where(t => t.UserId == userId)
                .ToList();
        }

        public TaskItem UpdateTask(int taskId, bool status)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == taskId);

            if (task == null)
                return null;

            task.IsCompleted = status;

            _context.SaveChanges();

            return task;
        }

        public bool DeleteTask(int taskId)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == taskId);

            if (task == null)
                return false;

            _context.Tasks.Remove(task);

            _context.SaveChanges();

            return true;
        }
    }
}