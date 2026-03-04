namespace TracelessNotes
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer? components = null;

        private SplitContainer _splitContainer = null!;
        private Panel _projectHeaderPanel = null!;
        private Panel _todoHeaderPanel = null!;
        private FlowLayoutPanel _projectButtonPanel = null!;
        private FlowLayoutPanel _todoButtonPanel = null!;
        private DataGridView _projectListView = null!;
        private DataGridView _todoListView = null!;
        private Button _addProjectButton = null!;
        private Button _editProjectButton = null!;
        private Button _deleteProjectButton = null!;
        private Button _addTodoButton = null!;
        private Button _editTodoButton = null!;
        private Button _deleteTodoButton = null!;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            _splitContainer = new SplitContainer();
            _projectHeaderPanel = new Panel();
            _todoHeaderPanel = new Panel();
            _projectButtonPanel = new FlowLayoutPanel();
            _todoButtonPanel = new FlowLayoutPanel();
            _projectListView = new DataGridView();
            _todoListView = new DataGridView();
            _addProjectButton = new Button();
            _editProjectButton = new Button();
            _deleteProjectButton = new Button();
            _addTodoButton = new Button();
            _editTodoButton = new Button();
            _deleteTodoButton = new Button();
            ((System.ComponentModel.ISupportInitialize)_splitContainer).BeginInit();
            _splitContainer.Panel1.SuspendLayout();
            _splitContainer.Panel2.SuspendLayout();
            _splitContainer.SuspendLayout();
            _projectHeaderPanel.SuspendLayout();
            _todoHeaderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // _splitContainer
            // 
            _splitContainer.Dock = DockStyle.Fill;
            _splitContainer.Location = new Point(0, 0);
            _splitContainer.Name = "_splitContainer";
            _splitContainer.Panel1MinSize = 200;
            _splitContainer.Panel2MinSize = 400;
            // 
            // _splitContainer.Panel1
            // 
            _splitContainer.Panel1.Controls.Add(_projectListView);
            _splitContainer.Panel1.Controls.Add(_projectHeaderPanel);
            // 
            // _splitContainer.Panel2
            // 
            _splitContainer.Panel2.Controls.Add(_todoListView);
            _splitContainer.Panel2.Controls.Add(_todoHeaderPanel);
            _splitContainer.Size = new Size(1600, 1200);
            // 左右宽度比例 1:3（约 400 : 1200）
            _splitContainer.SplitterDistance = 400;
            _splitContainer.TabIndex = 0;
            // 
            // _projectHeaderPanel
            // 
            _projectHeaderPanel.Dock = DockStyle.Top;
            _projectHeaderPanel.Height = 50;
            _projectHeaderPanel.Padding = new Padding(8, 0, 8, 0);
            _projectHeaderPanel.BackColor = SystemColors.Window;
            _projectHeaderPanel.Controls.Add(_projectButtonPanel);
            // 
            // _todoHeaderPanel
            // 
            _todoHeaderPanel.Dock = DockStyle.Top;
            _todoHeaderPanel.Height = 50;
            _todoHeaderPanel.Padding = new Padding(8, 0, 8, 0);
            _todoHeaderPanel.BackColor = SystemColors.Window;
            _todoHeaderPanel.Controls.Add(_todoButtonPanel);

            // 
            // _projectButtonPanel
            // 
            _projectButtonPanel.Dock = DockStyle.Right;
            _projectButtonPanel.AutoSize = true;
            _projectButtonPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _projectButtonPanel.FlowDirection = FlowDirection.LeftToRight;
            _projectButtonPanel.WrapContents = false;
            _projectButtonPanel.Padding = new Padding(0, 5, 0, 5); // 垂直居中：60 高度里放 40 按钮
            _projectButtonPanel.Margin = new Padding(0);
            _projectButtonPanel.Controls.Add(_addProjectButton);
            _projectButtonPanel.Controls.Add(_editProjectButton);
            _projectButtonPanel.Controls.Add(_deleteProjectButton);

            // 
            // _todoButtonPanel
            // 
            _todoButtonPanel.Dock = DockStyle.Right;
            _todoButtonPanel.AutoSize = true;
            _todoButtonPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _todoButtonPanel.FlowDirection = FlowDirection.LeftToRight;
            _todoButtonPanel.WrapContents = false;
            _todoButtonPanel.Padding = new Padding(0, 5, 0, 5);
            _todoButtonPanel.Margin = new Padding(0);
            _todoButtonPanel.Controls.Add(_addTodoButton);
            _todoButtonPanel.Controls.Add(_editTodoButton);
            _todoButtonPanel.Controls.Add(_deleteTodoButton);
            // 
            // _projectListView
            // 
            _projectListView.Dock = DockStyle.Fill;
            _projectListView.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            _projectListView.BackgroundColor = Color.White;
            _projectListView.DefaultCellStyle.BackColor = Color.White;
            // 增大行高：在字体之外增加上下内边距
            _projectListView.RowTemplate.Height = 40;
            _projectListView.DefaultCellStyle.Padding = new Padding(4, 6, 4, 6);
            _projectListView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(228, 236, 248);
            // 表头样式：禁用选中高亮，保持统一背景
            _projectListView.EnableHeadersVisualStyles = false;
            _projectListView.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            _projectListView.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.WindowText;
            _projectListView.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Control;
            _projectListView.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.WindowText;
            _projectListView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            _projectListView.ColumnHeadersHeight = 50;
            _projectListView.Location = new Point(0, 60);
            _projectListView.MultiSelect = true;
            _projectListView.Name = "_projectListView";
            _projectListView.Size = new Size(400, 560);
            _projectListView.TabIndex = 0;
            _projectListView.AllowUserToAddRows = false;
            _projectListView.AllowUserToDeleteRows = false;
            _projectListView.ReadOnly = true;
            _projectListView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _projectListView.RowHeadersVisible = false;
            _projectListView.AutoGenerateColumns = false;
            _projectListView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            _projectListView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _projectListView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProjectOrder",
                HeaderText = "序号",
                Width = 100,
                ReadOnly = true
            });
            _projectListView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProjectTitle",
                HeaderText = "项目",
                Width = 300,
                ReadOnly = true,
                DefaultCellStyle = { WrapMode = DataGridViewTriState.True }
            });
            _projectListView.SelectionChanged += ProjectListView_SelectionChanged;
            _projectListView.DoubleClick += ProjectListView_DoubleClick;
            // 
            // _todoListView
            // 
            _todoListView.Dock = DockStyle.Fill;
            _todoListView.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            _todoListView.BackgroundColor = Color.White;
            _todoListView.DefaultCellStyle.BackColor = Color.White;
            _todoListView.RowTemplate.Height = 40;
            _todoListView.DefaultCellStyle.Padding = new Padding(4, 6, 4, 6);
            _todoListView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(228, 236, 248);
            _todoListView.EnableHeadersVisualStyles = false;
            _todoListView.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            _todoListView.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.WindowText;
            _todoListView.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Control;
            _todoListView.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.WindowText;
            _todoListView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            _todoListView.ColumnHeadersHeight = 50;
            _todoListView.Location = new Point(0, 60);
            _todoListView.MultiSelect = true;
            _todoListView.Name = "_todoListView";
            _todoListView.Size = new Size(596, 560);
            _todoListView.TabIndex = 0;
            _todoListView.AllowUserToAddRows = false;
            _todoListView.AllowUserToDeleteRows = false;
            _todoListView.ReadOnly = true;
            _todoListView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _todoListView.RowHeadersVisible = false;
            _todoListView.AutoGenerateColumns = false;
            _todoListView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            _todoListView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _todoListView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StartTime",
                HeaderText = "开始时间",
                Width = 210,
                ReadOnly = true
            });
            _todoListView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DueTime",
                HeaderText = "截止时间",
                Width = 210,
                ReadOnly = true
            });
            _todoListView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "待办描述",
                Width = 560,
                ReadOnly = true,
                DefaultCellStyle = { WrapMode = DataGridViewTriState.True }
            });
            _todoListView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Priority",
                HeaderText = "优先级别",
                Width = 120,
                ReadOnly = true
            });
            _todoListView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "状态",
                Width = 120,
                ReadOnly = true
            });
            _todoListView.CellFormatting += TodoListView_CellFormatting;
            _todoListView.DoubleClick += TodoListView_DoubleClick;
            // 
            // Project header buttons
            // 
            _addProjectButton.Text = "＋";
            _addProjectButton.Width = 40;
            _addProjectButton.Height = 40;
            _addProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _addProjectButton.Margin = new Padding(0, 0, 8, 0);
            _addProjectButton.FlatStyle = FlatStyle.Flat;
            _addProjectButton.FlatAppearance.BorderSize = 0;
            _addProjectButton.Click += AddProjectButton_Click;

            _editProjectButton.Text = "✎";
            _editProjectButton.Width = 40;
            _editProjectButton.Height = 40;
            _editProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            _editProjectButton.Margin = new Padding(0, 0, 8, 0);
            _editProjectButton.FlatStyle = FlatStyle.Flat;
            _editProjectButton.FlatAppearance.BorderSize = 0;
            _editProjectButton.Click += EditProjectButton_Click;

            _deleteProjectButton.Text = "✕";
            _deleteProjectButton.Width = 40;
            _deleteProjectButton.Height = 40;
            _deleteProjectButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            _deleteProjectButton.Margin = new Padding(0);
            _deleteProjectButton.FlatStyle = FlatStyle.Flat;
            _deleteProjectButton.FlatAppearance.BorderSize = 0;
            _deleteProjectButton.Click += DeleteProjectButton_Click;
            // 
            // Todo header buttons
            // 
            _addTodoButton.Text = "＋";
            _addTodoButton.Width = 40;
            _addTodoButton.Height = 40;
            _addTodoButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            _addTodoButton.Margin = new Padding(0, 0, 8, 0);
            _addTodoButton.FlatStyle = FlatStyle.Flat;
            _addTodoButton.FlatAppearance.BorderSize = 0;
            _addTodoButton.Click += AddTodoButton_Click;

            _editTodoButton.Text = "✎";
            _editTodoButton.Width = 40;
            _editTodoButton.Height = 40;
            _editTodoButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            _editTodoButton.Margin = new Padding(0, 0, 8, 0);
            _editTodoButton.FlatStyle = FlatStyle.Flat;
            _editTodoButton.FlatAppearance.BorderSize = 0;
            _editTodoButton.Click += EditTodoButton_Click;

            _deleteTodoButton.Text = "✕";
            _deleteTodoButton.Width = 40;
            _deleteTodoButton.Height = 40;
            _deleteTodoButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            _deleteTodoButton.Margin = new Padding(0);
            _deleteTodoButton.FlatStyle = FlatStyle.Flat;
            _deleteTodoButton.FlatAppearance.BorderSize = 0;
            _deleteTodoButton.Click += DeleteTodoButton_Click;

            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 1200);
            Controls.Add(_splitContainer);
            Name = "MainForm";
            this.Icon = new Icon("app.ico");
            StartPosition = FormStartPosition.CenterScreen;
            Text = "无痕记【TracelessNotes】";
            _splitContainer.Panel1.ResumeLayout(false);
            _splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_splitContainer).EndInit();
            _splitContainer.ResumeLayout(false);
            _projectHeaderPanel.ResumeLayout(false);
            _todoHeaderPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
