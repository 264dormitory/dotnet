using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using planeTicketBooking.Models;
/// <summary>
/// 李世杰创建
/// 
/// 用于：
/// 1、机场信息管理页面
/// 1.1、机场名称设置
/// </summary>
/// <warning>
/// 为了辨别方便，创建的控制器的名称应该和页面的一致
/// </warning>
namespace planeTicketBooking.Controllers
{
    public class AirportAdminController : Controller
    {
        // GET: 绑定机场名称设置页面的视图
        public ActionResult airportname_set()
        {
            City city = new City();
            city.CityId = 1;
            city.CityName = "北京市";
            city.AirportName = "首都T2机场";
            ViewData["city"] = city;
            return View();
        }
    }
}