using Microsoft.AspNetCore.Mvc;
using PlayBall.GroupMangement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayBall.GroupMangement.Web.Controllers
{


    [Route("groups")]
    public class GroupsController: Controller
    {


        private static long currentGroupId = 1;
        private static List<GroupViewModel> groups = new List<GroupViewModel>
        { new GroupViewModel { Id = 1, Name = "Awesome group" } };


        [HttpGet]
        [Route("")]// dont need becouse of index would be use by default anyway
        public IActionResult Index()
        {
            return View(groups);
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult Details(long Id)
        {
            var group = groups.SingleOrDefault(g => g.Id == Id);

            if(group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        [HttpPost]
        [Route("{Id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long Id, GroupViewModel model)
        {
            var group = groups.SingleOrDefault(g => g.Id == Id);

            if (group == null)
            {
                return NotFound();
            }

            group.Name = model.Name;

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateReally(GroupViewModel Model)
        {
            Model.Id = ++currentGroupId;
            groups.Add(Model);

            return RedirectToAction("Index");
        }
    }
}
                                    