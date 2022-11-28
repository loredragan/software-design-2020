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
    public partial class ChatMessage : BaseModel
    {
        public int id { get; set; }
        public int fromUserID { get; set; }
        public string fromUserName { get; set; }
        public int userID { get; set; }
        public string content { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ChatMessage);
        }

        public bool Equals(ChatMessage other)
        {
            return other != null &&
                   this.id == other.id &&
                   this.fromUserName.Equals(other.fromUserName) &&
                   this.fromUserID ==  other.fromUserID &&
                   this.content.Equals(other.content) &&
                   this.userID == other.userID;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
