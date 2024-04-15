using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //PinDetails();
        }
        private void PinDetails()
        {
            var webRequest = WebRequest.Create("http://postalpincode.in/api/pincode/" + "855114") as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.ContentType = "application/json";
                webRequest.UserAgent = "Nothing";
                using (var s = webRequest.GetResponse().GetResponseStream())
                {
                    using (var sr = new StreamReader(s))
                    {
                        var contributorsAsJson = sr.ReadToEnd();
                        string contributors = JsonConvert.DeserializeObject(contributorsAsJson).ToString();
                        //var contributors = JsonConvert.DeserializeObject<List<pinApi>>(contributorsAsJson);
                        // Parse JSON into dynamic object, convenient!
                        JObject results = JObject.Parse(contributors);

                        foreach (var result in results["PostOffice"])
                        {
                            string employeeName = (string)result["State"];
                            
                        }
                        //string state = string.Format("{0}", contributors.PostOffice.State);
                    }
                }
            }
        }

        protected void txt_postal_pin_TextChanged(object sender, EventArgs e)
        {
            PinDetails();
        }
    }
}