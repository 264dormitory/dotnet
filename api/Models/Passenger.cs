using System;
using System.Collections.Generic;

namespace api
{
    public class Passenger
    {
        public int id;
        public User user;

        public String identity;                //身份证信息
        public String name;                    //乘客姓名
        public String phoneNum;                //联系人手机号
        public String type;                    //乘客类型

        public Passenger() {}
    }
}
