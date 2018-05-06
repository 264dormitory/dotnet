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
    public class OrdersController : Controller
    {
        // todo 跨域问题
        [Route("/Orders/{id}")]
        [HttpDelete]
        public JsonResult Delete(int id) {

            //返回json数据
            return Json(Connect.DeleteStringResultWithId("/Orders/" + id));
        }

        // 下订单
        [Route("/Orders")]
        [HttpPost]
        public JsonResult Save([FromBody] Orders orders) {
            //将User对象转化为json数据格式
            //定义请求的数据
            byte[] bytes = Encoding.UTF8.GetBytes(orders.ToString());

            //返回json数据
            return Json(Connect.PostStringResultWithRequestBody("/Orders", bytes));
        }

        // 退订单
        [Route("/Orders/deleteOfPay/{id}")]
        [HttpDelete]
        public JsonResult DeleteOfPay(int id) {
            return Json(Connect.DeleteStringResultWithId("/Orders/deleteOfPay/" + id));
        }

        // 订单支付
        [Route("/Orders/pay/{id}")]
        [HttpGet]
        public JsonResult Pay(int id) {
            return Json(Connect.DeleteStringResultWithId("/Orders/pay/" + id));
        }
    }
}