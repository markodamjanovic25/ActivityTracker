using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTrackerUI.ViewModels
{
    public class ActivityViewModel
    {
        public string UserName { get; set; }
        public int ActivityOptionId { get; set; }
        public List<ActivityOption> ActivityOptions { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
