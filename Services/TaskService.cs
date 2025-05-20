public class TaskService : ITaskService
{
    private readonly AppDbContext _context;

    public TaskService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync(string userId)
    {
        return await _context.Tasks.Where(t => t.UserId == userId).ToListAsync();
    }
}