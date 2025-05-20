public interface ITaskService
{
    Task<IEnumerable<TaskItem>> GetAllAsync(string userId);
}