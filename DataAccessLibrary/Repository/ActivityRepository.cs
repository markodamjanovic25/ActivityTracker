using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using DataAccessLibrary.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ActivityTrackerDbContext db;

        public ActivityRepository(ActivityTrackerDbContext db)
        {
            this.db = db;
        }

        public async Task Create(Activity a)
        {
            await db.Activities.AddAsync(a);
            await db.SaveChangesAsync();
        }

        public async Task<List<Activity>> GetActivities()
        {
            return await db.Activities
                        .OrderByDescending(a => a.Time)
                        .ToListAsync();
        }

        public async Task<List<ActivityOption>> GetActivityOptions()
        {
            return await db.ActivityOptions.ToListAsync();
        }

        public async Task<ActivityOption> GetActivityOption(int activityOptionId)
        {
            return await db.ActivityOptions
                            .Where(ao => ao.Id == activityOptionId)
                            .SingleAsync();
        }
    }
}
