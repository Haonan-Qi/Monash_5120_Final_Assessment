using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherAPI
{
    public class Introduction
    {

        public Introduction() { }

        public Introduction(string str1, string str2, string str3, string str4, string str5) {
            this.name = str1;
            this.time = str2;
            this.structure = str3;
            this.number = str4;
            this.source = str5;
            
        }

        public string name;
        public string time;
        public string structure;
        public string number;
        public string source;

    }

     
}