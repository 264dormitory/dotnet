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
    public class LoginController : Controller
    {
        // GET api/city
        // todo 跨域问题
        [Route("/User/login")]
        [HttpPost]
        public JsonResult Login([FromBody]User value)
        {
            //模拟发送http请求 POST数据
            //将User对象转化为json数据格式
            string result = "";     //定义返回的数据格式

            //定义请求的数据
            byte[] bytes = Encoding.UTF8.GetBytes(value.ToString());

            //定义请求头
            string url    = Connect.CONNECT_INFO + "/User/login";   
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);  
            request.Method = "POST";
            request.ContentLength = bytes.Length;
            request.ContentType = "json";

            //写入请求的数据
            Stream reqstream = request.GetRequestStream();
            reqstream.Write(bytes, 0, bytes.Length);

            HttpWebResponse resp = (HttpWebResponse)request.GetResponse();  
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