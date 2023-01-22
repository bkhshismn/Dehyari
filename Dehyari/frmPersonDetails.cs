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
    public partial class frmPersonDetails : Form
    {
        public int PersonID { get; set; }
        int ZaminID = -1;
        public frmPersonDetails()
        {
            InitializeComponent();
        }
        void DispalyPerson()
        {
            DehyariContext dbcontext = new DehyariContext();
            var query = from r in dbcontext.People
                        join k in dbcontext.IsKhanedars on r.IsKhanedarID equals k.IsKhanedarID
                        join s in dbcontext.IsSarparastKhanevars on r.IsSarparastKhanevarID equals s.IsSarparastKhanevarID
                        join Sx in dbcontext.Sexes on r.SexID equals Sx.SexID
                        join b in dbcontext.Bimes on r.BimeID equals b.BimeID
                        join t in dbcontext.Tahsilatts on r.TahsilatID equals t.TahsilatID
                        join m in dbcontext.IsMarrieds on r.IsMarriedID equals m.IsMarriedID
                        where r.PersonID== PersonID
                        select new
                        {
                            r.PersonID,
                            fullname = r.Name + " " + r.Family,
                            r.NamePedar,
                            r.SexID,
                            Sx.Sex1,
                            r.ShomareShenasname,
                            r.TarikhTavalod,
                            r.CodeMelli,
                            Sarparast = s.YesNoField,
                            r.IsSarparastKhanevarID,
                            SahebKhane = k.YesNoField,
                            r.IsKhanedarID,
                            r.MetrajKhane,
                            r.Mobile,
                            r.TelSabet,
                            r.IsMarriedID,
                            m.Married,
                            r.CodePosti,
                            r.TahsilatID,
                            t.NoTahsilat,
                            r.BimeID,
                            b.NoBime
                        };
            var p = query.ToList();
            lblName.Text=p[0].fullname;
            lblNamePdar.Text = p[0].NamePedar;
            lblCodeMelli.Text = p[0].CodeMelli;
            lblTarikhTavalod.Text = p[0].TarikhTavalod;
            lblShomareShenasname.Text = p[0].ShomareShenasname;
            lblCodePosti.Text = p[0].CodePosti;
            lblTelSabet.Text = p[0].TelSabet;
            lblMobile.Text = p[0].Mobile;
            lblJensiat.Text = p[0].Sex1;
            lblTahsilat.Text = p[0].NoTahsilat;
            lblSahebKhane.Text = p[0].SahebKhane;
            lblMetraj.Text = p[0].MetrajKhane.ToString();
            lblSarparast.Text = p[0].Sarparast;
            lblTaahol.Text = p[0].Married;
            lblBime.Text = p[0].NoBime;
        }
        void SettxtAbbaha()
        {
            try
            {
                using (DehyariContext d = new DehyariContext())
                {

                    int JaygahzaminID = Convert.ToInt32(cmdJaygahZamin.SelectedValue);
                    var query = from j in d.JaygahZamins
                                where j.JaygahZaminID == JaygahzaminID
                                select new
                                {
                                    j.NerkhAb
                                };
                    var p = query.ToList();
                    txtAbbaha.Text = p[0].NerkhAb.ToString();

                }
            }
            catch (Exception)
            {              
            }        
        }
        void DisplayZamin()
        {
            using (DehyariContext d = new DehyariContext())
            {
                var query = from z in d.Zamins
                            join jz in d.JaygahZamins on z.JaygahZaminID equals jz.JaygahZaminID
                            join nz in d.NoZamins on z.NoZaminID equals nz.NoZaminID
                            select new
                            {
                                z.ZaminID,
                                z.Masahat,
                                nz.NoZamin1,
                                jz.JaygahZamin1,                                
                                jz.NerkhAb
                            };
                dgvZamin.DataSource = query.ToList();
                dgvZamin.Columns["Masahat"].HeaderText = "مساحت رمین";
                dgvZamin.Columns["Masahat"].Width = 150;
                dgvZamin.Columns["NoZamin1"].HeaderText = "نوع زمین";
                dgvZamin.Columns["NoZamin1"].Width = 150;
                dgvZamin.Columns["JaygahZamin1"].HeaderText = "جایگاه";
                dgvZamin.Columns["JaygahZamin1"].Width = 250;
                dgvZamin.Columns["NerkhAb"].HeaderText = "نرخ آب بها";
                dgvZamin.Columns["NerkhAb"].Width = 250;
                dgvZamin.Columns["ZaminID"].Visible=false;
            }

        }
        void AddZamin()
        {
            try
            {
                using (DehyariContext d = new DehyariContext())
                {
                    Zamin z = new Zamin();
                    z.Masahat = Convert.ToInt64(txtMasahat.Text.Replace(",", ""));
                    z.NoZaminID = Convert.ToInt32(cmdNoZamin.SelectedValue);
                    z.JaygahZaminID = Convert.ToInt32(cmdJaygahZamin.SelectedValue);
                    z.PersonID = PersonID;
                    d.Zamins.Add(z);
                    d.SaveChanges();
                    DisplayZamin();
                }
            }
            catch (Exception)
            {

            }
           
        }
        void EditZamin()
        {
            try
            {
                using (DehyariContext d = new DehyariContext())
                {
                    Zamin z = new Zamin();
                    z=d.Zamins.Where(x => x.ZaminID == ZaminID).First();
                    z.Masahat = Convert.ToInt64(txtMasahat.Text.Replace(",", ""));
                    z.NoZaminID = Convert.ToInt32(cmdNoZamin.SelectedValue);
                    z.JaygahZaminID = Convert.ToInt32(cmdJaygahZamin.SelectedValue);
                    d.SaveChanges();
                    DisplayZamin();
                    ZaminID = -1;
                }
            }
            catch (Exception)
            {

            }
        }
        void DeleteZamin()
        {
            if (ZaminID != -1)
            {
                if (true)
                {
                    if (MessageBox.Show("آیا از حذف این رکورد مطمعن هستید؟", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        using (DehyariContext d = new DehyariContext())
                        {
                            Zamin z = new Zamin();
                            z = d.Zamins.Where(x => x.ZaminID == ZaminID).First();
                            d.Zamins.Remove(z);
                            d.SaveChanges();
                            DisplayZamin();
                            ZaminID = -1;

                        }
                    }
                }
            }
        }
        void AssignToFields()
        {
           
            using (DehyariContext d = new   DehyariContext())
            {
                Zamin z = new Zamin();
                z = d.Zamins.Where(x=> x.ZaminID.Equals(ZaminID)).First();
                txtMasahat.Text=z.Masahat.ToString();
                cmdNoZamin.SelectedValue= z.NoZaminID;
                cmdJaygahZamin.SelectedValue = z.JaygahZaminID;
            }

        }
        void AddComboboxNoZamin()
        {
            using (DehyariContext d = new DehyariContext())
            {
                List<NoZamin> nozamin = d.NoZamins.ToList();
                cmdNoZamin.DataSource = nozamin;
                cmdNoZamin.ValueMember = "NoZaminID";
                cmdNoZamin.DisplayMember = "NoZamin1";
            }
        }
        void AddComboboxJaygahZamin()
        {
            using (DehyariContext d = new DehyariContext())
            {
                List<JaygahZamin> jayga= d.JaygahZamins.ToList();
                cmdJaygahZamin.DataSource = jayga;
                cmdJaygahZamin.ValueMember = "JaygahZaminID";
                cmdJaygahZamin.DisplayMember = "JaygahZamin1";
            }
        }
        private void frmPersonDetails_Load(object sender, EventArgs e)
        {        
            DispalyPerson();
            AddComboboxNoZamin();
            AddComboboxJaygahZamin();
            DisplayZamin();
        
        }

        private void cmdJaygahZamin_SelectedValueChanged(object sender, EventArgs e)
        {
            SettxtAbbaha();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddZamin();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditZamin();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteZamin();

        }   
        private void dgvZamin_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string NRFormat = "###,###";
            dgvZamin.Columns["Masahat"].DefaultCellStyle.Format = NRFormat;
            dgvZamin.Columns["NerkhAb"].DefaultCellStyle.Format = NRFormat;
        }
        private void dgvZamin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvZamin.CurrentRow.Selected = true;
            ZaminID = (int)dgvZamin.CurrentRow.Cells["ZaminID"].Value;
            AssignToFields();
        }
        private void txtAbbaha_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAbbaha.Text != string.Empty)
                {
                    txtAbbaha.Text = string.Format("{0:N0}", double.Parse(txtAbbaha.Text.Replace(",", "")));
                    txtAbbaha.Select(txtAbbaha.TextLength, 0);
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
    }
}
