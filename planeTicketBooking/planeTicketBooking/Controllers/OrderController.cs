using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/// <summary>
///韩瑞峰修改18.5.6
/// 
/// 用于：
/// 1、订单填写页面
/// 2、用户订单查看页面
/// </summary>
/// <warning>
/// 为了辨别方便，创建的控制器的名称应该和页面的一致
/// </warning>
namespace planeTicketBooking.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult order()
        {
            return View();
        }
    }
    public class OrderFullController : Controller
    {
        // GET: Order
        public ActionResult orderfull()
        {
            return View();
        }
    }
}