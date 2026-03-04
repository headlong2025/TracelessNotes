using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace TracelessNotes;

public static class Database
{
    private const string ConnectionString = "Data Source=tracelessnotes.db";

    public static void Initialize()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        EnableForeignKeys(connection);

        using (var cmd = connection.CreateCommand())
        {
            cmd.CommandText =
                """
                CREATE TABLE IF NOT EXISTS Projects (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    SortOrder INTEGER NOT NULL,
                    Title TEXT NOT NULL
                );
                """;
            cmd.ExecuteNonQuery();
        }

        using (var cmd = connection.CreateCommand())
        {
            cmd.CommandText =
                """
                CREATE TABLE IF NOT EXISTS Todos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ProjectId INTEGER NOT NULL,
                    StartTime TEXT NULL,
                    DueTime TEXT NULL,
                    Description TEXT NOT NULL,
                    Priority INTEGER NOT NULL,
                    Status INTEGER NOT NULL,
                    FOREIGN KEY (ProjectId) REFERENCES Projects(Id) ON DELETE CASCADE
                );
                """;
            cmd.ExecuteNonQuery();
        }
    }

    private static void EnableForeignKeys(SqliteConnection connection)
    {
        using var cmd = connection.CreateCommand();
        cmd.CommandText = "PRAGMA foreign_keys = ON;";
        cmd.ExecuteNonQuery();
    }

    public static List<Project> GetProjects()
    {
        var result = new List<Project>();

        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        EnableForeignKeys(connection);

        using var cmd = connection.CreateCommand();
        cmd.CommandText =
            """
            SELECT Id, SortOrder, Title
            FROM Projects
            ORDER BY SortOrder, Id;
            """;

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Project
            {
                Id = reader.GetInt32(0),
                Order = reader.GetInt32(1),
                Title = reader.GetString(2)
            });
        }

        return result;
    }

    public static Project AddProject(string title, int order)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        EnableForeignKeys(connection);

        using var cmd = connection.CreateCommand();
        cmd.CommandText =
            """
            INSERT INTO Projects (SortOrder, Title)
            VALUES ($order, $title);
            SELECT last_insert_rowid();
            """;
        cmd.Parameters.AddWithValue("$order", order);
        cmd.Parameters.AddWithValue("$title", title);

        var id = (long)cmd.ExecuteScalar()!;

        return new Project
        {
            Id = (int)id,
            Order = order,
            Title = title
        };
    }

    public static void UpdateProject(Project project)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        EnableForeignKeys(connection);

        using var cmd = connection.CreateCommand();
        cmd.CommandText =
            """
            UPDATE Projects
            SET SortOrder = $order,
                Title = $title
            WHERE Id = $id;
            """;
        cmd.Parameters.AddWithValue("$order", project.Order);
        cmd.Parameters.AddWithValue("$title", project.Title);
        cmd.Parameters.AddWithValue("$id", project.Id);

        cmd.ExecuteNonQuery();
    }

    public static void DeleteProject(int projectId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        EnableForeignKeys(connection);

        using var cmd = connection.CreateCommand();
        cmd.CommandText =
            """
            DELETE FROM Projects
            WHERE Id = $id;
            """;
        cmd.Parameters.AddWithValue("$id", projectId);
        cmd.ExecuteNonQuery();
    }

    public static List<TodoItem> GetTodosByProject(int projectId)
    {
        var result = new List<TodoItem>();

        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        EnableForeignKeys(connection);

        using var cmd = connection.CreateCommand();
        cmd.CommandText =
            """
            SELECT Id, ProjectId, StartTime, DueTime, Description, Priority, Status
            FROM Todos
            WHERE ProjectId = $projectId
            ORDER BY DueTime IS NULL, DueTime, Id;
            """;
        cmd.Parameters.AddWithValue("$projectId", projectId);

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            DateTime? ParseDateTime(int ordinal)
            {
                if (reader.IsDBNull(ordinal))
                {
                    return null;
                }

                var s = reader.GetString(ordinal);
                return DateTime.TryParse(s, out var dt) ? dt : null;
            }

            result.Add(new TodoItem
            {
                Id = reader.GetInt32(0),
                ProjectId = reader.GetInt32(1),
                StartTime = ParseDateTime(2),
                DueTime = ParseDateTime(3),
                Description = reader.GetString(4),
                Priority = (TodoPriority)reader.GetInt32(5),
                Status = (TodoStatus)reader.GetInt32(6)
            });
        }

        return result;
    }

    public static TodoItem AddTodo(TodoItem todo)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        EnableForeignKeys(connection);

        using var cmd = connection.CreateCommand();
        cmd.CommandText =
            """
            INSERT INTO Todos (ProjectId, StartTime, DueTime, Description, Priority, Status)
            VALUES ($projectId, $startTime, $dueTime, $description, $priority, $status);
            SELECT last_insert_rowid();
            """;
        cmd.Parameters.AddWithValue("$projectId", todo.ProjectId);
        cmd.Parameters.AddWithValue("$startTime", todo.StartTime?.ToString("s") ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("$dueTime", todo.DueTime?.ToString("s") ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("$description", todo.Description);
        cmd.Parameters.AddWithValue("$priority", (int)todo.Priority);
        cmd.Parameters.AddWithValue("$status", (int)todo.Status);

        var id = (long)cmd.ExecuteScalar()!;
        todo.Id = (int)id;
        return todo;
    }

    public static void UpdateTodo(TodoItem todo)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        EnableForeignKeys(connection);

        using var cmd = connection.CreateCommand();
        cmd.CommandText =
            """
            UPDATE Todos
            SET ProjectId = $projectId,
                StartTime = $startTime,
                DueTime = $dueTime,
                Description = $description,
                Priority = $priority,
                Status = $status
            WHERE Id = $id;
            """;
        cmd.Parameters.AddWithValue("$projectId", todo.ProjectId);
        cmd.Parameters.AddWithValue("$startTime", todo.StartTime?.ToString("s") ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("$dueTime", todo.DueTime?.ToString("s") ?? (object)DBNull.Value);
        cmd.Parameters.AddWithValue("$description", todo.Description);
        cmd.Parameters.AddWithValue("$priority", (int)todo.Priority);
        cmd.Parameters.AddWithValue("$status", (int)todo.Status);
        cmd.Parameters.AddWithValue("$id", todo.Id);

        cmd.ExecuteNonQuery();
    }

    public static void DeleteTodo(int todoId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        EnableForeignKeys(connection);

        using var cmd = connection.CreateCommand();
        cmd.CommandText =
            """
            DELETE FROM Todos
            WHERE Id = $id;
            """;
        cmd.Parameters.AddWithValue("$id", todoId);
        cmd.ExecuteNonQuery();
    }
}

