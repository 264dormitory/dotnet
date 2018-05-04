using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace planeTicketBooking.Models
{
    public class City
    {
        public int CityId { get; set; }  //城市编号

        public string AirportName { get; set; }  //机场名称

        public string CityName { get; set; }  //城市名称
    }
}