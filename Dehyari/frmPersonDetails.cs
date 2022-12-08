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
        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
          
            DispalyPerson();
        }
    }
}
