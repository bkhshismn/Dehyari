using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dehyari
{
    public  class Date
    {
        public string Changedate(string date)
        {
            string ResultDate = "";
            string years = "";
            string month = "";
            string day = "";
            years = date.Split('/')[0];
            month = date.Split('/')[1];
            day = date.Split('/')[2];
            if (month.Length<2) { month = "0" + month; }
            if (day.Length<2) { day = "0" + day; }
            ResultDate= years +"/" + month+"/" + day;
            return ResultDate;
        }
        public int GetYear(string date)
        {
            int Result = 0;
            string years = "";
            years = date.Split('/')[0];
            Result = Convert.ToInt32(years);
            return Result;
        }
    }
}
