using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Dehyari
{
    public partial class frmJaygahZamin : Form
    {
        public frmJaygahZamin()
        {
            InitializeComponent();
        }
        int zaminID = -1;
        void DisplayZamin()
        {
            using (DehyariContext dbcontext = new DehyariContext())
            {
                var query = from z in dbcontext.JaygahZamins
                            select new
                            { 
                                z.JaygahZaminID,
                                z.JaygahZamin1,
                                z.NerkhAb
                            };
                dgvJaygahZamin.DataSource= query.ToList();
                dgvJaygahZamin.Columns["JaygahZaminID"].HeaderText = "کد جایگاه";
                dgvJaygahZamin.Columns["JaygahZaminID"].Width = 50;
                dgvJaygahZamin.Columns["JaygahZamin1"].HeaderText = "جایگاه";
                dgvJaygahZamin.Columns["JaygahZamin1"].Width= 150;
                dgvJaygahZamin.Columns["NerkhAb"].HeaderText = "نرخ آب بها";
            }

        }
        void AddJaygah()
        {
            using (DehyariContext dbcontext = new DehyariContext())
            {
                JaygahZamin j = new JaygahZamin();
                j.JaygahZamin1 = txtJaygah.Text;
                j.NerkhAb = Convert.ToInt64(txtAbbaha.Text.Replace(",", ""));
                dbcontext.JaygahZamins.Add(j);
                dbcontext.SaveChanges();
                DisplayZamin();
            }
        }
        void AssignToFields()
        {
            JaygahZamin jaygahZamin = new JaygahZamin();
            using (DehyariContext dbcontext = new DehyariContext())
            {
                jaygahZamin = dbcontext.JaygahZamins.Where(c => c.JaygahZaminID == zaminID).First();
                txtJaygah.Text = jaygahZamin.JaygahZamin1;
                txtAbbaha.Text = jaygahZamin.NerkhAb.ToString();
          
            }

        }
        void CleareTextBoxs()
        {
            txtAbbaha.Text = "";
            txtJaygah.Text = "";
            zaminID = -1;
        }
        void EditJaygah()
        {
            if (zaminID != -1)
            {
                using (DehyariContext dbcontext = new DehyariContext())
                {

                    JaygahZamin j = new JaygahZamin();
                    j = dbcontext.JaygahZamins.Where(c => c.JaygahZaminID == zaminID).First();
                    j.JaygahZamin1 = txtJaygah.Text;
                    j.NerkhAb = Convert.ToInt64(txtAbbaha.Text.Replace(",", ""));
                    dbcontext.SaveChanges();
                    CleareTextBoxs();
                    DisplayZamin();
                }
            }
         
        }
        void DeleteJaygah()
        {
            if (zaminID !=-1)
            {
                if (true)
                {
                    if (MessageBox.Show("آیا از حذف این رکورد مطمعن هستید؟", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        using (DehyariContext dbcontext = new DehyariContext())
                        {
                            JaygahZamin z = new JaygahZamin();
                            z = dbcontext.JaygahZamins.Where( p => p.JaygahZaminID.Equals(zaminID)).First();
                            dbcontext.JaygahZamins.Remove(z);
                            dbcontext.SaveChanges();
                            DisplayZamin();
                            CleareTextBoxs();
                        }
                    }
                }
            }
        }
        private void frmJaygahZamin_Load(object sender, EventArgs e)
        {
            DisplayZamin();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddJaygah();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditJaygah();
        }
        private void dgvJaygahZamin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvJaygahZamin.CurrentRow.Selected = true;
            zaminID = (int)dgvJaygahZamin.CurrentRow.Cells["JaygahZaminID"].Value;
            AssignToFields();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteJaygah();
        }
        private void dgvJaygahZamin_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string NRFormat = "###,###";
            dgvJaygahZamin.Columns["NerkhAb"].DefaultCellStyle.Format = NRFormat;
        }
    }
}
