using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireCar.Models
{
    public partial class customer
    {
        [MetadataType(typeof(customerMetaData))]
        public class customerMetaData
        {
            [DisplayName("CustomerName")]
            public string customerName { get; set; }
            [DisplayName("Address")]
            public string address { get; set; }
            [DisplayName("Mobile")]
            public Nullable<int> mobile { get; set; }
        }
    }
}