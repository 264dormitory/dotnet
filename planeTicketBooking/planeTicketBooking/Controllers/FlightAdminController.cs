using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using planeTicketBooking.Models;
using System.Data;
using MySql.Data.MySqlClient;  //导入连接使用MySQL数据库所必须的命名空间
/// <summary>
/// 
/// 用于：
/// 1、航班信息管理页面
/// 1.1、航班信息管理
/// 1.2、折扣、退票、改签规则管理
/// </summary>
/// <warning>
/// 为了辨别方便，创建的控制器的名称应该和页面的一致
/// </warning>
namespace planeTicketBooking.Controllers
{
    public class FlightAdminController : Controller
    {
        // GET: 绑定航班信息管理页面的视图
        public ActionResult FlightInfo()
        {
            FlightListModels flightList = new FlightListModels();
            //建立FlightModel列表
            List<FlightModels> flightArray = new List<FlightModels>();
            //连接数据库
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server=localhost;Database=ticket;User ID=admin;Password=admin;port=3306;CharSet=utf8;pooling=true;SslMode=None;";
            //获取flight、detail_airline、plane、company、total_airline、city数据表中的相关数据
            String flightMsg = String.Format("SELECT flight.id,flight_num,departure_time,arrive_time,city1.city_name,city2.city_name,company.company_name FROM flight, detail_airline, city city1, city city2, company, plane, total_airline WHERE flight.id = detail_airline.flight_id AND detail_airline.total_airline_id = total_airline.id AND total_airline.set_out_city_id = city1.id AND total_airline.arrive_city_id = city2.id AND flight.plane_id = plane.id AND plane.company_id = company.id; ");
            MySqlCommand comm = new MySqlCommand(flightMsg, conn);
            //创建和初始化数据适配器DataAdapter
            MySqlDataAdapter flightAdapter = new MySqlDataAdapter(flightMsg, conn);
            //创建DataSet对象
            DataSet flightDataSet = new DataSet();
            try
            {
                conn.Open();
                flightAdapter.Fill(flightDataSet, "flight");  //将DataSet起名为flight
                //使用DataTable来提取DataSet表中的数据
                DataTable flightDataTable = flightDataSet.Tables["flight"];
                foreach(DataRow dr in flightDataTable.Rows)
                {
                     foreach(DataColumn dc in flightDataTable.Columns)
                                    {
                                        Console.WriteLine("{0}\t",dr[dc]);
                                    }
                    Console.WriteLine();
                }
               

                //将DataTable中的数据赋值到List之中
                for (int row = 0; row < flightDataTable.Rows.Count; row++)
                {
                    FlightModels flight = new FlightModels();
                    flight.Flight_id = Convert.ToInt16(flightDataTable.Rows[row]["flight_id"]); //航班ID
                    flight.Flight_num = flightDataTable.Rows[row]["flight_num"].ToString();//航班号
                    flight.Departure_time = Convert.ToDateTime(flightDataTable.Rows[row]["departure_time"]);//出发时间
                    flight.Arrive_time = Convert.ToDateTime(flightDataTable.Rows[row]["arrive_time"]);//到达时间
                    flight.Departure_city = flightDataTable.Rows[row]["city1.city_name"].ToString();//出发城市
                    flight.Arrive_city = flightDataTable.Rows[row]["city2.city_name"].ToString();//到达城市
                    flight.FlightCompany_name = flightDataTable.Rows[row]["company.company_name"].ToString();//公司名称
                    flightArray.Add(flight);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                flightList.FlightModelsArray = flightArray;
                conn.Close();
            }
            return View(flightList);
        }

        /// <summary>
        /// 用于添加城市信息数据
        /// </summary>
        /*[HttpPost]
        public string AddFlightMsg(int flight_id, string flight_num,DateTime departure_time,DateTime arrive_time,String departureCity,String arriveCity,String flightCompanyName)
        {
            FlightListModels flightList = new FlightListModels();
            //建立Flight Model列表
            List<FlightModels> flightArray = new List<FlightModels>();
            //连接数据库
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server=localhost;Database=ticket;User ID=admin;Password=admin;port=3306;CharSet=utf8;pooling=true;SslMode=None;";
            //获取City数据表中的所有数据
            string add = String.Format("insert into city (airport_name, city_name) values (\'{0}\', \'{1}\')", airportname, cityname);
            MySqlCommand comm = new MySqlCommand(add, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return "数据新增成功";
        }
        /// <summary>
        /// 用于修改城市信息数据
        /// </summary>
        [HttpPost]
        public string ChangeFlightMsg(int flight_id, string flight_num, DateTime departure_time, DateTime arrive_time, String departureCity, String arriveCity, String flightCompanyName)
        {
            FlightListModels flightList = new FlightListModels();
            //建立Flight Model列表
            List<FlightModels> flightArray = new List<FlightModels>();
            //连接数据库
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server=localhost;Database=ticket;User ID=admin;Password=admin;port=3306;CharSet=utf8;pooling=true;SslMode=None;";
            //获取City数据表中的所有数据
            string change = String.Format("update city set airport_name = \'{1}\' where id = \'{0}\'", airportID, airportName);
            MySqlCommand comm = new MySqlCommand(change, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return "数据修改成功";
        }

        /// <summary>
        /// 用于删除城市信息数据
        /// </summary>
        [HttpPost]
        public string DeleteFlightMsg(int flight_id, string flight_num, DateTime departure_time, DateTime arrive_time, String departureCity, String arriveCity, String flightCompanyName)
        {
            FlightListModels flightList = new FlightListModels();
            //建立Flight Model列表
            List<FlightModels> flightArray = new List<FlightModels>();
            //连接数据库
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server=localhost;Database=ticket;User ID=admin;Password=admin;port=3306;CharSet=utf8;pooling=true;SslMode=None;";
            //获取City数据表中的所有数据
            string delete = String.Format("delete from city where id = \'{0}\'", airportID);
            MySqlCommand comm = new MySqlCommand(delete, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return "数据删除成功";
        }*/
    }
}