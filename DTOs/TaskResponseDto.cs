using DevTracker.Models;

namespace DevTracker.DTOs;

public record TaskResponseDto(int Id, string Title, DevTaskStatus Status, int ProjectId);