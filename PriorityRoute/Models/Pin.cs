using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms.Maps;

namespace PriorityRoute.Models
{
    [Table("Pin")]
    public class Pin
    {
        [PrimaryKey, AutoIncrement]
        public int ID {get; set;}
        public int CompanyID {get; set;}
        public int Status {get; set;}
        public String Name {get; set;}
        public String Latitude {get; set;}
        public String Longitude {get; set;}
        public String Label {get; set;}
        public String Type {get; set;}

        public Position location;

        public Pin()
        {
            double lat = Convert.ToDouble(this.Latitude);
            double lon = Convert.ToDouble(this.Longitude);
            this.location = new Position(lat, lon);
        }
    }
}