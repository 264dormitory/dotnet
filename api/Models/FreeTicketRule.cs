using System;
using System.Collections.Generic;

namespace api
{
    public class FreeTicketRule
    {
        public int id;
        private Company company;                   //关联航空公司
        private Double firstClassCabinScale;       //头等舱退钱比例
        private Double touristClassScale;          //经济舱退钱比例
        private String ruleExplain;                //规则说明

        public FreeTicketRule() {}
    }
}
