using ActivityTrackerUI.Hubs;
using ActivityTrackerUI.ViewModels;
using DataAccessLibrary.Models;
using DataAccessLibrary.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTrackerUI.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityRepository activityRepository;
        public ActivityViewModel viewModel;
        public ActivityController(IActivityRepository activityRepository)
        {
            this.activityRepository = activityRepository;
            viewModel = new ActivityViewModel();
        }

        public async Task<IActionResult> PopulateViewModel()
        {
            viewModel.Activities = await activityRepository.GetActivities();
            viewModel.ActivityOptions = await activityRepository.GetActivityOptions();
            return View("Index", viewModel);
        }

        public async Task<IActionResult> Index()
        {
            return await PopulateViewModel();
        }

    }
}
