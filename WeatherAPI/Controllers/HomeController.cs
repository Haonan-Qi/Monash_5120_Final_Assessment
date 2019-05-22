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


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Recommendation()
        {
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
        public ActionResult Events(string a, string b, string c)
        {
            if (a == null && b == null && c == null)
            {
                ViewBag.a = "";
                ViewBag.b = "";
                ViewBag.c = "";
            }
            else
            {
ViewBag.a = a.ToLower();
            ViewBag.b = b.ToLower();
            ViewBag.c = c.ToLower();
            }
            
            return View();
        }

        public ActionResult eventsdraft()
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
                    int check;
                    if (!int.TryParse(searchPostCode, out check))
                    {
                        ViewBag.list = new List<List<String>>();
                        ViewBag.number = 0;
                        ViewBag.meg = "Please enter the correct postcode";
                    }
                    else
                    {
                        int judge = Convert.ToInt32(searchPostCode);
                        int judge1 = judge / 1000;
                        if (searchPostCode.Count() != 4 || judge1 != 3)
                        {
                            ViewBag.list = new List<List<String>>();
                            ViewBag.number = 0;
                            ViewBag.meg = "Please enter the correct postcode";
                        }
                        else {
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
                            if (sum2.Count == 0)
                            {
                                ViewBag.number = 0;
                                ViewBag.meg = "No Result Found";
                            }
                            else
                            {
                                ViewBag.number = 1;
                                ViewBag.meg = "";
                            }
                        }
                    }
                    return View();
                }

                if ((searchPostCode != "" && searchSports == ""))
                {
                    int check;
                    if (!int.TryParse(searchPostCode, out check))
                    {
                        ViewBag.list = new List<List<String>>();
                        ViewBag.number = 0;
                        ViewBag.meg = "Please enter the correct postcode";
                    }
                    else
                    {
                        int judge = Convert.ToInt32(searchPostCode);
                        int judge1 = judge / 1000;
                        if (searchPostCode.Count() != 4 || judge1 != 3)
                        {
                            ViewBag.list = new List<List<String>>();
                            ViewBag.number = 0;
                            ViewBag.meg = "Please enter the correct postcode";
                        }
                        else
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
                            if (sum2.Count == 0)
                            {
                                ViewBag.number = 0;
                                ViewBag.meg = "No Results Found";
                            }
                            else
                            {
                                ViewBag.number = 1;
                                ViewBag.meg = "";
                            }
                        }
                    }
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
                    if (sum2.Count == 0)
                    {
                        ViewBag.number = 0;
                        ViewBag.meg = "No Result Found";
                    }
                    else
                    {
                        ViewBag.number = 1;
                        ViewBag.meg = "";
                    }
                    return View();
                }


                else
                {
                    ViewBag.list = new List<List<String>>();
                    ViewBag.number = 0;
                    if (searchPostCode == "" && searchSports == "")
                    {
                        ViewBag.meg = "Please enter the postcode or select the sports";
                    }
                    else
                    {
                        ViewBag.meg = "";
                    }
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

            if (weight == null)
            {

                ViewBag.list1 = 0;
                ViewBag.list2 = 0;
                ViewBag.list3 = 0;
                ViewBag.list4 = 0;
                ViewBag.list5 = 0;
                ViewBag.plan1 = "Plan1";
                ViewBag.plan2 = "Plan2";
                ViewBag.plan3 = "Plan3";
                ViewBag.mess1 = "";
                ViewBag.mess2 = "";
                ViewBag.mess5 = "";
                ViewBag.mess6 = "";
                ViewBag.mess3 = "";
                ViewBag.mess4 = "";
                ViewBag.mess7 = "";
                ViewBag.mess8 = "";
                ViewBag.mess9 = "";
                ViewBag.mess10 = "";
                return View();
            }

            if (weight != null && weight != "")
            {
                double check;
                if (!Double.TryParse(weight, out check))
                {
                    ViewBag.list1 = 0;
                    ViewBag.list2 = 0;
                    ViewBag.list3 = 0;
                    ViewBag.list4 = 0;
                    ViewBag.list5 = 0;
                    ViewBag.plan1 = "Plan1";
                    ViewBag.plan2 = "Plan2";
                    ViewBag.plan3 = "Plan3";
                    ViewBag.mess1 = "";
                    ViewBag.mess2 = "please enter the right value of weight";
                    ViewBag.mess5 = "";
                    ViewBag.mess6 = "";
                    ViewBag.mess3 = "";
                    ViewBag.mess4 = "";
                    ViewBag.mess7 = "";
                    ViewBag.mess8 = "";
                    ViewBag.mess9 = "";
                    ViewBag.mess10 = "";
                    return View();
                }

                float newWeight = Convert.ToSingle(weight);

                if (searchSports1 == "")
                {
                    ViewBag.list1 = 0;
                    ViewBag.list2 = 0;
                    ViewBag.list3 = 0;
                    ViewBag.list4 = 0;
                    ViewBag.list5 = 0;
                    ViewBag.plan1 = "Plan1";
                    ViewBag.plan2 = "Plan2";
                    ViewBag.plan3 = "Plan3";
                    ViewBag.mess1 = "";
                    ViewBag.mess2 = "please choose at least one favourite sport";
                    ViewBag.mess5 = "";
                    ViewBag.mess6 = "";
                    ViewBag.mess3 = "";
                    ViewBag.mess4 = "";
                    ViewBag.mess7 = "";
                    ViewBag.mess8 = "";
                    ViewBag.mess9 = "";
                    ViewBag.mess10 = "";
                    return View();
                }

                if(searchSports2 != "" && searchSports3 != "" && (searchSports1 == searchSports2 || searchSports2 == searchSports3 || searchSports3 == searchSports1))
                {
                    ViewBag.list1 = 0;
                    ViewBag.list2 = 0;
                    ViewBag.list3 = 0;
                    ViewBag.list4 = 0;
                    ViewBag.list5 = 0;
                    ViewBag.plan1 = "Plan1";
                    ViewBag.plan2 = "Plan2";
                    ViewBag.plan3 = "Plan3";
                    ViewBag.mess1 = "";
                    ViewBag.mess2 = "please choose different sports";
                    ViewBag.mess5 = "";
                    ViewBag.mess6 = "";
                    ViewBag.mess3 = "";
                    ViewBag.mess4 = "";
                    ViewBag.mess7 = "";
                    ViewBag.mess8 = "";
                    ViewBag.mess9 = "";
                    ViewBag.mess10 = "";
                    return View();
                }

                if (searchSports2 != ""  && (searchSports1 == searchSports2 ))
                {
                    ViewBag.list1 = 0;
                    ViewBag.list2 = 0;
                    ViewBag.list3 = 0;
                    ViewBag.list4 = 0;
                    ViewBag.list5 = 0;
                    ViewBag.plan1 = "Plan1";
                    ViewBag.plan2 = "Plan2";
                    ViewBag.plan3 = "Plan3";
                    ViewBag.mess1 = "";
                    ViewBag.mess2 = "please choose different sports";
                    ViewBag.mess5 = "";
                    ViewBag.mess6 = "";
                    ViewBag.mess3 = "";
                    ViewBag.mess4 = "";
                    ViewBag.mess7 = "";
                    ViewBag.mess8 = "";
                    ViewBag.mess9 = "";
                    ViewBag.mess10 = "";
                    return View();
                }


                if (searchSports1 != null && searchSports1 != "" && duration1 != null && duration1 != "" && frequence1 != null && frequence1 != ""
                 && searchSports2 != null && searchSports2 != "" && duration2 != null && duration2 != "" && frequence2 != null && frequence2 != ""
                 && searchSports3 != null && searchSports3 != "" && duration3 != null && duration3 != "" && frequence3 != null && frequence3 != ""
                )
                {
                    float lost3 = 0;
                    float lost4 = 0;
                    float lost5 = 0;
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
                            lost5 = lost5 + lost1 / (num1 * num2) * newWeight * newDuration3 * newFrequence3 / 7 * 365 / 12;
                            lost = lost + lost1 / (num1 * num2) * newWeight * newDuration3 * newFrequence3 / 7 * 365 / 12;
                        }
                        if (b[i].Equals(searchSports2))
                        {

                            float num1 = 125;
                            float num2 = Convert.ToSingle(0.453592);
                            float lost1 = Convert.ToSingle(d[i]);
                            lost4 = lost4 + lost1 / (num1 * num2) * newWeight * newDuration2 * newFrequence2 / 7 * 365 / 12;
                            lost = lost + lost1 / (num1 * num2) * newWeight * newDuration2 * newFrequence2 / 7 * 365 / 12;
                        }
                        if (b[i].Equals(searchSports1))
                        {

                            float num1 = 125;
                            float num2 = Convert.ToSingle(0.453592);
                            float lost1 = Convert.ToSingle(d[i]);
                            lost3 = lost3 + lost1 / (num1 * num2) * newWeight * newDuration1 * newFrequence1 / 7 * 365 / 12;
                            lost = lost + lost1 / (num1 * num2) * newWeight * newDuration1 * newFrequence1 / 7 * 365 / 12;
                        }
                    }

                    double sumLost1 = Math.Round(Convert.ToDouble(lost), 2);
                    double sumLost2 = Math.Round(lost / 7550, 2);
                    double sumLost3 = Math.Round(lost3 / 7550, 2);
                    double sumLost4 = Math.Round(lost4 / 7550, 2);
                    double sumLost5 = Math.Round(lost5 / 7550, 2);
                    ViewBag.list1 = sumLost1;
                    ViewBag.list2 = sumLost2;
                    ViewBag.list3 = sumLost3;
                    ViewBag.list4 = sumLost4;
                    ViewBag.list5 = sumLost5;
                    ViewBag.plan1 = searchSports1;
                    ViewBag.plan2 = searchSports2;
                    ViewBag.plan3 = searchSports3;
                    ViewBag.mess99 = "Based on this schedule";
                    ViewBag.mess1 = "You will burn " + sumLost1 + " calories this month";
                    ViewBag.mess99 = "Based on this schedule";
                    ViewBag.mess2 = "You will lose " + sumLost2 + " Kg this month, if you keep this schedule";
                    ViewBag.mess3 = "Your current plan:";
                    ViewBag.mess4 = "1. Take part in " + searchSports1 + ", " + frequence1 + " time(s) per week, spend " + duration1 + " hour(s) per session";
                    ViewBag.mess5 = "2. Take part in " + searchSports2 + ", " + frequence2 + " time(s) per week, spend " + duration2 + " hour(s) per session";
                    ViewBag.mess6 = "3. Take part in " + searchSports3 + ", " + frequence3 + " time(s) per week, spend " + duration3 + " hour(s) per session";
                    ViewBag.messBorder = "border:solid; color: white; border-radius:15px";

                    if (sumLost2 <= 5)
                    {
                        ViewBag.mess7 = "To lose 0-5Kgs in a month, what do I eat?";
                        ViewBag.mess8 = "Breakfast - a portion (20 grams) of protein - eggs, yogurt, smoked salmon + a portion (20 grams) of carbs -a slice of whole grain bread(or) a bowl of whole grain cereal and milk.";
                        ViewBag.mess9 = "Lunch - About two cups of vegetables is highly recommended with a wrap (or) sashimi with a bowl of vegetables.";
                        ViewBag.mess10 = "Dinner - It is essential to note that this should be the lightest meal of the day. So a combination of boiled white fish and salad or a few pieces of chicken with soup would be ideal.";
                    }

                    else
                    {
                        ViewBag.mess7 = "To lose 5-10Kgs in a month, what do I eat?";
                        ViewBag.mess8 = "Breakfast - ½ cup of oatmeal with ½ cup of skim milk, (or) a glass of green tea with an omelette made up of two egg white and a slice of whole grain toast.";
                        ViewBag.mess9 = "Mid morning snack - a bowl of lean fruits.";
                        ViewBag.mess10 = "Lunch - a bowl of vegetable soup with two slices of whole grain bread (or) grilled salmon.";
                    }
                    return View();
                }


                if ((searchSports1 != null && searchSports1 != "" && duration1 != null && duration1 != "" && frequence1 != null && frequence1 != ""
                     && searchSports2 != null && searchSports2 != "" && duration2 != null && duration2 != "" && frequence2 != null && frequence2 != "")
                     && (searchSports3 == null || searchSports3 == "" || duration3 == null || duration3 == "" || frequence3 == null || frequence3 == "")
                    )
                {
                    float lost3 = 0;
                    float lost4 = 0;
                    float lost5 = 0;

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
                            lost4 = lost4 + lost1 / (num1 * num2) * newWeight * newDuration2 * newFrequence2 / 7 * 365 / 12;
                            lost = lost + lost1 / (num1 * num2) * newWeight * newDuration2 * newFrequence2 / 7 * 365 / 12;
                        }
                        if (b[i].Equals(searchSports1))
                        {

                            float num1 = 125;
                            float num2 = Convert.ToSingle(0.453592);
                            float lost1 = Convert.ToSingle(d[i]);
                            lost3 = lost3 + lost1 / (num1 * num2) * newWeight * newDuration1 * newFrequence1 / 7 * 365 / 12;
                            lost = lost + lost1 / (num1 * num2) * newWeight * newDuration1 * newFrequence1 / 7 * 365 / 12;
                        }
                    }
                    double sumLost1 = Math.Round(Convert.ToDouble(lost), 2);
                    double sumLost2 = Math.Round(lost / 7550, 2);
                    double sumLost3 = Math.Round(lost3 / 7550, 2);
                    double sumLost4 = Math.Round(lost4 / 7550, 2);
                    double sumLost5 = Math.Round(lost5 / 7550, 2);
                    ViewBag.list1 = sumLost1;
                    ViewBag.list2 = sumLost2;
                    ViewBag.list3 = sumLost3;
                    ViewBag.list4 = sumLost4;
                    ViewBag.list5 = sumLost5;
                    ViewBag.plan1 = searchSports1;
                    ViewBag.plan2 = searchSports2;
                    ViewBag.plan3 = "Plan3";
                    ViewBag.mess1 = "You will burn " + sumLost1 + " calories this month";
                    ViewBag.mess99 = "Based on this schedule";
                    ViewBag.mess2 = "You will lose " + sumLost2 + " Kg this month, if you keep this schedule";
                    ViewBag.mess3 = "Your current plan:";
                    ViewBag.mess4 = "1. Take part in " + searchSports1 + ", " + frequence1 + " time(s) per week, spend " + duration1 + " hour(s) per session";
                    ViewBag.mess5 = "2. Take part in " + searchSports2 + ", " + frequence2 + " time(s) per week, spend " + duration2 + " hour(s) per session";
                    ViewBag.mess6 = "";
                    ViewBag.messBorder = "border:solid; color: white; border-radius:15px";
                    if (sumLost2 <= 5)
                    {
                        ViewBag.mess7 = "To lose 0-5Kgs in a month, what do I eat?";
                        ViewBag.mess8 = "Breakfast - a portion (20 grams) of protein - eggs, yogurt, smoked salmon + a portion (20 grams) of carbs -a slice of whole grain bread(or) a bowl of whole grain cereal and milk.";
                        ViewBag.mess9 = "Lunch - About two cups of vegetables is highly recommended with a wrap (or) sashimi with a bowl of vegetables.";
                        ViewBag.mess10 = "Dinner - It is essential to note that this should be the lightest meal of the day. So a combination of boiled white fish and salad or a few pieces of chicken with soup would be ideal.";
                    }

                    else
                    {
                        ViewBag.mess7 = "To lose 5-10Kgs in a month, what do I eat?";
                        ViewBag.mess8 = "Breakfast - ½ cup of oatmeal with ½ cup of skim milk, (or) a glass of green tea with an omelette made up of two egg white and a slice of whole grain toast.";
                        ViewBag.mess9 = "Mid morning snack - a bowl of lean fruits.";
                        ViewBag.mess10 = "Lunch - a bowl of vegetable soup with two slices of whole grain bread (or) grilled salmon.";
                    }
                    return View();
                }



                if ((searchSports1 != null && searchSports1 != "" && duration1 != null && duration1 != "" && frequence1 != null && frequence1 != "")
                     && (searchSports2 == null || searchSports2 == "" || duration2 == null || duration2 == "" || frequence2 == null || frequence2 == ""
                     && searchSports3 == null || searchSports3 == "" || duration3 == null || duration3 == "" || frequence3 == null || frequence3 == ""))
                {
                    float lost3 = 0;
                    float lost4 = 0;
                    float lost5 = 0;
                    float newDuration1 = Convert.ToSingle(duration1);

                    float newFrequence1 = Convert.ToSingle(frequence1);

                    
                    
                        for (var i = 0; i < a.Count; i++)
                        {


                            if (b[i].Equals(searchSports1))
                            {

                                float num1 = 125;
                                float num2 = Convert.ToSingle(0.453592);
                                float lost1 = Convert.ToSingle(d[i]);
                                lost3 = lost3 + lost1 / (num1 * num2) * newWeight * newDuration1 * newFrequence1 / 7 * 365 / 12;
                                lost = lost + lost1 / (num1 * num2) * newWeight * newDuration1 * newFrequence1 / 7 * 365 / 12;
                            }
                        }
                        double sumLost1 = Math.Round(Convert.ToDouble(lost), 2);
                        double sumLost2 = Math.Round(lost / 7550, 2);
                        double sumLost3 = Math.Round(lost3 / 7550, 2);
                        double sumLost4 = Math.Round(lost4 / 7550, 2);
                        double sumLost5 = Math.Round(lost5 / 7550, 2);
                        ViewBag.list1 = sumLost1;
                        ViewBag.list2 = sumLost2;
                        ViewBag.list3 = sumLost3;
                        ViewBag.list4 = sumLost4;
                        ViewBag.list5 = sumLost5;
                        ViewBag.plan1 = searchSports1;
                        ViewBag.plan2 = "Plan2";
                        ViewBag.plan3 = "Plan3";
                        
                        ViewBag.mess1 = "You will burn " + sumLost1 + " calories this month";
                        ViewBag.mess99 = "Based on this schedule";
                        ViewBag.mess2 = "You will lose " + sumLost2 + " Kg this month, if you keep this schedule";
                        ViewBag.mess3 = "Your current plan:";
                        ViewBag.mess4 = "1. Take part in " + searchSports1 + ", " + frequence1 + " time(s) per week, spend " + duration1 + " hour(s) per session";
                        ViewBag.mess5 = "";
                        ViewBag.mess6 = "";
                        ViewBag.messBorder = "border:solid; color: white; border-radius:15px";

                    if (sumLost2 <= 5)
                    {
                        ViewBag.mess7 = "To lose 0-5Kgs in a month, what do I eat?";
                        ViewBag.mess8 = "Breakfast - a portion (20 grams) of protein - eggs, yogurt, smoked salmon + a portion (20 grams) of carbs -a slice of whole grain bread(or) a bowl of whole grain cereal and milk.";
                        ViewBag.mess9 = "Lunch - About two cups of vegetables is highly recommended with a wrap (or) sashimi with a bowl of vegetables.";
                        ViewBag.mess10 = "Dinner - It is essential to note that this should be the lightest meal of the day. So a combination of boiled white fish and salad or a few pieces of chicken with soup would be ideal.";
                    }

                    else
                    {
                        ViewBag.mess7 = "To lose 5-10Kgs in a month, what do I eat?";
                        ViewBag.mess8 = "Breakfast - ½ cup of oatmeal with ½ cup of skim milk, (or) a glass of green tea with an omelette made up of two egg white and a slice of whole grain toast.";
                        ViewBag.mess9 = "Mid morning snack - a bowl of lean fruits.";
                        ViewBag.mess10 = "Lunch - a bowl of vegetable soup with two slices of whole grain bread (or) grilled salmon.";
                    }
                    return View();
                    
                }

                


                if ((searchSports1 == null || searchSports1 == "") && (duration1 == null || duration1 == "") && (frequence1 == null || frequence1 == "")
                     && (searchSports2 == null || searchSports2 == "") && (duration2 == null || duration2 == "") && (frequence2 == null || frequence2 == "")
                     && (searchSports3 == null || searchSports3 == "") && (duration3 == null || duration3 == "") && (frequence3 == null || frequence3 == "")
                    )
                {
                    ViewBag.list1 = 0;
                    ViewBag.list2 = 0;
                    ViewBag.list3 = 0;
                    ViewBag.list4 = 0;
                    ViewBag.list5 = 0;
                    ViewBag.plan1 = "Plan1";
                    ViewBag.plan2 = "Plan2";
                    ViewBag.plan3 = "Plan3";
                    ViewBag.mess1 = "";
                    ViewBag.mess2 = "";
                    ViewBag.mess5 = "";
                    ViewBag.mess6 = "";
                    ViewBag.mess3 = "";
                    ViewBag.mess4 = "";
                    ViewBag.mess7 = "";
                    ViewBag.mess8 = "";
                    ViewBag.mess9 = "";
                    ViewBag.mess10 = "";
                    return View();
                }


                



                else
                {
                    ViewBag.list1 = 0;
                    ViewBag.list2 = 0;
                    ViewBag.list3 = 0;
                    ViewBag.list4 = 0;
                    ViewBag.list5 = 0;
                    ViewBag.plan1 = "Plan1";
                    ViewBag.plan2 = "Plan2";
                    ViewBag.plan3 = "Plan3";
                    ViewBag.mess1 = "";
                    ViewBag.mess2 = "the field should not be blank";
                    ViewBag.mess5 = "";
                    ViewBag.mess6 = "";
                    ViewBag.mess3 = "";
                    ViewBag.mess4 = "";
                    ViewBag.mess7 = "";
                    ViewBag.mess8 = "";
                    ViewBag.mess9 = "";
                    ViewBag.mess10 = "";
                    return View();
                }
            }

            else
            {
                ViewBag.list1 = 0;
                ViewBag.list2 = 0;
                ViewBag.list3 = 0;
                ViewBag.list4 = 0;
                ViewBag.list5 = 0;
                ViewBag.plan1 = "Plan1";
                ViewBag.plan2 = "Plan2";
                ViewBag.plan3 = "Plan3";
                ViewBag.mess1 = "";
                ViewBag.mess2 = "please enter your weight";
                ViewBag.mess5 = "";
                ViewBag.mess6 = "";
                ViewBag.mess3 = "";
                ViewBag.mess4 = "";
                ViewBag.mess7 = "";
                ViewBag.mess8 = "";
                ViewBag.mess9 = "";
                ViewBag.mess10 = "";
                return View();
            }

        }
    }
}