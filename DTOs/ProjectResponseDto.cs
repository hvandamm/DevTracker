namespace DevTracker.DTOs;

public record ProjectResponseDto(int Id, string Name, string Description, List<TaskResponseDto> Tasks);