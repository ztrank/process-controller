
namespace ProcessController
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AddProcessButton = new System.Windows.Forms.Button();
            this.ProcessMonitorGrid = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.propertyHeader = new System.Windows.Forms.ColumnHeader();
            this.valueHeader = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.removeProcess = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessMonitorGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.94044F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.05956F));
            this.tableLayoutPanel1.Controls.Add(this.ProcessMonitorGrid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.04575F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.95425F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1041, 614);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // AddProcessButton
            // 
            this.AddProcessButton.Location = new System.Drawing.Point(3, 3);
            this.AddProcessButton.Name = "AddProcessButton";
            this.AddProcessButton.Size = new System.Drawing.Size(177, 23);
            this.AddProcessButton.TabIndex = 0;
            this.AddProcessButton.Text = "Add Process";
            this.AddProcessButton.UseVisualStyleBackColor = true;
            this.AddProcessButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ProcessMonitorGrid
            // 
            this.ProcessMonitorGrid.AllowUserToAddRows = false;
            this.ProcessMonitorGrid.AllowUserToDeleteRows = false;
            this.ProcessMonitorGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcessMonitorGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessMonitorGrid.Location = new System.Drawing.Point(3, 3);
            this.ProcessMonitorGrid.Name = "ProcessMonitorGrid";
            this.ProcessMonitorGrid.ReadOnly = true;
            this.ProcessMonitorGrid.RowTemplate.Height = 25;
            this.ProcessMonitorGrid.Size = new System.Drawing.Size(846, 338);
            this.ProcessMonitorGrid.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 347);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(846, 264);
            this.splitContainer1.SplitterDistance = 281;
            this.splitContainer1.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.propertyHeader,
            this.valueHeader});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(561, 264);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // propertyHeader
            // 
            this.propertyHeader.Text = "Property";
            // 
            // valueHeader
            // 
            this.valueHeader.Text = "Value";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.removeProcess);
            this.panel1.Controls.Add(this.AddProcessButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(855, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 338);
            this.panel1.TabIndex = 3;
            // 
            // removeProcess
            // 
            this.removeProcess.Location = new System.Drawing.Point(3, 32);
            this.removeProcess.Name = "removeProcess";
            this.removeProcess.Size = new System.Drawing.Size(177, 23);
            this.removeProcess.TabIndex = 1;
            this.removeProcess.Text = "Remove Process";
            this.removeProcess.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 631);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProcessMonitorGrid)).EndInit();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button AddProcessButton;
        private System.Windows.Forms.DataGridView ProcessMonitorGrid;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader propertyHeader;
        private System.Windows.Forms.ColumnHeader valueHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button removeProcess;
    }
}

