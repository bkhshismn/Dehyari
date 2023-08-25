using DevComponents.DotNetBar;
using PARSGREEN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dehyari
{
    public partial class frmPersonDetails : Form
    {
        const string Signature = "7F63B9BC-38B3-4A28-B21A-5023A957F89B";
        const Int64 ParsgreenSendingPhoneNumber =10004004040;
        public int PersonID { get; set; }
        int ZaminID = -1;
        int HesabID = -1;
        int sexID = -1;
        Date changedate = new Date();
        Accounting Acounting = new Accounting();
        public frmPersonDetails()
        {
            InitializeComponent();
        }
        void DisplayPerson()
        {
            DehyariContext dbcontext = new DehyariContext();
            var query = from r in dbcontext.People
                        join k in dbcontext.IsKhanedars on r.IsKhanedarID equals k.IsKhanedarID
                        join s in dbcontext.IsSarparastKhanevars on r.IsSarparastKhanevarID equals s.IsSarparastKhanevarID
                        join Sx in dbcontext.Sexes on r.SexID equals Sx.SexID
                        join b in dbcontext.Bimes on r.BimeID equals b.BimeID
                        join t in dbcontext.Tahsilatts on r.TahsilatID equals t.TahsilatID
                        join m in dbcontext.IsMarrieds on r.IsMarriedID equals m.IsMarriedID
                        where r.PersonID == PersonID
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
            lblName.Text = p[0].fullname;
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
            sexID = (int)p[0].SexID;
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
                            where(z.PersonID == PersonID)
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
                dgvZamin.Columns["ZaminID"].Visible = false;
            }

        }
        void AddZamin()
        {
            try
            {
                using (DehyariContext d = new DehyariContext())
                {
                    Zamin z = new Zamin();
                    if (txtMasahat.Text == string.Empty)
                    {
                        MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
                    }
                    z.Masahat = Convert.ToInt64(txtMasahat.Text.Replace(",", ""));
                    z.NoZaminID = Convert.ToInt32(cmdNoZamin.SelectedValue);
                    z.JaygahZaminID = Convert.ToInt32(cmdJaygahZamin.SelectedValue);
                    z.PersonID = PersonID;
                    d.Zamins.Add(z);
                    d.SaveChanges();
                    DisplayZamin();
                    txtMasahat.Text = string.Empty;
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
                    z = d.Zamins.Where(x => x.ZaminID == ZaminID).First();
                    z.Masahat = Convert.ToInt64(txtMasahat.Text.Replace(",", ""));
                    z.NoZaminID = Convert.ToInt32(cmdNoZamin.SelectedValue);
                    z.JaygahZaminID = Convert.ToInt32(cmdJaygahZamin.SelectedValue);
                    d.SaveChanges();
                    DisplayZamin();
                    ZaminID = -1;
                    txtMasahat.Text = string.Empty;
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
                            txtMasahat.Text = string.Empty;
                        }
                    }
                }
            }
        }
        void AssignToTabZaminTextBoxs()
        {

            using (DehyariContext d = new DehyariContext())
            {
                Zamin z = new Zamin();
                z = d.Zamins.Where(x => x.ZaminID.Equals(ZaminID)).First();
                txtMasahat.Text = z.Masahat.ToString();
                cmdNoZamin.SelectedValue = z.NoZaminID;
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
                List<JaygahZamin> jayga = d.JaygahZamins.ToList();
                cmdJaygahZamin.DataSource = jayga;
                cmdJaygahZamin.ValueMember = "JaygahZaminID";
                cmdJaygahZamin.DisplayMember = "JaygahZamin1";
            }
        }
        void AddComboboxNoBed()
        {
            using (DehyariContext d = new DehyariContext())
            {
                List<BedNo> bedno = d.BedNoes.ToList();
                cmbBedNo.DataSource = bedno;
                cmbBedNo.ValueMember = "BedNoID";
                cmbBedNo.DisplayMember = "BedNo1";

                cmbBesNo.DataSource = bedno;
                cmbBesNo.ValueMember = "BedNoID";
                cmbBesNo.DisplayMember = "BedNo1";
            }
        }
        void DisplayBed()
        {
            try
            {
                using (DehyariContext dbContext = new DehyariContext())
                {
                    var query = from BedHesab in dbContext.PersonHesabs
                                where BedHesab.PersonID == PersonID && BedHesab.Bes == null
                                select new
                                {
                                    BedHesab.HesabID,
                                    BedHesab.PersonID,
                                    BedHesab.Bed,
                                    BedHesab.Date,
                                    BedHesab.Sayer
                                };
                    dgvBed.DataSource = query.ToList();               
                }
            }
            catch (Exception)
            {


            }

        }
        private int FindTheFinalIndex()
        {
            int hesabId = 0;
            using (DehyariContext dbContext = new DehyariContext())
            {
                var hesab= dbContext.PersonHesabs.OrderByDescending(p => p.HesabID).FirstOrDefault();
                hesabId=hesab.HesabID;
            }
                return hesabId;
        }
        void EmptyTextBoxOfTabBed()
        {
            txtSayer.Text = string.Empty;
            txtBed.Text = string.Empty;
        }
        void AddBedToPersonHesabTable()
        {
            using (DehyariContext dbContext = new DehyariContext())
            {
                PersonHesab BedHesab = new PersonHesab();
                BedHesab.PersonID = PersonID;
                BedHesab.Bed = Convert.ToInt64(txtBed.Text.Replace(",", ""));
                BedHesab.Date =changedate.Changedate(cmbBedDate.Text);;
                BedHesab.BedNoID = Convert.ToInt32(cmbBedNo.SelectedValue);

                if (txtSayer.Enabled)
                {
                    if (txtSayer.Text == string.Empty)
                    {
                        MessageBox.Show("لطفا فیلد عنوان بدهی را وارد نمایید");
                    }
                    else
                    {
                        BedHesab.Sayer = txtSayer.Text;
                    }
                }
                else
                {
                    BedHesab.Sayer = null;
                }
                dbContext.PersonHesabs.Add(BedHesab);
                dbContext.SaveChanges();
                AddBeSToDehyariHesabTable();
                DisplayBed();
                EmptyTextBoxOfTabBed();
            }
        }
        void AddBeSToDehyariHesabTable()
        {
            int PersonHesabID = FindTheFinalIndex();
            using (DehyariContext dbContext = new DehyariContext())
            {
                DehyariHesab BesHesab = new DehyariHesab();
                BesHesab.PersonHesabID = PersonHesabID;
                BesHesab.Bes = Convert.ToInt64(txtBed.Text.Replace(",", ""));
                BesHesab.Date =changedate.Changedate(cmbBedDate.Text);;
               // BesHesab.Date = cmbBedDate.Value.Year.ToString() + "/" + cmbBedDate.Value.Month.ToString("0#") + "/" + cmbBedDate.Value.Day.ToString();
                dbContext.DehyariHesabs.Add(BesHesab);
                dbContext.SaveChanges();
                DisplayBed();
                EmptyTextBoxOfTabBed();
            }
        }
        void EditBedToPersonHesabTable()
        {
            using (DehyariContext dbContext = new DehyariContext())
            {
                PersonHesab BedHesab = new PersonHesab();
                BedHesab = dbContext.PersonHesabs.Where(p => p.HesabID == HesabID).First();
                BedHesab.Bed = Convert.ToInt64(txtBed.Text.Replace(",", ""));
               // BedHesab.Date = cmbBedDate.Value.Year.ToString() + "/" + cmbBedDate.Value.Month.ToString("0#") + "/" + cmbBedDate.Value.Day.ToString();
                BedHesab.BedNoID = Convert.ToInt32(cmbBedNo.SelectedValue);
                if (txtSayer.Enabled)
                {
                    if (txtSayer.Text == string.Empty)
                    {
                        MessageBox.Show("لطفا فیلد عنوان بدهی را وارد نمایید");
                    }
                    else
                    {
                        BedHesab.Sayer = txtSayer.Text;
                    }

                }
                else
                {
                    BedHesab.Sayer = null;
                }

                dbContext.SaveChanges();
                EditBesToDehyariHesabTable();
                HesabID = -1;
                DisplayBed();              
                EmptyTextBoxOfTabBed();
            }
        }
        void EditBesToDehyariHesabTable()
        {
            using (DehyariContext dbContext  = new DehyariContext())
            {
                DehyariHesab dehyariHesab = new DehyariHesab();
                dehyariHesab = dbContext.DehyariHesabs.Where( p => p.PersonHesabID== HesabID ).FirstOrDefault();
                dehyariHesab.Bes = Convert.ToInt64(txtBed.Text.Replace(",", ""));
                dbContext.SaveChanges();

            }
        }
        void AssignToTabBedTextBoxs()
        {

            using (DehyariContext dbContext = new DehyariContext())
            {
                try
                {
                    PersonHesab BedHesab = new PersonHesab();
                    BedHesab = dbContext.PersonHesabs.Where(p => p.HesabID == HesabID).First();
                    txtBed.Text = BedHesab.Bed.ToString();
                    cmbBedNo.SelectedValue = BedHesab.BedNoID;
                    if (BedHesab.Sayer != null)
                    {
                        txtSayer.Text = BedHesab.Sayer.ToString();
                        txtSayer.Enabled = true;
                    }
                }
                catch (Exception)
                {

                    
                }
               

            }

        }
        void DeleteBedToPersonHesabTable()
        {
            if (HesabID != -1)
            {
                if (true)
                {
                    if (MessageBox.Show("آیا از حذف این رکورد مطمعن هستید؟", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        using (DehyariContext dbContext = new DehyariContext())
                        {
                            PersonHesab BedHesab = new PersonHesab();
                            BedHesab = dbContext.PersonHesabs.Where(p => p.HesabID == HesabID).First();
                            dbContext.PersonHesabs.Remove(BedHesab);
                            DeleteBesToDehyriHesabTable();
                            dbContext.SaveChanges();
                            
                            HesabID = -1;
                            DisplayBed();
                        }
                    }
                }
            } 
          
        }
        void DeleteBesToDehyriHesabTable()
        {
            using (DehyariContext dbContext = new DehyariContext())
            {
                DehyariHesab dehyariHesab = new DehyariHesab();
                dehyariHesab = dbContext.DehyariHesabs.Where(p => p.PersonHesabID == HesabID).First();
                dbContext.DehyariHesabs.Remove(dehyariHesab); dbContext.SaveChanges();
            }
        }
        //Bes TAB------------------------------------------------------------
        void DisplayBes()
        {
            try
            {
                using (DehyariContext dbContext = new DehyariContext())
                {
                    var query = from BedHesab in dbContext.PersonHesabs
                                where BedHesab.PersonID == PersonID && BedHesab.Bed==null
                                select new
                                {
                                    BedHesab.HesabID,
                                    BedHesab.PersonID,
                                    BedHesab.Bes,
                                    BedHesab.Date,
                                    BedHesab.Sayer
                                };
                    dgvBes.DataSource = query.ToList();
                }
                dgvBes.Columns["Bes"].HeaderText = "مبلغ";
                dgvBes.Columns["Bes"].Width = 150;
            }
            catch (Exception)
            {


            }

        }
        void AddBesToPersonHesabTable()
        {
            using (DehyariContext dbContext = new DehyariContext())
            {
                PersonHesab BesHesab = new PersonHesab();
                BesHesab.PersonID = PersonID;
                BesHesab.Bes = Convert.ToInt64(txtBes.Text.Replace(",", ""));
                BesHesab.Date = changedate.Changedate(cmbDaryaftDate.Text); ;
                BesHesab.BedNoID = Convert.ToInt32(cmbBesNo.SelectedValue);

                if (txtSayerDaryaft.Enabled)
                {
                    if (txtSayer.Text == string.Empty)
                    {
                        MessageBox.Show("لطفا فیلد عنوان دریافتی را انتخاب نمایید");
                    }
                    else
                    {
                        BesHesab.Sayer = txtSayerDaryaft.Text;
                    }
                }
                else
                {
                    BesHesab.Sayer = null;
                }
                dbContext.PersonHesabs.Add(BesHesab);
                dbContext.SaveChanges();
               // AddBeSToDehyariHesabTable();
                DisplayBes();
                EmptyTextBoxOfTabBed();
            }
        }
        void AddBedToDehyariHesabTable()
        {
            int PersonHesabID = FindTheFinalIndex();
            using (DehyariContext dbContext = new DehyariContext())
            {
                DehyariHesab BesHesab = new DehyariHesab();
                BesHesab.PersonHesabID = PersonHesabID;
                BesHesab.Bed = Convert.ToInt64(txtBes.Text.Replace(",", ""));
                BesHesab.Date = changedate.Changedate(cmbDaryaftDate.Text); ;
                
                dbContext.DehyariHesabs.Add(BesHesab);
                dbContext.SaveChanges();
                DisplayBed();
                EmptyTextBoxOfTabBed();
            }
        }
        //-------------------------------------------------------------------
        private void frmPersonDetails_Load(object sender, EventArgs e)
        {        
            DisplayPerson();
            AddComboboxNoZamin();
            AddComboboxJaygahZamin();
            DisplayZamin();
            AddComboboxNoBed();
            DisplayBed();
            DisplayBes();

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
            AssignToTabZaminTextBoxs();
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
        private void txtMasahat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMasahat.Text != string.Empty)
                {
                    txtMasahat.Text = string.Format("{0:N0}", double.Parse(txtMasahat.Text.Replace(",", "")));
                    txtMasahat.Select(txtMasahat.TextLength, 0);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void txtBed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBed.Text != string.Empty)
                {
                    txtBed.Text = string.Format("{0:N0}", double.Parse(txtBed.Text.Replace(",", "")));
                    txtBed.Select(txtBed.TextLength, 0);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void cmbBedNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbBedNo.SelectedValue) == 5)
                {
                    txtSayer.Enabled = true;
                }
                else if (Convert.ToInt32(cmbBedNo.SelectedValue) == 2)
                {
                    double totalBed = 0;

                    using (var dbContext = new DehyariContext())
                    {
                        var query = from z in dbContext.Zamins
                                    join j in dbContext.JaygahZamins on z.JaygahZaminID equals j.JaygahZaminID
                                    where z.PersonID == PersonID
                                    select new { Result = z.Masahat * j.NerkhAb };

                        totalBed =(double) query.Sum(x => x.Result);
                        
                    
                    } ;
                    txtBed.Text= totalBed.ToString("N0");
                }
                else
                {
                    txtBed.Text = string.Empty;
                    txtSayer.Enabled = false;
                    txtSayer.Text = "";
                }
            }
            catch (Exception)
            {

            }
           
        }
        private void btnAddBed_Click(object sender, EventArgs e)
        {
            AddBedToPersonHesabTable();   
        }
        private void btnEditBed_Click(object sender, EventArgs e)
        {
            EditBedToPersonHesabTable();
            HesabID = -1;
        }
        private void dgvBed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBed.CurrentRow.Selected =true;
            HesabID = (int)dgvBed.CurrentRow.Cells["HesabID"].Value;
            AssignToTabBedTextBoxs();
        }
        private void btnDeleteBed_Click(object sender, EventArgs e)
        {
            DeleteBedToPersonHesabTable();
            HesabID = -1;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //try
            //{
            int year = changedate.GetYear(dtpDateSMS.Text);

            //}
            //catch (Exception)
            //{

            //}
            using (DehyariContext dbcontext = new DehyariContext())
            {
                var query = from p in dbcontext.PersonHesabs
                            join bn in dbcontext.BedNoes on p.BedNoID equals bn.BedNoID
                            where (p.Date.Contains(year.ToString()) && p.PersonID == PersonID) && p.Bed != null
                            select new
                            {
                                p.PersonID,
                                bn.BedNo1,
                                p.Bed,
                                p.Date

                            };
                dgSMS.DataSource = query.ToList();
                string s = "";
                var list = query.ToList();
                for (int i = 0;i < list.Count; i++)
                {
                   s += list[i].BedNo1.ToString() + ":" + (double.Parse( list[i].Bed.ToString())).ToString("N0") +"\n";
                }
                
               txtSMS.Text = s.ToString(); 
            }
                

        }

        private void btnBesAdd_Click(object sender, EventArgs e)
        {
            AddBesToPersonHesabTable();
        }

        private void cmbBesNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbBesNo.SelectedValue) == 5)
                {
                    txtSayer.Enabled = true;
                }
                else if (Convert.ToInt32(cmbBesNo.SelectedValue) == 2)
                {
                    double totalBed = 0;
                    using (var dbContext = new DehyariContext())
                    {
                        var query = from z in dbContext.Zamins
                                    join j in dbContext.JaygahZamins on z.JaygahZaminID equals j.JaygahZaminID
                                    where z.PersonID == PersonID
                                    select new { Result = z.Masahat * j.NerkhAb };
                        totalBed = (double)query.Sum(x => x.Result);
                    };
                    txtBes.Text = totalBed.ToString("N0");
                }
                else
                {
                    txtBes.Text = string.Empty;
                    txtSayerDaryaft.Enabled = false;
                    txtSayerDaryaft.Text = "";
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            string[] _to = new string[1];
 
            _to[0] = "09391191129";
            string _text = txtSMS.Text;
            bool _isflash = false;
            string _udh = String.Empty;
            var _ApiSMS = new PARSGREEN.API_SendSMS.SendSMS();
            int _result = _ApiSMS.SendGroupSmsSimple(Signature, ParsgreenSendingPhoneNumber.ToString(), _to, _text, _isflash, _udh);
        }
    }
}
