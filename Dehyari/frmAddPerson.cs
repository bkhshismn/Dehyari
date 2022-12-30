using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace Dehyari
{
    public partial class frmAddPerson : Form
    {
        public int Refer { get; set; }//1=Add, 2= Edit
        public int PersonID { get; set; }
        DehyariContext d = new DehyariContext();
        int Sarparast = -1;
        int SahebKhane = -1;
        int Taaol = -1;
        void InitializeSetups()
        {
            rdbSarparastYes.Checked = true;
            rdbSahebKhaneYes.Checked = true;
            rdbTaaholYes.Checked = true;
            if (int.Parse(txtMetraj.Text) > 0)
            {
                txtMetraj.Visible = false;
                lblMetraj.Visible = false;
            }  
        }
        void AddComboboxSex()
        {
            using ( d = new DehyariContext())
            {
                List<Sex> sexes = d.Sexes.ToList();
                cmbSex.DataSource = sexes;
                cmbSex.ValueMember = "SexID";
                cmbSex.DisplayMember = "Sex1";
            }
        }
        void AddComboboxTahsilat()
        {
            using ( d = new DehyariContext())
            {
                List<Tahsilatt> tahsilatts  = d.Tahsilatts.ToList();
                cmbTahsilat.DataSource = tahsilatts;
                cmbTahsilat.ValueMember = "TahsilatID";
                cmbTahsilat.DisplayMember = "NoTahsilat";
            }
        }
        void AddBime()
        {
            using (d = new DehyariContext())
            {
                List<Bime> bimes = d.Bimes.ToList();
                cmbBime.DataSource = bimes;
                cmbBime.ValueMember = "BimeID";
                cmbBime.DisplayMember = "NoBime";
            }
        }
        void RadioButtomsChecking()
        {

            if (rdbSarparastYes.Checked)
            {
                Sarparast = 1;
            }
            else if (rdbSarparastNo.Checked)
            {
                Sarparast = 2;
            }
            if (rdbSahebKhaneYes.Checked)
            {
                SahebKhane = 1;
            }
            else if (rdbSahebKhaneNo.Checked)
            {
                SahebKhane = 2;
                txtMetraj.Text = "0";
            }
            if (rdbTaaholYes.Checked)
            {
                Taaol = 1;
            }
            else if (rdbTaaholNo.Checked)
            {
                Taaol = 2;
            }
        }     
        void txtMetrajVisibaleChange()
        {
            if (rdbSahebKhaneYes.Checked)
            {
                txtMetraj.Visible = true;
                lblMetraj.Visible = true;
            }
            else
            {
                txtMetraj.Visible = false;
                lblMetraj.Visible = false;
            }
            
        }
        bool CheckingEmptyItemForAdd()
        {
            string MessageText = "";
            bool check=true;
            if (txtName.Text == String.Empty)
            {
                MessageText += "لطفا فیلد نام را پر کنید  " + " \n";
                check = false;
            }
             if (txtFamily.Text == String.Empty)
            {

                MessageText += "لطفا فیلد نام خانوادگی را پر کنید  " + " \n";
                check = false;
            }
            if (txtNamePedar.Text == String.Empty)
            {

                MessageText += "لطفا فیلد نام پدر را پر کنید  " + " \n";
                check = false;
            }
            if (check==false)
            {
                MessageBox.Show(MessageText);
            }
            return check;
        }
        void IsKhanedar(int iskhanedarId)
        {
            if (iskhanedarId == 1)
            {
                rdbSahebKhaneYes.Checked = true;
            }
            else
            {
                rdbSahebKhaneNo.Checked = true;
            }
        }
        void IsMarried(int ismarriedId)
        {
            if (ismarriedId == 1)
            {
                rdbTaaholYes.Checked = true;
            }
            else
            {
                rdbTaaholNo.Checked = true;
            }
        }
        void IsSarparast(int issarparastId)
        {
            if (issarparastId == 1)
            {
                rdbSarparastYes.Checked = true;
            }
            else
            {
                rdbSarparastNo.Checked = true;
            }
        }
        void AssignToFields()
        {
            Person person = new Person();
            using (d=new DehyariContext())
            {
                person = d.People.Where(c => c.PersonID == PersonID).First();
                txtName.Text = person.Name;
                txtFamily.Text = person.Family;
                txtCodeMelli.Text = person.CodeMelli;
                txtCodePosti.Text = person.CodePosti;
                txtMetraj.Text = person.MetrajKhane.ToString();
                txtMobile.Text=person.Mobile;
                txtTellSabet.Text = person.TelSabet;
                txtNamePedar.Text=person.NamePedar;
                txtShoareShenasname.Text = person.ShomareShenasname;
                cmbBime.SelectedValue = person.BimeID;
                cmbSex.SelectedValue = person.SexID;
                cmbTahsilat.SelectedValue = person.TahsilatID;
                IsKhanedar((int)person.IsKhanedarID.Value);
                IsMarried((int)person.IsMarriedID.Value);
                IsSarparast((int)person.IsSarparastKhanevarID);
            }

        }
        void AddPrtson()
        {
            using (d = new DehyariContext())
            {
                Person p = new Person();
                p.Name = txtName.Text;
                p.Family = txtFamily.Text;
                p.CodeMelli = txtCodeMelli.Text;
                p.CodePosti = txtCodePosti.Text;
                p.NamePedar = txtNamePedar.Text;
                p.Mobile = txtMobile.Text;
                p.TelSabet = txtTellSabet.Text;
                p.TarikhTavalod=cmbBirthDate.Text;
                p.TarikhTavalod = cmbBirthDate.Value.Year.ToString() + "/" + cmbBirthDate.Value.Month.ToString("0#") + "/" + cmbBirthDate.Value.Day.ToString();
                p.MetrajKhane = Convert.ToDouble(txtMetraj.Text.Replace(",", ""));
                p.ShomareShenasname = txtShoareShenasname.Text;
                p.BimeID = Convert.ToInt32(cmbBime.SelectedValue);
                p.TahsilatID = Convert.ToInt32(cmbTahsilat.SelectedValue);
                p.SexID = Convert.ToInt32(cmbSex.SelectedValue);
                p.IsKhanedarID = SahebKhane;
                p.IsSarparastKhanevarID = Sarparast;
                p.IsMarriedID = Taaol;
                d.People.Add(p);
                d.SaveChanges();
                this.Close();
            }
        }
        void EditPrtson()
        {
            using (d = new DehyariContext())
            {
                Person p = new Person();
                p = d.People.Where(c => c.PersonID == PersonID).First();
                p.Name = txtName.Text;
                p.Family = txtFamily.Text;
                p.CodeMelli = txtCodeMelli.Text;
                p.CodePosti = txtCodePosti.Text;
                p.NamePedar = txtNamePedar.Text;
                p.Mobile = txtMobile.Text;
                p.TelSabet = txtTellSabet.Text;
                p.TarikhTavalod = cmbBirthDate.Value.Year.ToString()+"/" + cmbBirthDate.Value.Month.ToString("0#") + "/" + cmbBirthDate.Value.Day.ToString()  ;
                p.MetrajKhane = Convert.ToDouble(txtMetraj.Text.Replace(",", ""));
                p.ShomareShenasname = txtShoareShenasname.Text;
                p.BimeID = Convert.ToInt32(cmbBime.SelectedValue);
                p.TahsilatID = Convert.ToInt32(cmbTahsilat.SelectedValue);
                p.SexID = Convert.ToInt32(cmbSex.SelectedValue);
                p.IsKhanedarID = SahebKhane;
                p.IsSarparastKhanevarID = Sarparast;
                p.IsMarriedID = Taaol;
                d.SaveChanges();
                this.Close();

            }
        }
        public frmAddPerson()//FormLoad
        {
            InitializeComponent();
            AddComboboxSex();
            AddComboboxTahsilat();
            AddComboboxTahsilat();
            AddBime();
            InitializeSetups();
            

        }

        private void AddPerson_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Refer ==1)
            {
                if (CheckingEmptyItemForAdd() == true)
                {
                    RadioButtomsChecking();
                    AddPrtson();
                }
            }
            else
            {
                if (CheckingEmptyItemForAdd() == true)
                {
                    RadioButtomsChecking();
                    EditPrtson();
                }
            }
           
        }
        private void rdbSahebKhaneYes_CheckedChanged(object sender, EventArgs e)
        {
            txtMetrajVisibaleChange();
        }
        private void AddPerson_Load(object sender, EventArgs e)
        {
            if (Refer == 2)
            {
                AssignToFields();
            }
        }
    }
}
