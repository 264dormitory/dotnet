using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// 高黎明创建
/// 
/// 用于：
/// 1、航班查询的界面
/// </summary>
/// <warning>
namespace planeTicketBooking.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }
    }
}