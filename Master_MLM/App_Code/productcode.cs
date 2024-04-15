using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Master_MLM.App_Code
{
    public class productcode
    {
        public string product_code()
        {


            string final_code = "";
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("yyyyMMddhhmmss");
            Random random = new Random();
            int tempo = random.Next(1000, 9999);

            final_code = date + tempo;
            return final_code;

        }
    }
}