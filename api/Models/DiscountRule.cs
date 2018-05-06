using System;
using System.Collections.Generic;

namespace api
{
    public class DiscountRule
    {
        public int id;
        public Company company;

        public Double firstClassCabinDiscount;  //头等舱折扣
        
        public Double touristClassDiscount;     //经济舱折扣
        
        public Double sparpreisDiscount;        //特价舱折扣
       
        public string startDate;              //开始日期
        
        public string endDate;

        public DiscountRule() {}
    }
}
