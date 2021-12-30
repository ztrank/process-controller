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
    public partial class NumberField : UserControl
    {
        public NumberField()
        {
            InitializeComponent();
        }

        public NumericUpDown NumberBox
        {
            get => this.numericUpDown1;
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

        [Description("Value displayed in the number box"), Category("Data")]
        public decimal Value
        {
            get => this.numericUpDown1.Value;
            set => this.numericUpDown1.Value = value;
        }

        [Description("Makes the number box read only"), Category("Behavior")]
        public bool ReadOnly
        {
            get => this.numericUpDown1.ReadOnly;
            set => this.numericUpDown1.ReadOnly = value;
        }

        [Description("The maximum value allowed"), Category("Data")]
        public decimal Maximum
        {
            get => this.numericUpDown1.Maximum; 
            set => this.numericUpDown1.Maximum = value;
        }

        [Description("The minimum value allowed"), Category("Data")]
        public decimal Minimum
        {
            get => this.numericUpDown1.Minimum; 
            set => this.numericUpDown1.Minimum = value;
        }

        [Description("The amount to increment"), Category("Data")]
        public decimal Increment
        {
            get => this.numericUpDown1.Increment;
            set => this.numericUpDown1.Increment = value;
        }

        [Description("The decimal places allowed"), Category("Data")]
        public int DecimalPlaces
        {
            get => this.numericUpDown1.DecimalPlaces;
            set => this.numericUpDown1.DecimalPlaces = value;
        }

        [Description("Indicates whether the thousands separater is visible"), Category("Data")]
        public bool ThousandsSeparator
        {
            get => this.numericUpDown1.ThousandsSeparator;
            set => this.numericUpDown1.ThousandsSeparator = value;
        }
    }
}
