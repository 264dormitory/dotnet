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
/// 1、航空公司信息管理页面
/// 1.2、航线管理
/// 1.3、飞机信息管理
/// 1.4、航空公司信息管理
/// </summary>
/// <warning>
/// 为了辨别方便，创建的控制器的名称应该和页面的一致
/// </warning>
namespace planeTicketBooking.Controllers
{
    public class AirlineCompanyAdminController : Controller
    {
        // GET: 绑定航线信息页面的视图
        public ActionResult AirlineCompanyAdmin()
        {
			AirlineListModels airlineList = new AirlineListModels();
			//建立AirlineModels列表
			List<AirlineModels> airlineArray = new List<AirlineModels>();
			//连接数据库
			MySqlConnection conn = new MySqlConnection();
			conn.ConnectionString = "Server=localhost;Database=ticket;User ID=admin;Password=admin;port=3306;CharSet=utf8;pooling=true;SslMode=None;";
			//获取detail_airline、total_airline、city数据表中的相关数据
			String airlineMsg = String.Format("SELECT total_airline.id,airline_price,city1.city_name,city2.city_name, " +
												"FROM detail_airline, city city1, city city2,total_airline " +
												"WHERE total_airline.set_out_city_id = city1.id " +
												       "AND total_airline.arrive_city_id = city2.id " +
													   "AND detail_airline.total_airline_id = total_airline.id ");
			MySqlCommand comm = new MySqlCommand(airlineMsg, conn);
			//创建和初始化数据适配器DataAdapter
			MySqlDataAdapter airlineAdapter = new MySqlDataAdapter(airlineMsg, conn);
			//创建DataSet对象
			DataSet airlineDataSet = new DataSet();
			try
			{
				conn.Open();
				airlineAdapter.Fill(airlineDataSet, "airline");  //将DataSet起名为airline
															   //使用DataTable来提取DataSet表中的数据
				DataTable airlineDataTable = airlineDataSet.Tables["airline"];
				foreach (DataRow dr in airlineDataTable.Rows)
				{
					foreach (DataColumn dc in airlineDataTable.Columns)
					{
						Console.WriteLine("{0}\t", dr[dc]);
					}
					Console.WriteLine();
				}


				//将DataTable中的数据赋值到List之中
				for (int row = 0; row < airlineDataTable.Rows.Count; row++)
				{
					AirlineModels airline = new AirlineModels();
					airline.Airline_id = Convert.ToInt16(airlineDataTable.Rows[row]["detail_airline.id"]); //航线ID
					airline.Airline_price = Convert.ToInt16(airlineDataTable.Rows[row]["airLine_price"]); //航线价格
					airline.Departure_city = airlineDataTable.Rows[row]["city1.city_name"].ToString();//出发城市
					airline.Arrive_city = airlineDataTable.Rows[row]["city2.city_name"].ToString();//到达城市
					airlineArray.Add(airline);
				}
			}
			catch (Exception ex)
			{
				Response.Write(ex.Message);
			}
			finally
			{
				airlineList.AirlineModelsArray = airlineArray;
				conn.Close();
			}
			return View(airlineList);
			/// <summary>
			/// 用于添加城市信息数据
			/// </summary>
			/*[HttpPost]
			public string AddAirlineMsg(int flight_id, string flight_num,DateTime departure_time,DateTime arrive_time,String departureCity,String arriveCity,String flightCompanyName)
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
			public string ChangeAirlineMsg(int flight_id, string flight_num, DateTime departure_time, DateTime arrive_time, String departureCity, String arriveCity, String flightCompanyName)
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
			public string DeleteAirlineMsg(int flight_id, string flight_num, DateTime departure_time, DateTime arrive_time, String departureCity, String arriveCity, String flightCompanyName)
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
}