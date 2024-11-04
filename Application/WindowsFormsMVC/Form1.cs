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
    {
        private Infrastructure.SmallOutleetControllerInterface _controller = new MainController();
        public Form1()
        {
            InitializeComponent();
            _controller.UpdateTableContent(this.dataGridView1);
        }
    }
}
