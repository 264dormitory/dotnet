using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Http;

namespace api.Controllers
{
    public class CityController : Controller
    {
        // GET api/city
        // todo 跨域问题
        [Route("/City")]
        [HttpGet]
        public JsonResult Get()
        {
            //模拟发送http请求
            string result = "";
            string url    = Connect.CONNECT_INFO + "/City";   
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);  
            req.Method = "GET";  
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();  
            Stream stream = resp.GetResponseStream();  
            //获取内容  
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))  
            {  
                result = reader.ReadToEnd();  
            } 

            //返回json数据
            return Json(result);
        }
    }
}
