using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// 航班信息管理
/// </summary>
namespace planeTicketBooking.Models
{
    public class FlightModels
    {
        public int Flight_id { get; set; }   //航班ID

        public int detail_airlineid { get; set; }  //ID1

        public String Flight_num { get; set; }  //航班号

        public DateTime Departure_time { get; set; }  //出发时间

        public DateTime Arrive_time { get; set; }  //到达时间

        public String Departure_city { get; set; }  //出发城市

        public String Arrive_city { get; set; }  //到达城市

        public String FlightCompany_name { get; set; }  //公司名称
    }
}