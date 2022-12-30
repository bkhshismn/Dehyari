using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Dehyari
{
    public partial class frmLoadPerson : Form
    {
        int personID = -1;
        DehyariContext d = new DehyariContext();
        public frmLoadPerson()
        {
            InitializeComponent();
            DisplayPerson();
        }
        void DataGridHeaders()
        {
            dgvLoadPeople.Columns["PersonID"].HeaderText = "کد شخص";
            dgvLoadPeople.Columns["fullname"].HeaderText = "نام";
            dgvLoadPeople.Columns["SexID"].Visible = false;
            dgvLoadPeople.Columns["Sex1"].HeaderText = "جنسیت";
            dgvLoadPeople.Columns["ShomareShenasname"].HeaderText = "ش شناسنامه";
            dgvLoadPeople.Columns["TarikhTavalod"].HeaderText = "تاریخ تولد";
            dgvLoadPeople.Columns["CodeMelli"].HeaderText ="کد ملی";
            dgvLoadPeople.Columns["NamePedar"].HeaderText = "نام پدر";
            dgvLoadPeople.Columns["Sarparast"].HeaderText = "سرپرست خانوار";
            dgvLoadPeople.Columns["IsKhanedarID"].Visible = false;
            dgvLoadPeople.Columns["SahebKhane"].HeaderText = "صاحب خانه";
            dgvLoadPeople.Columns["MetrajKhane"].HeaderText = "متراژ خانه";
            dgvLoadPeople.Columns["Mobile"].HeaderText = "شماره همراه";
            dgvLoadPeople.Columns["TelSabet"].HeaderText = "تلفن ثابت";
            dgvLoadPeople.Columns["IsMarriedID"].Visible=false;
            dgvLoadPeople.Columns["CodePosti"].HeaderText = "کد پستی";
            dgvLoadPeople.Columns["BimeID"].Visible = false;
            dgvLoadPeople.Columns["NoBime"].HeaderText = "نوع بیمه";
            dgvLoadPeople.Columns["TahsilatID"].Visible = false;
            dgvLoadPeople.Columns["NoTahsilat"].HeaderText = "تحصیلات";
            dgvLoadPeople.Columns["IsSarparastKhanevarID"].Visible = false;

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
                        select new
                        {
                            r.PersonID,
                            fullname = r.Name + " "+ r.Family,
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
                            r.CodePosti,
                            r.TahsilatID,
                            t.NoTahsilat,
                            r.BimeID,
                            b.NoBime
                        };
            dgvLoadPeople.DataSource = query.ToList();

            DataGridHeaders();
        }
        void Search()
        {
           // Person person = new Person();
            using (DehyariContext dbcontext = new DehyariContext())
            {
                var query = from r in dbcontext.People
                            join k in dbcontext.IsKhanedars on r.IsKhanedarID equals k.IsKhanedarID
                            join s in dbcontext.IsSarparastKhanevars on r.IsSarparastKhanevarID equals s.IsSarparastKhanevarID
                            join Sx in dbcontext.Sexes on r.SexID equals Sx.SexID
                            join b in dbcontext.Bimes on r.BimeID equals b.BimeID
                            join t in dbcontext.Tahsilatts on r.TahsilatID equals t.TahsilatID
                            where(r.Name.Contains(txtSearch.Text) || 
                                  r.Family.Contains(txtSearch.Text ) || 
                                  r.CodeMelli.Contains(txtSearch.Text))
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
                                r.CodePosti,
                                r.TahsilatID,
                                t.NoTahsilat,
                                r.BimeID,
                                b.NoBime
                            };
                dgvLoadPeople.DataSource = query.ToList();

                DataGridHeaders();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddPerson Add = new frmAddPerson();
            Add.Refer = 1;
            Add.Text = "افزودن شخص";
            if (Add.ShowDialog() == DialogResult.OK)
            {
                DisplayPerson();
            }
        }
        private void dgvLoadPeople_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvLoadPeople.CurrentRow.Selected = true;
            personID = (int)dgvLoadPeople.CurrentRow.Cells["personID"].Value;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmAddPerson Add = new frmAddPerson();
            Add.Refer = 2;
            Add.PersonID = personID;
            Add.Text = "ویرایش شخص";
            if (personID != -1)
            {
                if (Add.ShowDialog() == DialogResult.OK)
                {
                    DisplayPerson();
                    personID = -1;
                }
            }
            else
            {
                MessageBox.Show("لطفا رکورد مورد نظر را انتخاب کنید");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (personID != -1)
            {
                if (MessageBox.Show("آیا از حذف این رکورد مطمعن هستید؟", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    using (d = new DehyariContext())
                    {
                        Person p = new Person();
                        p = d.People.Where(c => c.PersonID == personID).First();
                        d.People.Remove(p);
                        d.SaveChanges();
                        DisplayPerson();
                        personID = -1;
                    }
                }
            }
            else
            {
                MessageBox.Show("لطفا رکورد مورد نظر را انتخاب کنید");
            }
        }
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        private void dgvLoadPeople_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            frmPersonDetails  frm = new frmPersonDetails();
            frm.PersonID = personID;
            frm.Text = "جزئیات ";
            if (personID != -1)
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DisplayPerson();
                    personID = -1;
                }
            }
            else
            {
                MessageBox.Show("لطفا رکورد مورد نظر را انتخاب کنید");
            }
        }

    }
}
