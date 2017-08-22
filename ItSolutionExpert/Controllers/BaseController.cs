using ItSolutionExpert.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItSolutionExpert.Controllers
{
    public class BaseController : Controller
    {
        protected DataContext _dataContext;
        public BaseController()
        {
            _dataContext = new DataContext();
        }
        protected override void Dispose(bool disposing)
        {
            _dataContext.Dispose();
            base.Dispose(disposing);
        }
    }
}