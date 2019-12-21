using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireCar.Models
{
    public partial class car
    {
        [MetadataType(typeof(carMetaData))]
        public class carMetaData
        {
            [DisplayName("CarNumber")]
            public string carNumber { get; set; }
            [DisplayName("Make")]
            public string make { get; set; }
            [DisplayName("Model")]
            public string model { get; set; }
            [DisplayName("Available")]
            public string available { get; set; }
        }
    }
}