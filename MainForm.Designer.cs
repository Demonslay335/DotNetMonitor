
namespace DotNetMonitor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.LoadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MonitoredGroupBox = new System.Windows.Forms.GroupBox();
            this.MonitoredTreeView = new System.Windows.Forms.TreeView();
            this.CallsGroupBox = new System.Windows.Forms.GroupBox();
            this.CallsDataGridView = new System.Windows.Forms.DataGridView();
            this.ParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.ParametersDataGridView = new System.Windows.Forms.DataGridView();
            this.ParameterOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParameterType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParameterValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexGroupBox = new System.Windows.Forms.GroupBox();
            this.ApiGroup = new System.Windows.Forms.GroupBox();
            this.ApiDataViewGrid = new System.Windows.Forms.DataGridView();
            this.ApiEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ApiFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApiName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApiOverride = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApiOverridable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RandomContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ReconstructRandomSequenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CallOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallHash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallTicks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallModule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallReturnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.MonitoredGroupBox.SuspendLayout();
            this.CallsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CallsDataGridView)).BeginInit();
            this.ParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParametersDataGridView)).BeginInit();
            this.ApiGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ApiDataViewGrid)).BeginInit();
            this.RandomContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadFileToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1467, 24);
            this.MenuStrip.TabIndex = 0;
            // 
            // LoadFileToolStripMenuItem
            // 
            this.LoadFileToolStripMenuItem.Name = "LoadFileToolStripMenuItem";
            this.LoadFileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.LoadFileToolStripMenuItem.Text = "Load File";
            this.LoadFileToolStripMenuItem.Click += new System.EventHandler(this.LoadFileToolStripMenuItem_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Title = "Select .NET assembly";
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 668);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(1467, 22);
            this.StatusStrip.TabIndex = 1;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(1452, 17);
            this.StatusLabel.Spring = true;
            this.StatusLabel.Text = "Idle";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MonitoredGroupBox
            // 
            this.MonitoredGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MonitoredGroupBox.Controls.Add(this.MonitoredTreeView);
            this.MonitoredGroupBox.Location = new System.Drawing.Point(13, 28);
            this.MonitoredGroupBox.Name = "MonitoredGroupBox";
            this.MonitoredGroupBox.Size = new System.Drawing.Size(299, 393);
            this.MonitoredGroupBox.TabIndex = 2;
            this.MonitoredGroupBox.TabStop = false;
            this.MonitoredGroupBox.Text = "Monitored Assemblies";
            // 
            // MonitoredTreeView
            // 
            this.MonitoredTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitoredTreeView.Location = new System.Drawing.Point(3, 16);
            this.MonitoredTreeView.Name = "MonitoredTreeView";
            this.MonitoredTreeView.Size = new System.Drawing.Size(293, 374);
            this.MonitoredTreeView.TabIndex = 0;
            this.MonitoredTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MonitoredTreeView_AfterSelect);
            // 
            // CallsGroupBox
            // 
            this.CallsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CallsGroupBox.Controls.Add(this.CallsDataGridView);
            this.CallsGroupBox.Location = new System.Drawing.Point(319, 28);
            this.CallsGroupBox.Name = "CallsGroupBox";
            this.CallsGroupBox.Size = new System.Drawing.Size(1136, 393);
            this.CallsGroupBox.TabIndex = 3;
            this.CallsGroupBox.TabStop = false;
            this.CallsGroupBox.Text = "Calls";
            // 
            // CallsDataGridView
            // 
            this.CallsDataGridView.AllowUserToAddRows = false;
            this.CallsDataGridView.AllowUserToDeleteRows = false;
            this.CallsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.CallsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.CallsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CallsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CallOrder,
            this.CallHash,
            this.CallTime,
            this.CallTicks,
            this.CallModule,
            this.CallMethod,
            this.CallReturnValue});
            this.CallsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CallsDataGridView.Location = new System.Drawing.Point(3, 16);
            this.CallsDataGridView.Name = "CallsDataGridView";
            this.CallsDataGridView.ReadOnly = true;
            this.CallsDataGridView.RowHeadersVisible = false;
            this.CallsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CallsDataGridView.Size = new System.Drawing.Size(1130, 374);
            this.CallsDataGridView.TabIndex = 0;
            this.CallsDataGridView.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.CallsDataGridView_CellContextMenuStripNeeded);
            this.CallsDataGridView.SelectionChanged += new System.EventHandler(this.CallsDataGridView_SelectionChanged);
            // 
            // ParametersGroupBox
            // 
            this.ParametersGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ParametersGroupBox.Controls.Add(this.ParametersDataGridView);
            this.ParametersGroupBox.Location = new System.Drawing.Point(319, 427);
            this.ParametersGroupBox.Name = "ParametersGroupBox";
            this.ParametersGroupBox.Size = new System.Drawing.Size(617, 238);
            this.ParametersGroupBox.TabIndex = 4;
            this.ParametersGroupBox.TabStop = false;
            this.ParametersGroupBox.Text = "Parameters";
            // 
            // ParametersDataGridView
            // 
            this.ParametersDataGridView.AllowUserToAddRows = false;
            this.ParametersDataGridView.AllowUserToDeleteRows = false;
            this.ParametersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParametersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterOrder,
            this.ParameterType,
            this.ParameterName,
            this.ParameterValue});
            this.ParametersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParametersDataGridView.Location = new System.Drawing.Point(3, 16);
            this.ParametersDataGridView.Name = "ParametersDataGridView";
            this.ParametersDataGridView.ReadOnly = true;
            this.ParametersDataGridView.RowHeadersVisible = false;
            this.ParametersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ParametersDataGridView.Size = new System.Drawing.Size(611, 219);
            this.ParametersDataGridView.TabIndex = 0;
            this.ParametersDataGridView.SelectionChanged += new System.EventHandler(this.ParametersDataGridView_SelectionChanged);
            // 
            // ParameterOrder
            // 
            this.ParameterOrder.DataPropertyName = "Position";
            this.ParameterOrder.HeaderText = "Order";
            this.ParameterOrder.Name = "ParameterOrder";
            this.ParameterOrder.ReadOnly = true;
            // 
            // ParameterType
            // 
            this.ParameterType.DataPropertyName = "ParameterType";
            this.ParameterType.HeaderText = "Type";
            this.ParameterType.Name = "ParameterType";
            this.ParameterType.ReadOnly = true;
            // 
            // ParameterName
            // 
            this.ParameterName.DataPropertyName = "Name";
            this.ParameterName.HeaderText = "Name";
            this.ParameterName.Name = "ParameterName";
            this.ParameterName.ReadOnly = true;
            // 
            // ParameterValue
            // 
            this.ParameterValue.DataPropertyName = "Value";
            this.ParameterValue.HeaderText = "Value";
            this.ParameterValue.Name = "ParameterValue";
            this.ParameterValue.ReadOnly = true;
            // 
            // HexGroupBox
            // 
            this.HexGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HexGroupBox.Location = new System.Drawing.Point(942, 428);
            this.HexGroupBox.Name = "HexGroupBox";
            this.HexGroupBox.Size = new System.Drawing.Size(513, 237);
            this.HexGroupBox.TabIndex = 5;
            this.HexGroupBox.TabStop = false;
            this.HexGroupBox.Text = "Hex Buffer";
            // 
            // ApiGroup
            // 
            this.ApiGroup.Controls.Add(this.ApiDataViewGrid);
            this.ApiGroup.Location = new System.Drawing.Point(16, 428);
            this.ApiGroup.Name = "ApiGroup";
            this.ApiGroup.Size = new System.Drawing.Size(293, 237);
            this.ApiGroup.TabIndex = 6;
            this.ApiGroup.TabStop = false;
            this.ApiGroup.Text = "API Filter";
            // 
            // ApiDataViewGrid
            // 
            this.ApiDataViewGrid.AllowUserToAddRows = false;
            this.ApiDataViewGrid.AllowUserToDeleteRows = false;
            this.ApiDataViewGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ApiDataViewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ApiDataViewGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ApiEnabled,
            this.ApiFullName,
            this.ApiName,
            this.ApiOverride,
            this.ApiOverridable});
            this.ApiDataViewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ApiDataViewGrid.Location = new System.Drawing.Point(3, 16);
            this.ApiDataViewGrid.Name = "ApiDataViewGrid";
            this.ApiDataViewGrid.RowHeadersVisible = false;
            this.ApiDataViewGrid.Size = new System.Drawing.Size(287, 218);
            this.ApiDataViewGrid.TabIndex = 0;
            this.ApiDataViewGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ApiDataViewGrid_CellFormatting);
            // 
            // ApiEnabled
            // 
            this.ApiEnabled.DataPropertyName = "Enabled";
            this.ApiEnabled.HeaderText = "Enabled";
            this.ApiEnabled.Name = "ApiEnabled";
            this.ApiEnabled.Width = 52;
            // 
            // ApiFullName
            // 
            this.ApiFullName.DataPropertyName = "FullName";
            this.ApiFullName.HeaderText = "FullName";
            this.ApiFullName.Name = "ApiFullName";
            this.ApiFullName.ReadOnly = true;
            this.ApiFullName.Visible = false;
            this.ApiFullName.Width = 76;
            // 
            // ApiName
            // 
            this.ApiName.DataPropertyName = "Name";
            this.ApiName.HeaderText = "Name";
            this.ApiName.Name = "ApiName";
            this.ApiName.ReadOnly = true;
            this.ApiName.Width = 60;
            // 
            // ApiOverride
            // 
            this.ApiOverride.DataPropertyName = "Override";
            this.ApiOverride.HeaderText = "Override";
            this.ApiOverride.Name = "ApiOverride";
            this.ApiOverride.Width = 72;
            // 
            // ApiOverridable
            // 
            this.ApiOverridable.DataPropertyName = "IsOverridable";
            this.ApiOverridable.HeaderText = "Overridable";
            this.ApiOverridable.Name = "ApiOverridable";
            this.ApiOverridable.ReadOnly = true;
            this.ApiOverridable.Visible = false;
            this.ApiOverridable.Width = 67;
            // 
            // RandomContextMenuStrip
            // 
            this.RandomContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReconstructRandomSequenceToolStripMenuItem});
            this.RandomContextMenuStrip.Name = "RandomContextMenuStrip";
            this.RandomContextMenuStrip.Size = new System.Drawing.Size(240, 26);
            // 
            // ReconstructRandomSequenceToolStripMenuItem
            // 
            this.ReconstructRandomSequenceToolStripMenuItem.Name = "ReconstructRandomSequenceToolStripMenuItem";
            this.ReconstructRandomSequenceToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.ReconstructRandomSequenceToolStripMenuItem.Text = "Reconstruct Random Sequence";
            this.ReconstructRandomSequenceToolStripMenuItem.Click += new System.EventHandler(this.ReconstructRandomSequenceToolStripMenuItem_Click);
            // 
            // CallOrder
            // 
            this.CallOrder.DataPropertyName = "ID";
            this.CallOrder.HeaderText = "#";
            this.CallOrder.Name = "CallOrder";
            this.CallOrder.ReadOnly = true;
            this.CallOrder.Width = 39;
            // 
            // CallHash
            // 
            this.CallHash.DataPropertyName = "HashCode";
            this.CallHash.HeaderText = "Instance";
            this.CallHash.Name = "CallHash";
            this.CallHash.ReadOnly = true;
            this.CallHash.Width = 73;
            // 
            // CallTime
            // 
            this.CallTime.DataPropertyName = "TimeOFDay";
            this.CallTime.HeaderText = "Time";
            this.CallTime.Name = "CallTime";
            this.CallTime.ReadOnly = true;
            this.CallTime.Width = 55;
            // 
            // CallTicks
            // 
            this.CallTicks.DataPropertyName = "Ticks";
            this.CallTicks.HeaderText = "Ticks";
            this.CallTicks.Name = "CallTicks";
            this.CallTicks.ReadOnly = true;
            this.CallTicks.Width = 58;
            // 
            // CallModule
            // 
            this.CallModule.DataPropertyName = "ModuleFullName";
            this.CallModule.HeaderText = "Module";
            this.CallModule.Name = "CallModule";
            this.CallModule.ReadOnly = true;
            this.CallModule.Width = 67;
            // 
            // CallMethod
            // 
            this.CallMethod.DataPropertyName = "MethodPrototype";
            this.CallMethod.HeaderText = "Method";
            this.CallMethod.Name = "CallMethod";
            this.CallMethod.ReadOnly = true;
            this.CallMethod.Width = 68;
            // 
            // CallReturnValue
            // 
            this.CallReturnValue.DataPropertyName = "ReturnPrototype";
            this.CallReturnValue.HeaderText = "Return";
            this.CallReturnValue.Name = "CallReturnValue";
            this.CallReturnValue.ReadOnly = true;
            this.CallReturnValue.Width = 64;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 690);
            this.Controls.Add(this.ApiGroup);
            this.Controls.Add(this.HexGroupBox);
            this.Controls.Add(this.ParametersGroupBox);
            this.Controls.Add(this.CallsGroupBox);
            this.Controls.Add(this.MonitoredGroupBox);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.Text = "DotNetMonitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.MonitoredGroupBox.ResumeLayout(false);
            this.CallsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CallsDataGridView)).EndInit();
            this.ParametersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ParametersDataGridView)).EndInit();
            this.ApiGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ApiDataViewGrid)).EndInit();
            this.RandomContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem LoadFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.GroupBox MonitoredGroupBox;
        private System.Windows.Forms.TreeView MonitoredTreeView;
        private System.Windows.Forms.GroupBox CallsGroupBox;
        private System.Windows.Forms.GroupBox ParametersGroupBox;
        private System.Windows.Forms.DataGridView CallsDataGridView;
        private System.Windows.Forms.DataGridView ParametersDataGridView;
        private System.Windows.Forms.GroupBox HexGroupBox;
        private System.Windows.Forms.GroupBox ApiGroup;
        private System.Windows.Forms.DataGridView ApiDataViewGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ApiEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApiFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApiName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApiOverride;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ApiOverridable;
        private System.Windows.Forms.ContextMenuStrip RandomContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ReconstructRandomSequenceToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallHash;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallTicks;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallModule;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallReturnValue;
    }
}