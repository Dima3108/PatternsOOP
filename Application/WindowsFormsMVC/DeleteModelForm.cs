using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMVC
{
    public partial class DeleteModelForm : Form
    {
        private Controller.DeleteOutleetModelController _controller;
        public DeleteModelForm(Controller.DeleteOutleetModelController controller)
        {
            InitializeComponent();
            _controller = controller;
            _controller.SetModel(labelID, labelInventoryNumber, labelStorey);
        }

        private void buttonDelOk_Click(object sender, EventArgs e)
        {
            _controller.DeleteModel(this);
        }

        private void buttonDelCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
