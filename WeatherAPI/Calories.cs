using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherAPI
{
    public class Calories
    {

        public Calories() { }

        public Calories(string str1, string str2, string str3, string str4) {
            this.id = str1;
            this.name = str2;
            this.mets = str3;
            this.lbs = str4;
            
        }

        public string name;
        public string id;
        public string mets;
        public string lbs;

    }

     
}