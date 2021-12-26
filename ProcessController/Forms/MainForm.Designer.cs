
namespace ProcessController.Forms
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
                this.watcherDataGridController.Dispose();
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.WatcherDataGridView = new System.Windows.Forms.DataGridView();
            this.WatcherControlPanel = new System.Windows.Forms.Panel();
            this.RemoveWatcher = new System.Windows.Forms.Button();
            this.AddWatcher = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WatcherDataGridView)).BeginInit();
            this.WatcherControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Size = new System.Drawing.Size(1039, 590);
            this.splitContainer1.SplitterDistance = 348;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.WatcherDataGridView);
            this.splitContainer2.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(15);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.WatcherControlPanel);
            this.splitContainer2.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(15);
            this.splitContainer2.Panel2MinSize = 100;
            this.splitContainer2.Size = new System.Drawing.Size(1039, 348);
            this.splitContainer2.SplitterDistance = 817;
            this.splitContainer2.TabIndex = 0;
            // 
            // WatcherDataGridView
            // 
            this.WatcherDataGridView.AllowUserToAddRows = false;
            this.WatcherDataGridView.AllowUserToDeleteRows = false;
            this.WatcherDataGridView.AllowUserToResizeRows = false;
            this.WatcherDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WatcherDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WatcherDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.WatcherDataGridView.Location = new System.Drawing.Point(15, 15);
            this.WatcherDataGridView.MultiSelect = false;
            this.WatcherDataGridView.Name = "WatcherDataGridView";
            this.WatcherDataGridView.RowTemplate.Height = 25;
            this.WatcherDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WatcherDataGridView.Size = new System.Drawing.Size(787, 318);
            this.WatcherDataGridView.TabIndex = 0;
            // 
            // WatcherControlPanel
            // 
            this.WatcherControlPanel.Controls.Add(this.RemoveWatcher);
            this.WatcherControlPanel.Controls.Add(this.AddWatcher);
            this.WatcherControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WatcherControlPanel.Location = new System.Drawing.Point(15, 15);
            this.WatcherControlPanel.Name = "WatcherControlPanel";
            this.WatcherControlPanel.Size = new System.Drawing.Size(188, 318);
            this.WatcherControlPanel.TabIndex = 0;
            // 
            // RemoveWatcher
            // 
            this.RemoveWatcher.Dock = System.Windows.Forms.DockStyle.Top;
            this.RemoveWatcher.Location = new System.Drawing.Point(0, 23);
            this.RemoveWatcher.Name = "RemoveWatcher";
            this.RemoveWatcher.Size = new System.Drawing.Size(188, 23);
            this.RemoveWatcher.TabIndex = 1;
            this.RemoveWatcher.Text = "Remove Watcher";
            this.RemoveWatcher.UseVisualStyleBackColor = true;
            // 
            // AddWatcher
            // 
            this.AddWatcher.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddWatcher.Location = new System.Drawing.Point(0, 0);
            this.AddWatcher.Name = "AddWatcher";
            this.AddWatcher.Size = new System.Drawing.Size(188, 23);
            this.AddWatcher.TabIndex = 0;
            this.AddWatcher.Text = "Add Watcher";
            this.AddWatcher.UseVisualStyleBackColor = true;
            this.AddWatcher.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 590);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process Controller";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WatcherDataGridView)).EndInit();
            this.WatcherControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView WatcherDataGridView;
        private System.Windows.Forms.Panel WatcherControlPanel;
        private System.Windows.Forms.Button RemoveWatcher;
        private System.Windows.Forms.Button AddWatcher;
    }
}