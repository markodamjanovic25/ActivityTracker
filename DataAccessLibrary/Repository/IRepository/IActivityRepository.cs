using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Repository.IRepository
{
    public interface IActivityRepository
    {
        Task Create(Activity a);
        Task<List<Activity>> GetActivities();
        Task<List<ActivityOption>> GetActivityOptions();
        Task<ActivityOption> GetActivityOption(int activityOptionId);
    }
}
