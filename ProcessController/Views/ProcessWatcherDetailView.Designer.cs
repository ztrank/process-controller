
namespace ProcessController.Views
{
    partial class ProcessWatcherDetailView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameField = new ProcessController.UserControls.TextField();
            this.processNameField = new ProcessController.UserControls.TextField();
            this.targetCountField = new ProcessController.UserControls.NumberField();
            this.processCountField = new ProcessController.UserControls.NumberField();
            this.descriptionField = new ProcessController.UserControls.TextField();
            this.fieldsPanel1 = new System.Windows.Forms.Panel();
            this.countPanel = new System.Windows.Forms.Panel();
            this.namePanel = new System.Windows.Forms.Panel();
            this.fieldsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCtrlPanel = new System.Windows.Forms.Panel();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.undoBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.processViewerPanel = new System.Windows.Forms.Panel();
            this.processListView = new System.Windows.Forms.ListView();
            this.PID = new System.Windows.Forms.ColumnHeader();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.startTime = new System.Windows.Forms.ColumnHeader();
            this.exitTime = new System.Windows.Forms.ColumnHeader();
            this.exitCode = new System.Windows.Forms.ColumnHeader();
            this.responding = new System.Windows.Forms.ColumnHeader();
            this.fieldsPanel1.SuspendLayout();
            this.countPanel.SuspendLayout();
            this.namePanel.SuspendLayout();
            this.fieldsFlowPanel.SuspendLayout();
            this.btnCtrlPanel.SuspendLayout();
            this.processViewerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameField
            // 
            this.nameField.AutoSize = true;
            this.nameField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nameField.Dock = System.Windows.Forms.DockStyle.Left;
            this.nameField.Label = "Name";
            this.nameField.Location = new System.Drawing.Point(0, 0);
            this.nameField.MaximumSize = new System.Drawing.Size(0, 48);
            this.nameField.MinimumSize = new System.Drawing.Size(200, 48);
            this.nameField.Name = "nameField";
            this.nameField.Padding = new System.Windows.Forms.Padding(5);
            this.nameField.ReadOnly = false;
            this.nameField.Size = new System.Drawing.Size(200, 48);
            this.nameField.TabIndex = 0;
            this.nameField.Value = "";
            // 
            // processNameField
            // 
            this.processNameField.AutoSize = true;
            this.processNameField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.processNameField.Dock = System.Windows.Forms.DockStyle.Right;
            this.processNameField.Label = "Process Name";
            this.processNameField.Location = new System.Drawing.Point(250, 0);
            this.processNameField.MaximumSize = new System.Drawing.Size(0, 48);
            this.processNameField.MinimumSize = new System.Drawing.Size(200, 48);
            this.processNameField.Name = "processNameField";
            this.processNameField.Padding = new System.Windows.Forms.Padding(5);
            this.processNameField.ReadOnly = false;
            this.processNameField.Size = new System.Drawing.Size(200, 48);
            this.processNameField.TabIndex = 1;
            this.processNameField.Value = "";
            // 
            // targetCountField
            // 
            this.targetCountField.DecimalPlaces = 0;
            this.targetCountField.Dock = System.Windows.Forms.DockStyle.Left;
            this.targetCountField.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.targetCountField.Label = "Target Count";
            this.targetCountField.Location = new System.Drawing.Point(0, 0);
            this.targetCountField.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.targetCountField.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.targetCountField.Name = "targetCountField";
            this.targetCountField.Padding = new System.Windows.Forms.Padding(5);
            this.targetCountField.ReadOnly = false;
            this.targetCountField.Size = new System.Drawing.Size(200, 54);
            this.targetCountField.TabIndex = 2;
            this.targetCountField.ThousandsSeparator = false;
            this.targetCountField.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // processCountField
            // 
            this.processCountField.DecimalPlaces = 0;
            this.processCountField.Dock = System.Windows.Forms.DockStyle.Right;
            this.processCountField.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.processCountField.Label = "Running Processes";
            this.processCountField.Location = new System.Drawing.Point(250, 0);
            this.processCountField.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.processCountField.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.processCountField.Name = "processCountField";
            this.processCountField.Padding = new System.Windows.Forms.Padding(5);
            this.processCountField.ReadOnly = true;
            this.processCountField.Size = new System.Drawing.Size(200, 54);
            this.processCountField.TabIndex = 4;
            this.processCountField.ThousandsSeparator = false;
            this.processCountField.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // descriptionField
            // 
            this.descriptionField.AutoSize = true;
            this.descriptionField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.descriptionField.Label = "Description";
            this.descriptionField.Location = new System.Drawing.Point(3, 115);
            this.descriptionField.MinimumSize = new System.Drawing.Size(450, 48);
            this.descriptionField.Name = "descriptionField";
            this.descriptionField.Padding = new System.Windows.Forms.Padding(5);
            this.descriptionField.ReadOnly = false;
            this.descriptionField.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.descriptionField.Size = new System.Drawing.Size(450, 48);
            this.descriptionField.TabIndex = 3;
            this.descriptionField.Value = "";
            // 
            // fieldsPanel1
            // 
            this.fieldsPanel1.Controls.Add(this.countPanel);
            this.fieldsPanel1.Controls.Add(this.namePanel);
            this.fieldsPanel1.Location = new System.Drawing.Point(3, 3);
            this.fieldsPanel1.Name = "fieldsPanel1";
            this.fieldsPanel1.Size = new System.Drawing.Size(450, 106);
            this.fieldsPanel1.TabIndex = 1;
            // 
            // countPanel
            // 
            this.countPanel.Controls.Add(this.processCountField);
            this.countPanel.Controls.Add(this.targetCountField);
            this.countPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.countPanel.Location = new System.Drawing.Point(0, 54);
            this.countPanel.Name = "countPanel";
            this.countPanel.Size = new System.Drawing.Size(450, 54);
            this.countPanel.TabIndex = 3;
            // 
            // namePanel
            // 
            this.namePanel.Controls.Add(this.processNameField);
            this.namePanel.Controls.Add(this.nameField);
            this.namePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.namePanel.Location = new System.Drawing.Point(0, 0);
            this.namePanel.Name = "namePanel";
            this.namePanel.Size = new System.Drawing.Size(450, 54);
            this.namePanel.TabIndex = 2;
            // 
            // fieldsFlowPanel
            // 
            this.fieldsFlowPanel.AutoSize = true;
            this.fieldsFlowPanel.Controls.Add(this.fieldsPanel1);
            this.fieldsFlowPanel.Controls.Add(this.descriptionField);
            this.fieldsFlowPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fieldsFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.fieldsFlowPanel.Name = "fieldsFlowPanel";
            this.fieldsFlowPanel.Size = new System.Drawing.Size(655, 166);
            this.fieldsFlowPanel.TabIndex = 4;
            // 
            // btnCtrlPanel
            // 
            this.btnCtrlPanel.Controls.Add(this.deleteBtn);
            this.btnCtrlPanel.Controls.Add(this.undoBtn);
            this.btnCtrlPanel.Controls.Add(this.saveBtn);
            this.btnCtrlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCtrlPanel.Location = new System.Drawing.Point(0, 166);
            this.btnCtrlPanel.Name = "btnCtrlPanel";
            this.btnCtrlPanel.Size = new System.Drawing.Size(655, 55);
            this.btnCtrlPanel.TabIndex = 5;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(84, 19);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 2;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // undoBtn
            // 
            this.undoBtn.Enabled = false;
            this.undoBtn.Location = new System.Drawing.Point(3, 19);
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(75, 23);
            this.undoBtn.TabIndex = 1;
            this.undoBtn.Text = "Undo";
            this.undoBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(378, 19);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            // 
            // processViewerPanel
            // 
            this.processViewerPanel.Controls.Add(this.processListView);
            this.processViewerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.processViewerPanel.Location = new System.Drawing.Point(0, 221);
            this.processViewerPanel.Name = "processViewerPanel";
            this.processViewerPanel.Size = new System.Drawing.Size(655, 107);
            this.processViewerPanel.TabIndex = 6;
            // 
            // processListView
            // 
            this.processListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PID,
            this.Status,
            this.startTime,
            this.exitTime,
            this.exitCode,
            this.responding});
            this.processListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processListView.FullRowSelect = true;
            this.processListView.GridLines = true;
            this.processListView.HideSelection = false;
            this.processListView.Location = new System.Drawing.Point(0, 0);
            this.processListView.Name = "processListView";
            this.processListView.Size = new System.Drawing.Size(655, 107);
            this.processListView.TabIndex = 0;
            this.processListView.UseCompatibleStateImageBehavior = false;
            this.processListView.View = System.Windows.Forms.View.Details;
            // 
            // PID
            // 
            this.PID.Text = "PID";
            // 
            // Status
            // 
            this.Status.Text = "Status";
            // 
            // startTime
            // 
            this.startTime.Text = "Start Time";
            this.startTime.Width = 150;
            // 
            // exitTime
            // 
            this.exitTime.Text = "Exit Time";
            this.exitTime.Width = 150;
            // 
            // exitCode
            // 
            this.exitCode.Text = "Exit Code";
            this.exitCode.Width = 80;
            // 
            // responding
            // 
            this.responding.Text = "Responding";
            this.responding.Width = 100;
            // 
            // ProcessWatcherDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.processViewerPanel);
            this.Controls.Add(this.btnCtrlPanel);
            this.Controls.Add(this.fieldsFlowPanel);
            this.Name = "ProcessWatcherDetailView";
            this.Size = new System.Drawing.Size(655, 448);
            this.fieldsPanel1.ResumeLayout(false);
            this.countPanel.ResumeLayout(false);
            this.namePanel.ResumeLayout(false);
            this.namePanel.PerformLayout();
            this.fieldsFlowPanel.ResumeLayout(false);
            this.fieldsFlowPanel.PerformLayout();
            this.btnCtrlPanel.ResumeLayout(false);
            this.processViewerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UserControls.TextField nameField;
        private UserControls.TextField processNameField;
        private UserControls.NumberField targetCountField;
        private UserControls.TextField descriptionField;
        private UserControls.NumberField processCountField;
        private System.Windows.Forms.Panel fieldsPanel1;
        private System.Windows.Forms.Panel countPanel;
        private System.Windows.Forms.Panel namePanel;
        private System.Windows.Forms.FlowLayoutPanel fieldsFlowPanel;
        private System.Windows.Forms.Panel btnCtrlPanel;
        private System.Windows.Forms.Button undoBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Panel processViewerPanel;
        private System.Windows.Forms.ListView processListView;
        private System.Windows.Forms.ColumnHeader PID;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader startTime;
        private System.Windows.Forms.ColumnHeader exitTime;
        private System.Windows.Forms.ColumnHeader exitCode;
        private System.Windows.Forms.ColumnHeader responding;
        private System.Windows.Forms.Button deleteBtn;
    }
}
