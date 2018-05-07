using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// 航线信息管理
/// </summary>
namespace planeTicketBooking.Models
{
	public class AirlineModels
	{
		public int Airline_id { get; set; }  //航线编号

		public string Departure_city { get; set; }  //出发城市

		public string Arrive_city { get; set; }  //到达城市

		public int Airline_price { get; set; }  //航线价格
	}
}