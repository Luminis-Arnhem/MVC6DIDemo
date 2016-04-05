using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using DIDemo.ExampleClasses;
using Microsoft.Data.Entity.Metadata.Internal;
using DIDemo.Models;
using DIDemo.Services;

namespace DIDemo.Controllers
{
    public class HomeController : Controller
    {
        private ITransientDependencyExample _transientDependencyExample;
        private IScopedDependencyExample _scopedDependencyExample;
        private ISingletonDependencyExample _singletonDependencyExample;
        private IInstanceDependencyExample _instanceDependencyExample;
        private IDemoService _demoService;

        public HomeController(ITransientDependencyExample transientDependencyExample, 
                              IScopedDependencyExample scopedDependencyExample,
                              ISingletonDependencyExample singletonDependencyExample,
                              IInstanceDependencyExample instanceDependencyExample,
                              IDemoService demoService)
        {
            _transientDependencyExample = transientDependencyExample;
            _scopedDependencyExample = scopedDependencyExample;
            _singletonDependencyExample = singletonDependencyExample;
            _instanceDependencyExample = instanceDependencyExample;
            _demoService = demoService;
        }

        public IActionResult Index()
        {
            List<DemoModel> list = new List<DemoModel>();
            list.Add(new DemoModel()
            {
                Name = "Transient",
                FirstCall = _transientDependencyExample.ID.ToString(),
                SecondCall = _demoService.GetIDFromTransientDependency(),
            });
            list.Add(new DemoModel()
            {
                Name = "Scoped",
                FirstCall = _scopedDependencyExample.ID.ToString(),
                SecondCall = _demoService.GetIDFromScopedDependency(),
            });
            list.Add(new DemoModel()
            {
                Name = "Singleton",
                FirstCall = _singletonDependencyExample.ID.ToString(),
                SecondCall = _demoService.GetIDFromSingletonDependency(),
            });
            list.Add(new DemoModel()
            {
                Name = "Instance",
                FirstCall = _instanceDependencyExample.ID.ToString(),
                SecondCall = _demoService.GetIDFromInstanceDependency(),
            });
            return View(list);
        }

        public IActionResult About([FromServices] ITransientDependencyExample transientDependencyExample)
        {
            ViewData["Message"] = "Your application description page.";
            ViewBag.ID = transientDependencyExample.ID;
            return View();
        }
    }
}
