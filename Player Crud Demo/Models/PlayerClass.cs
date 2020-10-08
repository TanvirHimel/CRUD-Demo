using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Player_Crud_Demo.Models
{
    public class PlayerClass
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}