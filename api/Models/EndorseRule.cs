using System;
using System.Collections.Generic;

namespace api
{
    public class EndorseRule
    {
        public int id;
        public Company company;

        public Double touristClassMoney;        //经济舱手续费用
       
        public string ruleExplain;              //规则说明

        public EndorseRule() {}
    }
}