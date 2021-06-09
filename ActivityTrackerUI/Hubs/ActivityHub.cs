using DataAccessLibrary.Models;
using DataAccessLibrary.Repository.IRepository;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTrackerUI.Hubs
{
    public class ActivityHub : Hub
    {
        private readonly IActivityRepository activityRepository;
        public ActivityHub(IActivityRepository activityRepository)
        {
            this.activityRepository = activityRepository;
        }
        public async Task SendActivity(string userName, int activityOptionId)
        {
            Activity a = new Activity() { UserName = userName, ActivityOption = await activityRepository.GetActivityOption(activityOptionId) };
            await Clients.All.SendAsync("ReceiveActivity", a);
            await activityRepository.Create(a);
        }
    }
}
