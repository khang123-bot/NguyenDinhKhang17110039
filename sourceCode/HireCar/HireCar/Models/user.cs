//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HireCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public partial class user
    {
        public int id { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage ="This field is required to complete")]
        public string name { get; set; }
        public string username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required to complete")]
        public string password { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}