using System;
using System.Collections.Generic;

namespace api
{
    public class Flight
    {
    private int id;

    private Plane plane;             //关联飞机

    private FreeTicketRule freeTicketRule;   //退票规则


    private DiscountRule discountRule;       //折扣规则

    private EndorseRule endorseRule;         //改签规则


    public string flightNum;                 //航班编号



        public Flight() {}
    }
}
