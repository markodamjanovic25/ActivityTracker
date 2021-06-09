using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string UserName { get; set; } // name of user that completed activity
        public DateTime Time { get; set; }
        public int ActivityOptionId { get; set; }
        public ActivityOption ActivityOption { get; set; }
    }
}
