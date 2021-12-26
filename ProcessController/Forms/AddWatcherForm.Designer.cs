
namespace ProcessController.Forms
{
    partial class AddWatcherForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.addWatcherGroupBox = new System.Windows.Forms.GroupBox();
            this.watcherNameBox = new System.Windows.Forms.TextBox();
            this.watcherNameLabel = new System.Windows.Forms.Label();
            this.processNameLabel = new System.Windows.Forms.Label();
            this.processNameBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.addWatcherGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addWatcherGroupBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // addWatcherGroupBox
            // 
            this.addWatcherGroupBox.Controls.Add(this.Cancel);
            this.addWatcherGroupBox.Controls.Add(this.addButton);
            this.addWatcherGroupBox.Controls.Add(this.processNameBox);
            this.addWatcherGroupBox.Controls.Add(this.processNameLabel);
            this.addWatcherGroupBox.Controls.Add(this.watcherNameLabel);
            this.addWatcherGroupBox.Controls.Add(this.watcherNameBox);
            this.addWatcherGroupBox.Location = new System.Drawing.Point(296, 140);
            this.addWatcherGroupBox.Name = "addWatcherGroupBox";
            this.addWatcherGroupBox.Size = new System.Drawing.Size(200, 203);
            this.addWatcherGroupBox.TabIndex = 0;
            this.addWatcherGroupBox.TabStop = false;
            this.addWatcherGroupBox.Text = "Add Watcher";
            this.addWatcherGroupBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // watcherNameBox
            // 
            this.watcherNameBox.Location = new System.Drawing.Point(6, 45);
            this.watcherNameBox.Name = "watcherNameBox";
            this.watcherNameBox.Size = new System.Drawing.Size(187, 23);
            this.watcherNameBox.TabIndex = 0;
            // 
            // watcherNameLabel
            // 
            this.watcherNameLabel.AutoSize = true;
            this.watcherNameLabel.Location = new System.Drawing.Point(7, 23);
            this.watcherNameLabel.Name = "watcherNameLabel";
            this.watcherNameLabel.Size = new System.Drawing.Size(86, 15);
            this.watcherNameLabel.TabIndex = 1;
            this.watcherNameLabel.Text = "Watcher Name";
            // 
            // processNameLabel
            // 
            this.processNameLabel.AutoSize = true;
            this.processNameLabel.Location = new System.Drawing.Point(7, 75);
            this.processNameLabel.Name = "processNameLabel";
            this.processNameLabel.Size = new System.Drawing.Size(82, 15);
            this.processNameLabel.TabIndex = 2;
            this.processNameLabel.Text = "Process Name";
            // 
            // processNameBox
            // 
            this.processNameBox.Location = new System.Drawing.Point(7, 94);
            this.processNameBox.Name = "processNameBox";
            this.processNameBox.Size = new System.Drawing.Size(186, 23);
            this.processNameBox.TabIndex = 3;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(118, 170);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddBtn_Click);
            
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(7, 170);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.CancelBtn_Click);

            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddWatcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "AddWatcherForm";
            this.Text = "AddWatcherForm";
            this.panel1.ResumeLayout(false);
            this.addWatcherGroupBox.ResumeLayout(false);
            this.addWatcherGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox addWatcherGroupBox;
        private System.Windows.Forms.TextBox watcherNameBox;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox processNameBox;
        private System.Windows.Forms.Label processNameLabel;
        private System.Windows.Forms.Label watcherNameLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}