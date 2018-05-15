$(window).load(function () {
    $('body').addClass('loaded');
    /* 设置页数全局变量 */
    var page_number = 0;
    var page_lenght = 5;

    //用于动态生成下拉列表
    var listBind = new Vue({
        el: '#filter-list',
        data:
            {
                flightlist: ""
            },
        methods: {
            listInit: function () {
                /* 用于获取航班信息 */
                var setout = jQuery.url.param("setout");
                var destination = jQuery.url.param("destination");
                var setout_date = jQuery.url.param("setout_date");
                var return_date = jQuery.url.param("return_date");
                var type = jQuery.url.param("type");
                if (type == "single") {
                    var jsondata = {
                        page: 0,
                        size: 1000,
                        setOutCityName: setout,
                        arriveCityName: destination,
                        departureDate: setout_date
                    };
                    console.log(jsondata);
                    jQuery.ajax({
                        url: 'http://localhost:8081/Flight/getAllByCondition',  //向后台传输数据
                        type: 'get',
                        contentType: 'application/json;charset=UTF-8',
                        data: jsondata,
                        dataType: "json",
                        success: function (data) {
                            listBind.flightlist = data.content;
                            console.log(listBind.flightlist);
                        },
                        error: function (data) {
                            console.log(data.responseJSON.message);
                        }
                    });
                }
                else {

                }
            }
        }
    })
    listBind.listInit();

    var page = new Vue({
        el: '#page-control',
        data:
            {
                pagemessage: "",
                currentpage: 1,
                totalpage: ""
            },
        methods:
            {
                /* 向后翻页 */
                pageTurn: function () {
                    /* 用于获取航班信息 */
                    if (page.currentpage < page.totalpage) {
                        page_number = page_number + 1;
                        page.currentpage = page.currentpage + 1;
                        var setout = jQuery.url.param("setout");
                        var destination = jQuery.url.param("destination");
                        var setout_date = jQuery.url.param("setout_date");
                        var return_date = jQuery.url.param("return_date");
                        var type = jQuery.url.param("type");
                        if (type == "single") {
                            var jsondata = {
                                page: page_number,
                                size: page_lenght,
                                setOutCityName: setout,
                                arriveCityName: destination,
                                departureDate: setout_date
                            };
                            console.log(jsondata);
                            jQuery.ajax({
                                url: 'http://localhost:8081/Flight/getAllByCondition',  //向后台传输数据
                                type: 'get',
                                contentType: 'application/json;charset=UTF-8',
                                data: jsondata,
                                dataType: "json",
                                success: function (data) {
                                    console.log(data);
                                    page.pagemessage = data.content;
                                    console.log();
                                    flightshow.$data.flightlist = page.pagemessage;
                                    var i, j;
                                    for (i = 0; i < page.pagemessage.length; i++) {
                                        for (j = 0; j < 1; j++) {
                                            flightshow.flightlist[i][j].arriveTime = flightshow.flightlist[i][j].arriveTime.substring(11, 16);
                                            flightshow.flightlist[i][j].departureTime = flightshow.flightlist[i][j].departureTime.substring(11, 16);
                                            console.log(flightshow.flightlist[i][j].arriveTime);
                                            if (flightshow.flightlist[i][j].sparpreisTicket == null) {
                                                flightshow.flightlist[i][j].sparpreisTicket = { ticketPrice: "售罄" };
                                            }
                                            if (flightshow.flightlist[0][0].firstClassCabinTicket == null) {
                                                flightshow.flightlist[i][j].firstClassCabinTicket = { ticketPrice: "售罄" };
                                            }
                                            if (flightshow.flightlist[0][0].touristClassTicket == null) {
                                                flightshow.flightlist[i][j].touristClassTicket = { ticketPrice: "售罄" };
                                            }
                                            switch (flightshow.flightlist[i][j].plane.company.companyName) {
                                                case "海南航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.hainan;
                                                    break;
                                                case "祥鹏航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.xiangpeng;
                                                    break;
                                                case "联合航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.lianhe;
                                                    break;
                                                case "南方航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.nanfang;
                                                    break;
                                                case "中国航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.zhongguo;
                                                    break;
                                                case "东方航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.dongfang;
                                                    break;
                                                case "四川航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.sichuan;
                                                    break;
                                                case "深圳航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.shenzhen;
                                                    break;
                                                case "华夏航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.huaxia;
                                                    break;
                                                default:
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.zhongguo;
                                                    break;
                                            }
                                        }
                                    }
                                },
                                error: function (data) {
                                    console.log(data.responseJSON.message);

                                }
                            });
                        }
                        else {

                        }
                    }
                    else {
                        //alert("已经是最后一页了！");
                        swal({
                            text: "已经是最后一页了！",
                            type: "info",
                            confirmButtonText: "确定"
                        });
                    }
                },
                /* 向前翻页 */
                pageReturn: function () {
                    if (page.currentpage != 1) {
                        /* 用于获取航班信息 */
                        page_number = page_number - 1;
                        page.currentpage = page.currentpage - 1;
                        var setout = jQuery.url.param("setout");
                        var destination = jQuery.url.param("destination");
                        var setout_date = jQuery.url.param("setout_date");
                        var return_date = jQuery.url.param("return_date");
                        var type = jQuery.url.param("type");
                        console.log(page.currentpage);
                        if (type == "single") {
                            var jsondata = {
                                page: page_number,
                                size: page_lenght,
                                setOutCityName: setout,
                                arriveCityName: destination,
                                departureDate: setout_date
                            };
                            console.log(jsondata);
                            jQuery.ajax({
                                url: 'http://localhost:8081/Flight/getAllByCondition',  //向后台传输数据
                                type: 'get',
                                contentType: 'application/json;charset=UTF-8',
                                data: jsondata,
                                dataType: "json",
                                success: function (data) {
                                    console.log(data);
                                    page.pagemessage = data.content;
                                    flightshow.$data.flightlist = page.pagemessage;
                                    var i, j;
                                    for (i = 0; i < page.pagemessage.length; i++) {
                                        for (j = 0; j < 1; j++) {
                                            flightshow.flightlist[i][j].arriveTime = flightshow.flightlist[i][j].arriveTime.substring(11, 16);
                                            flightshow.flightlist[i][j].departureTime = flightshow.flightlist[i][j].departureTime.substring(11, 16);
                                            console.log(flightshow.flightlist[i][j].arriveTime);
                                            if (flightshow.flightlist[i][j].sparpreisTicket == null) {
                                                flightshow.flightlist[i][j].sparpreisTicket = { ticketPrice: "售罄" };
                                            }
                                            if (flightshow.flightlist[0][0].firstClassCabinTicket == null) {
                                                flightshow.flightlist[i][j].firstClassCabinTicket = { ticketPrice: "售罄" };
                                            }
                                            if (flightshow.flightlist[0][0].touristClassTicket == null) {
                                                flightshow.flightlist[i][j].touristClassTicket = { ticketPrice: "售罄" };
                                            }
                                            switch (flightshow.flightlist[i][j].plane.company.companyName) {
                                                case "海南航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.hainan;
                                                    break;
                                                case "祥鹏航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.xiangpeng;
                                                    break;
                                                case "联合航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.lianhe;
                                                    break;
                                                case "南方航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.nanfang;
                                                    break;
                                                case "中国航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.zhongguo;
                                                    break;
                                                case "东方航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.dongfang;
                                                    break;
                                                case "四川航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.sichuan;
                                                    break;
                                                case "深圳航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.shenzhen;
                                                    break;
                                                case "华夏航空":
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.huaxia;
                                                    break;
                                                default:
                                                    flightshow.flightlist[i][j].companyImg = flightshow.companyImg.zhongguo;
                                                    break;
                                            }
                                        }
                                    }
                                },
                                error: function (data) {
                                    console.log(data.responseJSON.message);

                                }
                            });
                        }
                        else {

                        }
                    }
                    else {
                        //alert("您已经处于首页了！");
                        swal({
                            text: "您已经处于首页了！",
                            type: "info",
                            confirmButtonText: "确定"
                        });
                    }
                }
            }
    })

    var flightshow = new Vue({
        el: '#project-container',
        data:
            {
                flightlist: "",
                totalpage: "",
                companyImg: {
                    hainan: "../../img/company/hainan.png",
                    xiangpeng: "../../img/company/xiangpeng.png",
                    lianhe: "../../img/company/lianhe.png",
                    nanfang: "../../img/company/nanfang.png",
                    zhongguo: "../../img/company/chianCompany.gif",
                    dongfang: "../../img/company/dongfang.gif",
                    sichuan: "../../img/company/sichuan.gif",
                    shenzhen: "../../img/company/shenzhen.gif",
                    huxia: "../../img/company/huaxia.gif"
                }
            },
        methods: {
            showData: function () {
                /* 用于获取航班信息 */
                var setout = jQuery.url.param("setout");
                var destination = jQuery.url.param("destination");
                var setout_date = jQuery.url.param("setout_date");
                var return_date = jQuery.url.param("return_date");
                var type = jQuery.url.param("type");
                if (type == "single") {
                    var jsondata = {
                        page: 0,
                        size: page_lenght,
                        setOutCityName: setout,
                        arriveCityName: destination,
                        departureDate: setout_date
                    };
                    console.log(jsondata);
                    jQuery.ajax({
                        url: 'http://localhost:8081/Flight/getAllByCondition',  //向后台传输数据
                        type: 'get',
                        contentType: 'application/json;charset=UTF-8',
                        data: jsondata,
                        dataType: "json",
                        success: function (data) {
                            console.log(data);
                            flightshow.flightlist = data.content;
                            flightshow.totalpage = data.totalPages;
                            page.$data.totalpage = flightshow.totalpage;
                            console.log(flightshow.flightlist);
                            //如果没有符合要求的航班信息
                            if (!flightshow.flightlist.length) {
                                swal({
                                    text: "对不起，未找到符合条件的航班。",
                                    type: 'warning',
                                    showCancelButton: false,
                                    confirmButtonColor: '#3085d6',
                                    cancelButtonColor: '#d33',
                                    confirmButtonText: '确定',
                                }).then(function () {
                                    location.href = "/Index/Index";
                                });
                            }
                            //如果某一个舱位的票已经售完
                            if (flightshow.flightlist[0][0].sparpreisTicket == null) {
                                console.log("售罄");
                            }
                            var i, j;
                            for (i = 0; i < flightshow.flightlist.length; i++) {
                                for (j = 0; j < 1; j++) {
                                    flightshow.flightlist[i][j].arriveTime = flightshow.flightlist[i][j].arriveTime.substring(11, 16);
                                    flightshow.flightlist[i][j].departureTime = flightshow.flightlist[i][j].departureTime.substring(11, 16);
                                    //console.log(flightshow.flightlist[i][j].arriveTime);
                                    if (flightshow.flightlist[i][j].sparpreisTicket == null) {
                                        flightshow.flightlist[i][j].sparpreisTicket = { ticketPrice: "售罄" };
                                    }
                                    if (flightshow.flightlist[i][j].firstClassCabinTicket == null) {
                                        flightshow.flightlist[i][j].firstClassCabinTicket = { ticketPrice: "售罄" };
                                    }
                                    if (flightshow.flightlist[i][j].touristClassTicket == null) {
                                        flightshow.flightlist[i][j].touristClassTicket = { ticketPrice: "售罄" };
                                    }
                                    switch(flightshow.flightlist[i][j].plane.company.companyName){
                                        case "海南航空":
                                            flightshow.flightlist[i][j].companyImg = flightshow.companyImg.hainan;
                                            break;
                                        case "祥鹏航空":
                                            flightshow.flightlist[i][j].companyImg = flightshow.companyImg.xiangpeng;
                                            break;
                                        case "联合航空":
                                            flightshow.flightlist[i][j].companyImg = flightshow.companyImg.lianhe;
                                            break;
                                        case "南方航空":
                                            flightshow.flightlist[i][j].companyImg = flightshow.companyImg.nanfang;
                                            break;
                                        case "中国航空":
                                            flightshow.flightlist[i][j].companyImg = flightshow.companyImg.zhongguo;
                                            break;
                                        case "东方航空":
                                            flightshow.flightlist[i][j].companyImg = flightshow.companyImg.dongfang;
                                            break;
                                        case "四川航空":
                                            flightshow.flightlist[i][j].companyImg = flightshow.companyImg.sichuan;
                                            break;
                                        case "深圳航空":
                                            flightshow.flightlist[i][j].companyImg = flightshow.companyImg.shenzhen;
                                            break;
                                        case "华夏航空":
                                            flightshow.flightlist[i][j].companyImg = flightshow.companyImg.huaxia;
                                            break;
                                        default:
                                            flightshow.flightlist[i][j].companyImg = flightshow.companyImg.zhongguo;
                                            break;
                                    }
                                }
                            }
                            console.log(flightshow.flightlist);
                        },
                        error: function (data) {
                            console.log(data.responseJSON.message);

                        }
                    });
                }
                else {

                }
            },
            /* 用于控制价格是否显示 */
            shownOrNot: function (todo) {
                if (jQuery("#" + todo[0].id).css("display") == "none") {
                    jQuery("#" + todo[0].id).slideDown("slow");
                    jQuery("#" + todo[0].id).prev().css("background", "rgb(255,255,255)");
                }
                else {
                    jQuery("#" + todo[0].id).slideUp("slow");
                    jQuery("#" + todo[0].id).prev().css("background", "rgb(1, 126, 186)");
                }
            },
            /* 用于进入订单填写页面 */
            jumpToOrderfull1: function (todo) {
                // alert("123");
                var date = jQuery.url.param("setout_date");
                date = date.replace(/\//g, "-");
                date = date.substring(0, 5);
                console.log(date);
                var setout = jQuery.url.param("setout");
                var destination = jQuery.url.param("destination");
                var type = "特价经济舱";
                var setout_time = todo[0].departureTime;
                var arrive_time = todo[0].arriveTime;
                var flight_time = todo[0].flightTime;
                var setout_airport = todo[0].setOutAirport;
                var arrive_airport = todo[0].arriveAirport;
                var company = todo[0].plane.company.companyName;
                var id = todo[0].sparpreisTicket.id;
                var price = todo[0].sparpreisTicket.ticketPrice;
                this.target = "_blank";
                var url_date = "?date=" + date + "&setout=" + setout + "&destination=" + destination
			    + "&type=" + type + "&setout_time=" + setout_time + "&arrive_time=" + arrive_time
			    + "&flight_time=" + flight_time + "&setout_airport=" + setout_airport +
			    "&arrive_airport=" + arrive_airport + "&company=" + company + "&id=" + id + "&price=" + price;
                // window.location.href="./orderfull.php"+url_date;
                window.open("/Orderfull/orderfull" + url_date, "_blank");
            }
        }
    })
    flightshow.showData();
   
    $('#loader-wrapper .load_title').remove();
});