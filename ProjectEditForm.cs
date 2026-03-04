using System;
using System.Drawing;
using System.Windows.Forms;

namespace TracelessNotes;

public class ProjectEditForm : Form
{
    private readonly TextBox _titleTextBox = new();
    private readonly Button _okButton = new();
    private readonly Button _cancelButton = new();

    public string ProjectTitle
    {
        get => _titleTextBox.Text.Trim();
        set => _titleTextBox.Text = value ?? string.Empty;
    }

    public ProjectEditForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        Text = "项目";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        ClientSize = new Size(640, 260);
        MinimumSize = new Size(640, 260);

        var titleLabel = new Label
        {
            Text = "项目标题：",
            AutoSize = true,
            Left = 24,
            Top = 24
        };

        _titleTextBox.Left = 140;
        _titleTextBox.Top = 20;
        _titleTextBox.Width = 480;
        _titleTextBox.Height = 140;
        _titleTextBox.Multiline = true;
        _titleTextBox.ScrollBars = ScrollBars.Vertical;

        _okButton.Text = "确定";
        _okButton.Left = 400;
        _okButton.Top = 200;
        _okButton.Width = 100;
        _okButton.Height = 40;
        _okButton.DialogResult = DialogResult.OK;
        _okButton.Click += OkButton_Click;

        _cancelButton.Text = "取消";
        _cancelButton.Left = 520;
        _cancelButton.Top = 200;
        _cancelButton.Width = 100;
        _cancelButton.Height = 40;
        _cancelButton.DialogResult = DialogResult.Cancel;

        Controls.Add(titleLabel);
        Controls.Add(_titleTextBox);
        Controls.Add(_okButton);
        Controls.Add(_cancelButton);

        AcceptButton = _okButton;
        CancelButton = _cancelButton;
    }

    private void OkButton_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(ProjectTitle))
        {
            MessageBox.Show(this, "项目标题不能为空。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.None;
        }
    }
}

