
namespace ProcessController.Views
{
    partial class AddProcess
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.monitorName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.processName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.restartOnCrash = new System.Windows.Forms.CheckBox();
            this.add = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cancel);
            this.groupBox1.Controls.Add(this.add);
            this.groupBox1.Controls.Add(this.restartOnCrash);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.processName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.monitorName);
            this.groupBox1.Location = new System.Drawing.Point(293, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 251);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Process Monitor";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // monitorName
            // 
            this.monitorName.Location = new System.Drawing.Point(6, 58);
            this.monitorName.Name = "monitorName";
            this.monitorName.Size = new System.Drawing.Size(188, 23);
            this.monitorName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Monitor Name";
            // 
            // processName
            // 
            this.processName.Location = new System.Drawing.Point(7, 112);
            this.processName.Name = "processName";
            this.processName.Size = new System.Drawing.Size(187, 23);
            this.processName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Process Name";
            // 
            // restartOnCrash
            // 
            this.restartOnCrash.AutoSize = true;
            this.restartOnCrash.Location = new System.Drawing.Point(7, 155);
            this.restartOnCrash.Name = "restartOnCrash";
            this.restartOnCrash.Size = new System.Drawing.Size(112, 19);
            this.restartOnCrash.TabIndex = 4;
            this.restartOnCrash.Text = "Restart on Crash";
            this.restartOnCrash.UseVisualStyleBackColor = true;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(7, 180);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(187, 23);
            this.add.TabIndex = 5;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.Add_click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(7, 210);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(187, 23);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.Cancel_click);
            // 
            // AddProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddProcess";
            this.Text = "AddProcess";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox monitorName;
        private System.Windows.Forms.TextBox processName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.CheckBox restartOnCrash;
        private System.Windows.Forms.Label label2;
    }
}