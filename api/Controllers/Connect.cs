using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Http;


namespace api{
    class Connect {
        public static String CONNECT_INFO = "http://localhost:8080";       //定义后台数据库连接

        /**
         * 根据请求获取GET请求返回的数据
         * get请求中没有参数
         */
        public static string GetStringResultWithNoParams(string route) {
            //定义返回的数据
            string result = "";

            //定义请求头
            string url    = Connect.CONNECT_INFO + route;   
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);  
            request.Method = "GET";
            request.ContentType = "json";

            //获取内容
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))  
            {  
                result = reader.ReadToEnd();  
            } 

            //返回json数据
            return result;
        }
        
        public static string DeleteStringResultWithId(string route) {
            //定义返回的数据
            string result = "";

            //定义请求头
            string url    = Connect.CONNECT_INFO + route;   
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);  
            request.Method = "DELETE";
            request.ContentType = "json";

            //获取内容
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))  
            {  
                result = reader.ReadToEnd();  
            } 

            //返回json数据
            return result;
        }

        /**
         * 根据POST绑定实体返回信息
         */
        public static string PostStringResultWithRequestBody(string route, byte[] data) {
            //定义返回数据
            string result ="";

            //定义请求头
            string url    = Connect.CONNECT_INFO + route;   
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);  
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "json";

            //写入请求的数据
            Stream reqstream = request.GetRequestStream();
            reqstream.Write(data, 0, data.Length);

            HttpWebResponse resp = (HttpWebResponse)request.GetResponse();  
            Stream stream = resp.GetResponseStream();  
            //获取内容  
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))  
            {  
                result = reader.ReadToEnd();  
            }

            return result;
        }
    }
}