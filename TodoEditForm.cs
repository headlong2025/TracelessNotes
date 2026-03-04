using System;
using System.Drawing;
using System.Windows.Forms;

namespace TracelessNotes;

public class TodoEditForm : Form
{
    private readonly DateTimePicker _startPicker = new();
    private readonly DateTimePicker _duePicker = new();
    private readonly TextBox _descriptionTextBox = new();
    private readonly ComboBox _priorityComboBox = new();
    private readonly ComboBox _statusComboBox = new();
    private readonly Button _okButton = new();
    private readonly Button _cancelButton = new();

    public DateTime? StartTime
    {
        get => _startPicker.Value;
        set
        {
            if (value.HasValue)
            {
                _startPicker.Value = value.Value;
            }
        }
    }

    public DateTime? DueTime
    {
        get => _duePicker.Value;
        set
        {
            if (value.HasValue)
            {
                _duePicker.Value = value.Value;
            }
        }
    }

    public string Description
    {
        get => _descriptionTextBox.Text.Trim();
        set => _descriptionTextBox.Text = value ?? string.Empty;
    }

    public TodoPriority Priority
    {
        get => (TodoPriority)_priorityComboBox.SelectedIndex;
        set => _priorityComboBox.SelectedIndex = (int)value;
    }

    public TodoStatus Status
    {
        get => (TodoStatus)_statusComboBox.SelectedIndex;
        set => _statusComboBox.SelectedIndex = (int)value;
    }

    public TodoEditForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        Text = "待办事项";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        ClientSize = new Size(720, 440);
        MinimumSize = new Size(720, 440);

        var startLabel = new Label
        {
            Text = "开始时间：",
            AutoSize = true,
            Left = 24,
            Top = 24
        };

        _startPicker.Left = 140;
        _startPicker.Top = 20;
        _startPicker.Width = 550;
        _startPicker.Format = DateTimePickerFormat.Custom;
        _startPicker.CustomFormat = "yyyy-MM-dd HH:mm";

        var dueLabel = new Label
        {
            Text = "截止时间：",
            AutoSize = true,
            Left = 24,
            Top = 72
        };

        _duePicker.Left = 140;
        _duePicker.Top = 68;
        _duePicker.Width = 550;
        _duePicker.Format = DateTimePickerFormat.Custom;
        _duePicker.CustomFormat = "yyyy-MM-dd HH:mm";

        var descLabel = new Label
        {
            Text = "待办描述：",
            AutoSize = true,
            Left = 24,
            Top = 120
        };

        _descriptionTextBox.Left = 140;
        _descriptionTextBox.Top = 116;
        _descriptionTextBox.Width = 550;
        _descriptionTextBox.Height = 180;
        _descriptionTextBox.Multiline = true;
        _descriptionTextBox.ScrollBars = ScrollBars.Vertical;
        _descriptionTextBox.AcceptsReturn = true;

        var priorityLabel = new Label
        {
            Text = "优先级别：",
            AutoSize = true,
            Left = 24,
            Top = 320
        };

        _priorityComboBox.Left = 140;
        _priorityComboBox.Top = 316;
        _priorityComboBox.Width = 170;
        _priorityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        _priorityComboBox.Items.AddRange(new object[] { "高", "一般", "低" });
        _priorityComboBox.SelectedIndex = 1;

        var statusLabel = new Label
        {
            Text = "状态：",
            AutoSize = true,
            Left = 360,
            Top = 320
        };

        _statusComboBox.Left = 440;
        _statusComboBox.Top = 316;
        _statusComboBox.Width = 170;
        _statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        _statusComboBox.Items.AddRange(new object[] { "未开始", "进行中", "已完成" });
        _statusComboBox.SelectedIndex = 0;

        _okButton.Text = "确定";
        _okButton.Left = 480;
        _okButton.Top = 380;
        _okButton.Width = 100;
        _okButton.Height = 40;
        _okButton.DialogResult = DialogResult.OK;
        _okButton.Click += OkButton_Click;

        _cancelButton.Text = "取消";
        _cancelButton.Left = 600;
        _cancelButton.Top = 380;
        _cancelButton.Width = 100;
        _cancelButton.Height = 40;
        _cancelButton.DialogResult = DialogResult.Cancel;

        Controls.Add(startLabel);
        Controls.Add(_startPicker);
        Controls.Add(dueLabel);
        Controls.Add(_duePicker);
        Controls.Add(descLabel);
        Controls.Add(_descriptionTextBox);
        Controls.Add(priorityLabel);
        Controls.Add(_priorityComboBox);
        Controls.Add(statusLabel);
        Controls.Add(_statusComboBox);
        Controls.Add(_okButton);
        Controls.Add(_cancelButton);

        AcceptButton = _okButton;
        CancelButton = _cancelButton;
    }

    private void OkButton_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Description))
        {
            MessageBox.Show(this, "待办描述不能为空。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.None;
        }
    }
}

