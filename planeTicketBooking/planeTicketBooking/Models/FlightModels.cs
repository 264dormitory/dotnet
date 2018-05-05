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
        public String Flight_num { get; set; }  //飞机编号

        public int Plane_id { get; set; }   //航班编号

        public DateTime AirportName { get; set; }  //首站起飞时间

        public DateTime CityName { get; set; }  //预计到达时间
    }
}