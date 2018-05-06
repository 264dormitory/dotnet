using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace api.Controllers
{
    public class UserController : Controller
    {
        // todo 跨域问题
        [Route("/User/login")]
        [HttpPost]
        public JsonResult Login([FromBody]User value) {
            //模拟发送http请求 POST数据
            //将User对象转化为json数据格式
            //定义请求的数据
            byte[] bytes = Encoding.UTF8.GetBytes(value.ToString());

            //返回json数据
            return Json(Connect.PostStringResultWithRequestBody("/User/login", bytes));
        }

        //获取所有订单
        [Route("/User/getAllOrders")]
        [HttpGet]
        public JsonResult getAllOrders() {

            //返回json数据
            return Json(Connect.GetStringResultWithNoParams("/User/getAllOrders"));
        }

        //登出功能
        [Route("/User/logout")]
        [HttpGet]
        public JsonResult Logout() {
            
            //返回json数据
            return Json(Connect.GetStringResultWithNoParams("/User/logout"));          
        }

        //获取当前登录用户
        [Route("/User/getCurrentUser")]
        [HttpGet]
        public JsonResult GetCurrentUser() {
            return Json(Connect.GetStringResultWithNoParams("/User/getCurrentUser"));
        }

        //注册功能
        [Route("/User")]
        [HttpPost]
        public JsonResult Registered([FromBody]User value) {
            //将User对象转化为json数据格式
            //定义请求的数据
            byte[] bytes = Encoding.UTF8.GetBytes(value.ToString());

            //返回json数据
            return Json(Connect.PostStringResultWithRequestBody("/User", bytes));
        }

        //获取当前登录用户的所有乘客信息
        [Route("/User/getAllPassengers")]
        [HttpGet]
        public JsonResult GetAllPassengers() {
            return Json(Connect.GetStringResultWithNoParams("/User/getAllPassengers"));
        }
    }
}