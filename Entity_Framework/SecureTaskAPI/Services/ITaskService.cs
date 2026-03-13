using SecureTaskAPI.Models;
using SecureTaskAPI.DTOs;

namespace SecureTaskAPI.Services
{
    public interface ITaskService
    {
        User CreateUser(CreateUserDTO dto);

        TaskItem CreateTask(CreateTaskDTO dto);

        List<TaskItem> GetTasksByUser(int userId);

        TaskItem UpdateTask(int taskId, bool status);

        bool DeleteTask(int taskId);
    }
}