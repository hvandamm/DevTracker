using System.Text.Json.Serialization;

namespace DevTracker.Models;

public enum DevTaskStatus
{
    Todo,
    InProgress,
    Blocked,
    Done
}

public class Project 
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;

    // A Project can have many DevTasks (One-to-Many)
    public List<DevTask> Tasks { get; set; } = new();
}

public class DevTask 
{
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public DevTaskStatus Status { get; set; } = DevTaskStatus.Todo;

    // Foreign Key back to Project
    public int ProjectId { get; set; }

    // Navigation property 
    // [JsonIgnore] prevents circular reference errors during JSON serialization in the API
    [JsonIgnore]
    public Project? Project { get; set; }
}
