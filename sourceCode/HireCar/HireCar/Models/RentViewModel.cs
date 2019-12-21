using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireCar.Models
{
    public class RentViewModel
    {
        public int id { get; set; }
        public string carid { get; set; }
        public Nullable<int> customerid { get; set; }
        public Nullable<int> fee { get; set; }
        public Nullable<System.DateTime> sdate { get; set; }
        public Nullable<System.DateTime> edate { get; set; }
        public string available { get; set; }
    }
}