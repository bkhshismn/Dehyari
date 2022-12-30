using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dehyari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
        new frmLoadPerson().Show();

        }



        private void expandablePanel1_Click(object sender, EventArgs e)
        {

        }

        private void btnJaygahZamin_Click(object sender, EventArgs e)
        {
            new frmJaygahZamin().Show();
        }
    }
}
