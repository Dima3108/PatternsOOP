using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsMVC.Controller;

namespace WindowsFormsMVC
{
    public partial class Form1 : Form
        //Infrastructure.FabricForm
    {
        private MainController _controller = new MainController();
        internal Form1()//:base(_controllerInterface)
        {
            InitializeComponent();
            
          _controller.UpdateTableContent(this.dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.AddModel(this.dataGridView1);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
          
            //dataGridView1.SelectedColumns
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update model
            if (dataGridView1.SelectedRows.Count > 0)
            {
  _controller.UpdateModel(this.dataGridView1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                _controller.DeleteModel(this.dataGridView1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _controller.IncreaseOffset(this.dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _controller.ReduceOffset(this.dataGridView1);
        }
    }
}
