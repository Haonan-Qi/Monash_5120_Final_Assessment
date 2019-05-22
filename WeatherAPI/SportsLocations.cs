using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherAPI
{
    public class SportsLocations
    {

        public SportsLocations() { }

        public SportsLocations(string str1, string str2, string str3, string str4, string str5, string str6, string str7, string str8, string str9, string str10) {
            this.condition = str1;
            this.id = str2;
            this.latitude = str3;
            this.lgy = str4;
            this.longtitude = str5;
            this.name = str6;
            this.postCode = str7;
            this.sports = str8;
            this.streetName = str9;
            this.streetType = str10;
            
        }

        public string condition;
        public string id;
        public string latitude;
        public string lgy;
        public string longtitude;
        public string name;
        public string postCode;
        public string sports;
        public string streetName;
        public string streetType;

    }

     
}