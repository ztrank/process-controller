
namespace ProcessController.Views
{
    partial class ProcessWatcherSidebarView
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.addBtn = new System.Windows.Forms.Button();
            this.processWatcherGridView = new System.Windows.Forms.DataGridView();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processWatcherGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.addBtn);
            this.mainPanel.Controls.Add(this.processWatcherGridView);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(150, 350);
            this.mainPanel.TabIndex = 0;
            // 
            // addBtn
            // 
            this.addBtn.AutoSize = true;
            this.addBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.addBtn.Location = new System.Drawing.Point(0, 323);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(150, 23);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "New";
            this.addBtn.UseVisualStyleBackColor = true;
            // 
            // processWatcherGridView
            // 
            this.processWatcherGridView.AllowUserToAddRows = false;
            this.processWatcherGridView.AllowUserToDeleteRows = false;
            this.processWatcherGridView.AllowUserToResizeRows = false;
            this.processWatcherGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.processWatcherGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.processWatcherGridView.Location = new System.Drawing.Point(0, 0);
            this.processWatcherGridView.MinimumSize = new System.Drawing.Size(0, 300);
            this.processWatcherGridView.MultiSelect = false;
            this.processWatcherGridView.Name = "processWatcherGridView";
            this.processWatcherGridView.RowHeadersVisible = false;
            this.processWatcherGridView.RowTemplate.Height = 25;
            this.processWatcherGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.processWatcherGridView.Size = new System.Drawing.Size(150, 323);
            this.processWatcherGridView.TabIndex = 0;
            // 
            // ProcessWatcherSidebarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(150, 350);
            this.Name = "ProcessWatcherSidebarView";
            this.Size = new System.Drawing.Size(150, 350);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processWatcherGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.DataGridView processWatcherGridView;
        private System.Windows.Forms.Button addBtn;
    }
}
