//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    
    [Serializable]
    public partial class Ad: BaseModel
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string location { get; set; }
        public double size { get; set; }
        public double price { get; set; }
        public System.DateTime createdAt { get; set; }
    }
}
