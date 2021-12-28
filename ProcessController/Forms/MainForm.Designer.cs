
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
            this.watcherList1 = new ProcessController.Views.WatcherList();
            this.logViewer1 = new ProcessController.Views.LogViewer();
            this.SuspendLayout();
            // 
            // watcherList1
            // 
            this.watcherList1.AutoSize = true;
            this.watcherList1.Dock = System.Windows.Forms.DockStyle.Left;
            this.watcherList1.Location = new System.Drawing.Point(0, 0);
            this.watcherList1.MaximumSize = new System.Drawing.Size(300, 0);
            this.watcherList1.MinimumSize = new System.Drawing.Size(150, 400);
            this.watcherList1.Name = "watcherList1";
            this.watcherList1.Padding = new System.Windows.Forms.Padding(3);
            this.watcherList1.Size = new System.Drawing.Size(150, 545);
            this.watcherList1.TabIndex = 0;
            // 
            // logViewer1
            // 
            this.logViewer1.AutoSize = true;
            this.logViewer1.Location = new System.Drawing.Point(156, 445);
            this.logViewer1.MinimumSize = new System.Drawing.Size(600, 100);
            this.logViewer1.Name = "logViewer1";
            this.logViewer1.Size = new System.Drawing.Size(779, 100);
            this.logViewer1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 545);
            this.Controls.Add(this.logViewer1);
            this.Controls.Add(this.watcherList1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Views.WatcherList watcherList1;
        private Views.LogViewer logViewer1;
    }
}