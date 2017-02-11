using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeFun
{
    public partial class Form1 : Form
    {
        public int x, y;
        public Form1()
        {
            InitializeComponent();
            GenerateButton.Click += GenerateButton_Click;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            MazePower TestPower = new MazePower();
            var test = TestPower.makeMazeTiles(Convert.ToInt32(WidthValue.Value), Convert.ToInt32(HeightValue.Value));
            GenerateButton.Text = "finished";
        }
    }
}
