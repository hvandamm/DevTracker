using DevTracker.Models;

namespace DevTracker.DTOs;

public record CreateTaskDto(string Title, DevTaskStatus Status);