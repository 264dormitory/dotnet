using System;
using System.Collections.Generic;

namespace api
{
    public class Orders
    {
        public int id;

        public User user;                      //关联用户

        public Boolean status = false;         //订单状态 0出行　１未出行

        public Boolean isPay  = false;         //是否支付

        public Boolean isBackTicket = false;   //是否退票

        public Double totalPrice;              //总订单价格

        public string orderDate;             //订单日期

        public string payDate;               //支付日期

        public HashSet<Lineitem> lineitems;      //关联订单明细

        public Orders() {}
    }
}
