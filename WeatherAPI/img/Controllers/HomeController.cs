using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherAPI.Models;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
namespace WeatherAPI.Controllers
{



    public class HomeController : Controller
    {


       

        // GET: Home


        public ActionResult Index() {
            return View();
        }

        public ActionResult Food()
        {
            return View();
        }

        public ActionResult SportsIntroduction()
        {
            return View();
        }

        public ActionResult SportsLocation(object sender, EventArgs e, string searchPostCode, string searchSports)
        {

            {
                
                String url = "https://time-to-go-214605.firebaseio.com/.json";
                string json = new WebClient().DownloadString(url);


                List<String> a = new List<String>();
                List<String> b = new List<String>();
                List<String> c = new List<String>();
                List<String> d = new List<String>();
                List<String> f = new List<String>();
                List<String> g = new List<String>();
                List<String> h = new List<String>();

                List<String> a1 = new List<String>();
                List<String> b1 = new List<String>();
                List<String> c1 = new List<String>();
                List<String> d1 = new List<String>();
                List<String> f1 = new List<String>();
                List<String> g1 = new List<String>();
                List<String> h1 = new List<String>();


                List<List<String>> sum3 = new List<List<String>>();
                List<List<String>> sum2 = new List<List<String>>();


                List<SportsLocations> listSports = JsonConvert.DeserializeObject<List<SportsLocations>>(json);
                foreach (SportsLocations item in listSports)
                {
                    a.Add(item.name);
                    b.Add(item.sports);
                    c.Add(item.streetName);
                    d.Add(item.condition);
                    f.Add(item.postCode);
                    g.Add(item.latitude);
                    h.Add(item.longtitude);
                }


                if (searchPostCode != null && searchSports != null && searchPostCode != "" && searchSports != "")
                {
                    for (var i = 0; i < a.Count; i++)
                    {

                        if (b[i].Equals(searchSports))
                        {
                            List<String> sum1 = new List<String>();
                            sum1.Add(a[i]);
                            sum1.Add(b[i]);
                            sum1.Add(c[i]);
                            sum1.Add(d[i]);
                            sum1.Add(f[i]);
                            sum1.Add(g[i]);
                            sum1.Add(h[i]);
                            sum3.Add(sum1);
                        }

                    }

                    for (var i = 0; i < sum3.Count; i++)
                    {

                        if (sum3[i][4].Contains(searchPostCode))
                        {

                            sum2.Add(sum3[i]);
                        }

                    }

                    ViewBag.list = sum2;
                    return View();
                }

                if ((searchPostCode != "" && searchSports == ""))
                {
                    for (var i = 0; i < a.Count; i++)
                    {

                        if (f[i].Equals(searchPostCode))
                        {
                            List<String> sum1 = new List<String>();
                            sum1.Add(a[i]);
                            sum1.Add(b[i]);
                            sum1.Add(c[i]);
                            sum1.Add(d[i]);
                            sum1.Add(f[i]);
                            sum1.Add(g[i]);
                            sum1.Add(h[i]);
                            sum2.Add(sum1);
                        }

                    }

                    ViewBag.list = sum2;
                    return View();
                }
                if ((searchPostCode == "" && searchSports != ""))
                {
                    for (var i = 0; i < a.Count; i++)
                    {

                        if (b[i].Equals(searchSports))
                        {
                            List<String> sum1 = new List<String>();
                            sum1.Add(a[i]);
                            sum1.Add(b[i]);
                            sum1.Add(c[i]);
                            sum1.Add(d[i]);
                            sum1.Add(f[i]);
                            sum1.Add(g[i]);
                            sum1.Add(h[i]);
                            sum2.Add(sum1);
                        }

                    }

                    ViewBag.list = sum2;
                    return View();
                }


                else
                {
                    ViewBag.list = new List<List<String>>();
                    return View();
                }
            }
        }

        public ActionResult Weather()
        {
            return View();
        }

        public ActionResult Map(string Latitude, string Longtitude)
        {
            @ViewBag.latitude = Latitude;
            @ViewBag.longtitude = Longtitude;
            return View();
        }

        public ActionResult Calories(object sender, EventArgs e, string weight, string searchSports1, string frequence1, string duration1, string searchSports2, string frequence2, string duration2, string searchSports3, string frequence3, string duration3)
        {
            String url = "https://time-to-go-214605-8ac7a.firebaseio.com/.json";
            string json = new WebClient().DownloadString(url);

            List<String> a = new List<String>();
            List<String> b = new List<String>();
            List<String> c = new List<String>();
            List<String> d = new List<String>();


            List<String> a1 = new List<String>();
            List<String> b1 = new List<String>();
            List<String> c1 = new List<String>();
            List<String> d1 = new List<String>();


            List<List<String>> sum3 = new List<List<String>>();
            List<List<String>> sum2 = new List<List<String>>();


            List<Calories> listSports = JsonConvert.DeserializeObject<List<Calories>>(json);

           

            

            foreach (Calories item in listSports)
                {
                    a.Add(item.id);
                    b.Add(item.name);
                    c.Add(item.mets);
                    d.Add(item.lbs);
                }

            float lost = 0;

            if(weight == null)
            {

                ViewBag.list1 = 0;
                ViewBag.list2 = 0;
                ViewBag.mess1 = "";
                ViewBag.mess2 = "";
                return View();
            }

            if (weight != null && weight != "")
            {
                float newWeight = Convert.ToSingle(weight);

                if (searchSports1 != null && searchSports1 != "" && duration1 != null && duration1 != "" && frequence1 != null && frequence1 != ""
                 && searchSports2 != null && searchSports2 != "" && duration2 != null && duration2 != "" && frequence2 != null && frequence2 != ""
                 && searchSports3 != null && searchSports3 != "" && duration3 != null && duration3 != "" && frequence3 != null && frequence3 != ""
                )
                {

                    float newDuration1 = Convert.ToSingle(duration1);
                    float newDuration2 = Convert.ToSingle(duration2);
                    float newDuration3 = Convert.ToSingle(duration3);

                    float newFrequence1 = Convert.ToSingle(frequence1);
                    float newFrequence2 = Convert.ToSingle(frequence2);
                    float newFrequence3 = Convert.ToSingle(frequence3);
                    for (var i = 0; i < a.Count; i++)
                    {
                        if (b[i].Equals(searchSports3))
                        {

                            float num1 = 125;
                            float num2 = Convert.ToSingle(0.453592);

                            float lost1 = Convert.ToSingle(d[i]);
                            lost = lost + lost1 / (num1 * num2) * newWeight * newDuration3 * newFrequence3 / 7 * 365 / 12;
                        }
                        if (b[i].Equals(searchSports2))
                        {

                            float num1 = 125;
                            float num2 = Convert.ToSingle(0.453592);
                            float lost1 = Convert.ToSingle(d[i]);
                            lost = lost + lost1 / (num1 * num2) * newWeight * newDuration2 * newFrequence2 / 7 * 365 / 12;
                        }
                        if (b[i].Equals(searchSports1))
                        {

                            float num1 = 125;
                            float num2 = Convert.ToSingle(0.453592);
                            float lost1 = Convert.ToSingle(d[i]);
                            lost = lost + lost1 / (num1 * num2) * newWeight * newDuration1 * newFrequence1 / 7 * 365 / 12;
                        }
                    }
                    double sumLost1 = Math.Round(Convert.ToDouble(lost), 2);
                    double sumLost2 = Math.Round(lost / 7550, 2);
                    ViewBag.list1 = sumLost1;
                    ViewBag.list2 = sumLost2;
                    ViewBag.mess1 = "Based on this schedule, you will spend " + sumLost1 + " Calories this month";
                    ViewBag.mess2 = "You will lost " + sumLost2 + " Kg this month, if you keep this schedule";
                    return View();
                }


                if ((searchSports1 != null && searchSports1 != "" && duration1 != null && duration1 != "" && frequence1 != null && frequence1 != ""
                     && searchSports2 != null && searchSports2 != "" && duration2 != null && duration2 != "" && frequence2 != null && frequence2 != "")
                     && (searchSports3 == null || searchSports3 == "" || duration3 == null || duration3 == "" || frequence3 == null || frequence3 == "")
                    )
                {
                    float newDuration1 = Convert.ToSingle(duration1);
                    float newDuration2 = Convert.ToSingle(duration2);

                    float newFrequence1 = Convert.ToSingle(frequence1);
                    float newFrequence2 = Convert.ToSingle(frequence2);
                    for (var i = 0; i < a.Count; i++)
                    {

                        if (b[i].Equals(searchSports2))
                        {

                            float num1 = 125;
                            float num2 = Convert.ToSingle(0.453592);
                            float lost1 = Convert.ToSingle(d[i]);
                            lost = lost + lost1 / (num1 * num2) * newWeight * newDuration2 * newFrequence2 / 7 * 365 / 12;
                        }
                        if (b[i].Equals(searchSports1))
                        {

                            float num1 = 125;
                            float num2 = Convert.ToSingle(0.453592);
                            float lost1 = Convert.ToSingle(d[i]);
                            lost = lost + lost1 / (num1 * num2) * newWeight * newDuration1 * newFrequence1 / 7 * 365 / 12;
                        }
                    }
                    double sumLost1 = Math.Round(Convert.ToDouble(lost), 2);
                    double sumLost2 = Math.Round(lost / 7550, 2);
                    ViewBag.list1 = sumLost1;
                    ViewBag.list2 = sumLost2;
                    ViewBag.mess1 = "Based on this schedule, you will spend" + sumLost1 + " Calories this month";
                    ViewBag.mess2 = "You will lost " + sumLost2 + " Kg this month, if you keep this schedule";
                    return View();
                }



                if ((searchSports1 != null && searchSports1 != "" && duration1 != null && duration1 != "" && frequence1 != null && frequence1 != "")
                     && (searchSports2 == null || searchSports2 == "" || duration2 == null || duration2 == "" || frequence2 == null || frequence2 == ""
                     && searchSports3 == null || searchSports3 == "" || duration3 == null || duration3 == "" || frequence3 == null || frequence3 == ""))
                {
                    float newDuration1 = Convert.ToSingle(duration1);

                    float newFrequence1 = Convert.ToSingle(frequence1);
                    for (var i = 0; i < a.Count; i++)
                    {


                        if (b[i].Equals(searchSports1))
                        {

                            float num1 = 125;
                            float num2 = Convert.ToSingle(0.453592);
                            float lost1 = Convert.ToSingle(d[i]);
                            lost = lost + lost1 / (num1 * num2) * newWeight * newDuration1 * newFrequence1 / 7 * 365 / 12;
                        }
                    }
                    double sumLost1 = Math.Round(Convert.ToDouble(lost), 2);
                    double sumLost2 = Math.Round(lost / 7550, 2);
                    ViewBag.list1 = sumLost1;
                    ViewBag.list2 = sumLost2;
                    ViewBag.mess1 = "Based on this schedule, you will spend " + sumLost1 + " Calories this month";
                    ViewBag.mess2 = "You will lost " + sumLost2 + " Kg this month, if you keep this schedule";
                    return View();
                }




                if ((searchSports1 == null || searchSports1 == "") && (duration1 == null || duration1 == "") && (frequence1 == null || frequence1 == "")
                     && (searchSports2 == null || searchSports2 == "") && (duration2 == null || duration2 == "") && (frequence2 == null || frequence2 == "")
                     && (searchSports3 == null || searchSports3 == "") && (duration3 == null || duration3 == "") && (frequence3 == null || frequence3 == "")
                    )
                {
                    ViewBag.list1 = 0;
                    ViewBag.list2 = 0;
                    ViewBag.mess1 = "";
                    ViewBag.mess2 = "";
                    return View();
                }






                else
                {
                    ViewBag.list1 = 0;
                    ViewBag.list2 = 0;
                    ViewBag.mess1 = "please enter the right value";
                    ViewBag.mess2 = "";
                    return View();
                }
            }

            else
            {
                ViewBag.list1 = 0;
                ViewBag.list2 = 0;
                ViewBag.mess1 = "please enter your weight";
                ViewBag.mess2 = "";
                return View();
            }
            
        }
    }
}