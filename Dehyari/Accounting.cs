using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dehyari
{
    public class Accounting
    {
        DehyariContext dbContext;
        /// <summary>
        /// bedast avardane bedehi sale
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="Years"></param>
        /// <returns></returns>
        Date changeDate = new Date();
        public double GetBed(int personId, int Years)
        {

            double bed = 0;

            try
            {
                using (DehyariContext dbContext = new DehyariContext())
                {

                    var sum = dbContext.PersonHesabs
                            .Where(p => p.PersonID == personId && p.Date.Contains(Years.ToString()))
                            .Sum(p => p.Bed);
                    bed = (double)sum;
                }

            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در دریافت بدهی کل در رخ داده اشت");
            }
            return bed;
        }

        public List<PersonHesab> GetPersonHesabs(int years, int personID)
        {

            
                using (var context = new DehyariContext())
                {
                    var result = context.PersonHesabs
                  
                        .Where(p => p.Date.Contains(years.ToString()) && p.PersonID == personID)
                        .ToList();
                   return result;
                }
         

        }

    }
}
