using System;

namespace TracelessNotes;

public class Project
{
    public int Id { get; set; }
    public int Order { get; set; }
    public string Title { get; set; } = string.Empty;
}

public enum TodoPriority
{
    High = 0,
    Normal = 1,
    Low = 2
}

public enum TodoStatus
{
    NotStarted = 0,
    InProgress = 1,
    Completed = 2
}

public class TodoItem
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? DueTime { get; set; }
    public string Description { get; set; } = string.Empty;
    public TodoPriority Priority { get; set; }
    public TodoStatus Status { get; set; }
}

