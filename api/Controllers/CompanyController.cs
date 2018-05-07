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
    public class CompanyController : Controller
    {
        // todo 跨域问题
        [Route("/Company")]
        [HttpPost]
        public JsonResult Login([FromBody]Company company) {
            //模拟发送http请求 POST数据
            //将User对象转化为json数据格式
            //定义请求的数据
            byte[] bytes = Encoding.UTF8.GetBytes(company.ToString());

            //返回json数据
            return Json(Connect.PostStringResultWithRequestBody("/Company", bytes));
        }

        //获取所有的航空公司的分页信息
        [Route("/Company/pageAllCompanies")]
        [HttpGet]
        public JsonResult PageAllPlanes() {

            //返回json数据
            return Json(Connect.GetStringResultWithNoParams("/Company/pageAllCompanies"));
        }
    }
}