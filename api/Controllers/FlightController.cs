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

/*
 * 航班Controler
 * API
 */
namespace api.Controllers
{
    public class FlightController : Controller
    {
        //　航班保存
        [Route("/Flight/")]
        [HttpPost]
        public JsonResult Save([FromBody]Flight flight) {
            //模拟发送http请求 POST数据
            //将User对象转化为json数据格式
            //定义请求的数据
            byte[] bytes = Encoding.UTF8.GetBytes(flight.ToString());

            //返回json数据
            return Json(Connect.PostStringResultWithRequestBody("/Fligjt", bytes));
        }

        //　获取查询的航班
        [Route("/Flight/getAllByConditionOfRound/{setOutCityName}/{arriveCityName}/{departureDate}/{arriveDate}")]
        [HttpGet]
        public JsonResult getAllByConditionOfRound(string setOutCityName, string arriveCityName, 
                                                    string departureDate, string arriveDate) {
            //定义返回的参数
            string result = "";
            StringBuilder builder = new StringBuilder();
            builder.Append("/Flight/getAllByConditionOfRound");

            //初始化
            builder.Append("?");

            //添加查出发城市
            builder.Append("&");
            builder.AppendFormat("{0}={1}", "setOutCityName", setOutCityName);

            //添加到达城市
            builder.Append("&");
            builder.AppendFormat("{0}={1}", "arriveCityName", arriveCityName);

            //添加出发日期
            builder.Append("&");
            builder.AppendFormat("{0}={1}", "departureDate", departureDate);

            //添加到达日期
            builder.Append("&");
            builder.AppendFormat("{0}={1}", "arriveDate", arriveDate);

            //定义请求
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(builder.ToString());
            //添加参数
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();

            try　{
                //获取内容
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }

            }　finally　{
                stream.Close();
            }

            //返回Json结果
            return Json(result);
        }
    }
}