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
    public class PlaneController : Controller
    {
        //获取所有的飞机信息的分页信息
        [Route("/Plane/pageAllPlanes")]
        [HttpGet]
        public JsonResult PageAllPlanes() {

            //返回json数据
            return Json(Connect.GetStringResultWithNoParams("/Plane/pageAllPlanes"));
        }

        // 删除飞机
        [Route("/Plane/{id}")]
        [HttpDelete]
        public JsonResult Delete(int id) {
            //返回json数据
            return Json(Connect.GetStringResultWithNoParams("/Plane/" + id));
        }

        //保存飞机实体
        [Route("/Plane")]
        [HttpPost]
        public JsonResult save([FromBody] Plane plane) {
            //模拟发送http请求 POST数据
            //将User对象转化为json数据格式
            //定义请求的数据
            byte[] bytes = Encoding.UTF8.GetBytes(plane.ToString());

            //返回json数据
            return Json(Connect.PostStringResultWithRequestBody("/Plane", bytes));
        }
    }
}