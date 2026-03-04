using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TracelessNotes;

public partial class MainForm : Form
{
    private readonly List<Project> _projects = new();
    private readonly List<TodoItem> _todos = new();

    public MainForm()
    {
        InitializeComponent();
        Load += OnLoad;
    }

    // ToolStrip 按钮事件包装
    private void AddProjectButton_Click(object? sender, EventArgs e) => AddProject();
    private void EditProjectButton_Click(object? sender, EventArgs e) => EditSelectedProject();
    private void DeleteProjectButton_Click(object? sender, EventArgs e) => DeleteSelectedProject();
    private void AddTodoButton_Click(object? sender, EventArgs e) => AddTodo();
    private void EditTodoButton_Click(object? sender, EventArgs e) => EditSelectedTodo();
    private void DeleteTodoButton_Click(object? sender, EventArgs e) => DeleteSelectedTodo();

    // DataGridView 事件包装
    private void ProjectListView_SelectionChanged(object? sender, EventArgs e) => RefreshTodosForSelectedProject();
    private void ProjectListView_DoubleClick(object? sender, EventArgs e) => EditSelectedProject();
    private void TodoListView_DoubleClick(object? sender, EventArgs e) => EditSelectedTodo();

    private void OnLoad(object? sender, EventArgs e)
    {
        try
        {
            Database.Initialize();
            LoadProjectsFromDatabase();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"初始化数据库失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadProjectsFromDatabase()
    {
        _projects.Clear();
        _projects.AddRange(Database.GetProjects());
        RefreshProjectListView();
    }

    private void RefreshProjectListView()
    {
        _projectListView.Rows.Clear();

        foreach (var project in _projects.OrderBy(p => p.Order).ThenBy(p => p.Id))
        {
            var rowIndex = _projectListView.Rows.Add(project.Order.ToString(), project.Title);
            var row = _projectListView.Rows[rowIndex];
            row.Tag = project;
        }

        RefreshTodosForSelectedProject();
    }

    private Project? GetSelectedProject()
    {
        if (_projectListView.SelectedRows.Count == 0)
        {
            return null;
        }

        return _projectListView.SelectedRows[0].Tag as Project;
    }

    private TodoItem? GetSelectedTodo()
    {
        if (_todoListView.SelectedRows.Count == 0)
        {
            return null;
        }

        return _todoListView.SelectedRows[0].Tag as TodoItem;
    }

    private void RefreshTodosForSelectedProject()
    {
        var project = GetSelectedProject();
        _todos.Clear();

        if (project != null)
        {
            _todos.AddRange(Database.GetTodosByProject(project.Id));
        }

        _todoListView.Rows.Clear();

        foreach (var todo in _todos)
        {
            var rowIndex = _todoListView.Rows.Add(
                todo.StartTime?.ToString("yyyy-MM-dd HH:mm") ?? string.Empty,
                todo.DueTime?.ToString("yyyy-MM-dd HH:mm") ?? string.Empty,
                todo.Description,
                PriorityToChinese(todo.Priority),
                StatusToChinese(todo.Status));

            var row = _todoListView.Rows[rowIndex];
            row.Tag = todo;
        }
    }

    private void TodoListView_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }

        var grid = (DataGridView)sender!;
        var columnName = grid.Columns[e.ColumnIndex].Name;

        if (columnName == "Priority")
        {
            var text = e.Value as string;
            if (text == "高")
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 230, 230);
                e.CellStyle.ForeColor = Color.DarkRed;
            }
        }
        else if (columnName == "Status")
        {
            var text = e.Value as string;
            if (text == "已完成")
            {
                e.CellStyle.BackColor = Color.FromArgb(225, 245, 225);
                e.CellStyle.ForeColor = Color.DarkGreen;
            }
        }
    }

    private static string PriorityToChinese(TodoPriority priority) =>
        priority switch
        {
            TodoPriority.High => "高",
            TodoPriority.Normal => "一般",
            TodoPriority.Low => "低",
            _ => "一般"
        };

    private static string StatusToChinese(TodoStatus status) =>
        status switch
        {
            TodoStatus.NotStarted => "未开始",
            TodoStatus.InProgress => "进行中",
            TodoStatus.Completed => "已完成",
            _ => "未开始"
        };

    private void AddProject()
    {
        var order = _projects.Count == 0 ? 1 : _projects.Max(p => p.Order) + 1;
        var dialog = new ProjectEditForm();

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        var project = Database.AddProject(dialog.ProjectTitle, order);
        _projects.Add(project);
        RefreshProjectListView();
    }

    private void EditSelectedProject()
    {
        var project = GetSelectedProject();
        if (project == null)
        {
            return;
        }

        var dialog = new ProjectEditForm
        {
            ProjectTitle = project.Title
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        project.Title = dialog.ProjectTitle;
        Database.UpdateProject(project);
        RefreshProjectListView();
    }

    private void DeleteSelectedProject()
    {
        var project = GetSelectedProject();
        if (project == null)
        {
            return;
        }

        var result = MessageBox.Show(
            this,
            $"确定删除项目“{project.Title}”及其所有待办吗？",
            "确认删除",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
        {
            return;
        }

        Database.DeleteProject(project.Id);
        _projects.Remove(project);
        RefreshProjectListView();
    }

    private void AddTodo()
    {
        var project = GetSelectedProject();
        if (project == null)
        {
            MessageBox.Show(this, "请先选择一个项目。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var dialog = new TodoEditForm
        {
            StartTime = DateTime.Now,
            DueTime = DateTime.Now.AddDays(1),
            Priority = TodoPriority.Normal,
            Status = TodoStatus.NotStarted
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        var todo = new TodoItem
        {
            ProjectId = project.Id,
            StartTime = dialog.StartTime,
            DueTime = dialog.DueTime,
            Description = dialog.Description,
            Priority = dialog.Priority,
            Status = dialog.Status
        };

        Database.AddTodo(todo);
        _todos.Add(todo);
        RefreshTodosForSelectedProject();
    }

    private void EditSelectedTodo()
    {
        var todo = GetSelectedTodo();
        if (todo == null)
        {
            return;
        }

        var dialog = new TodoEditForm
        {
            StartTime = todo.StartTime,
            DueTime = todo.DueTime,
            Description = todo.Description,
            Priority = todo.Priority,
            Status = todo.Status
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        todo.StartTime = dialog.StartTime;
        todo.DueTime = dialog.DueTime;
        todo.Description = dialog.Description;
        todo.Priority = dialog.Priority;
        todo.Status = dialog.Status;

        Database.UpdateTodo(todo);
        RefreshTodosForSelectedProject();
    }

    private void DeleteSelectedTodo()
    {
        var todo = GetSelectedTodo();
        if (todo == null)
        {
            return;
        }

        var result = MessageBox.Show(
            this,
            "确定删除该待办事项吗？",
            "确认删除",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
        {
            return;
        }

        Database.DeleteTodo(todo.Id);
        _todos.Remove(todo);
        RefreshTodosForSelectedProject();
    }
}
