using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using planeTicketBooking.Models;
using System.Data;
using MySql.Data.MySqlClient;  //导入连接使用MySQL数据库所必须的命名空间
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
            CityListModels cityList = new CityListModels();
            //建立City Model列表
            List<City> cityArray = new List<City>();
            //连接数据库
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server=localhost;Database=ticket;User ID=admin;Password=admin;port=3306;CharSet=utf8;pooling=true;SslMode=None;";
            //获取City数据表中的所有数据
            string cityMsg = String.Format("select * from city");
            MySqlCommand comm = new MySqlCommand(cityMsg, conn);
            //创建和初始化数据适配器DataAdapter
            MySqlDataAdapter cityAdapter = new MySqlDataAdapter(cityMsg, conn);
            //创建DataSet对象
            DataSet cityDataSet = new DataSet();
            try
            {
                conn.Open();
                cityAdapter.Fill(cityDataSet, "city");  //将DataSet起名为city
                //使用DataTable来提取DataSet表中的数据
                DataTable cityDataTable = cityDataSet.Tables["city"];
                
                //将DataTable中的数据赋值到List之中
                for (int row = 0; row < cityDataTable.Rows.Count; row++)
                {
                    City city = new City();
                    city.CityId = Convert.ToInt16(cityDataTable.Rows[row]["id"]);
                    city.CityName = cityDataTable.Rows[row]["city_name"].ToString();
                    city.AirportName = cityDataTable.Rows[row]["airport_name"].ToString();
                    cityArray.Add(city);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                cityList.CityArray = cityArray;
                conn.Close();
            }
            return View(cityList);
        }

        //用于实现数据库删除
        public void delete()
        {

        }
    }
}