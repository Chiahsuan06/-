using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 動態問卷系統.Models
{
    public class UserInformation
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

    }
}