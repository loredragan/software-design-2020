//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment_3.Models
{
    using System;
    using System.Collections.Generic;
    [Serializable]
    public partial class Favorite : BaseModel
    {
        public int id { get; set; }
        public int userID { get; set; }
        public int adID { get; set; }
        public int ownerID { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Favorite);
        }

        public bool Equals(Favorite other)
        {
            return other != null &&
                   this.id == other.id &&
                   this.userID == other.userID &&
                   this.adID == other.adID &&
                   this.ownerID == other.ownerID;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
