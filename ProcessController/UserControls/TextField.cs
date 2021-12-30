using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessController.UserControls
{
    public partial class TextField : UserControl
    {
        

        public TextField()
        {
            InitializeComponent();
        }
        public TextBox TextBox
        {
            get => this.textBox1;
        }

        public Label LabelControl
        {
            get => this.label1;
        }

        [Description("Text displayed in the Label"), Category("Appearance")]
        public string Label
        {
            get => this.label1.Text;
            set => this.label1.Text = value;
        }

        [Description("Text displayed in the text box"), Category("Data")]
        public string Value
        {
            get => this.textBox1.Text;
            set => this.textBox1.Text = value;
        }

        [Description("Makes the text box read only"), Category("Behavior")]
        public bool ReadOnly
        {
            get => this.textBox1.ReadOnly;
            set => this.textBox1.ReadOnly = value;
        }
    }
}
