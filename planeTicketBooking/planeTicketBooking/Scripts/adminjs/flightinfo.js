//修改按钮的点击事件
function change(flight_id, flight_num, flight_departuretime, flight_arrivetime, flight_departurecity, flight_arrivecity,flight_companyname) {
    //通过传参获取表格中每一项的数据
    $('#changeFlight_ID').val(flight_id);
    $('#changeFlight_Num').val(flight_num);
    $('#changeFlight_Departuretime').val(flight_departuretime);
    $('#changeFlight_Arrivetime').val(flight_arrivetime);
    $('#changeFlight_DepartureCity').val(flight_departurecity);
    $('#changeFlight_ArriveCity').val(flight_arrivecity);
    $('#changeFlight_CompanyName').val(flight_companyname);
}

//删除按钮的点击事件
function Delete(id) {
    swal({
        title: '确定要删除此航班信息吗?',
        text: "此项操作是不可恢复的!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: '确定',
        cancelButtonText: '取消'
    }).then(function () {
        //向相应的Controller发送请求
        $.ajax({
            url: '/FlightInfo/DeleteFlightMsg',
            type: 'post',
            data: { Flight_ID: id },
            success: function (data) {
                console.log("数据删除成功");
                console.log(data);
                location.reload();
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
}

$(document).ready(function () {

    //初始化城市选择框
    var cityPicker = new HzwCityPicker({
        data: data,
        target: 'addCityBelong',
        valType: 'k-v',
        hideCityInput: {
            name: 'city',
            id: 'city'
        },
        hideProvinceInput: {
            name: 'province',
            id: 'province'
        },
        callback: function () {

        }
    });
    cityPicker.init();

    //添加模态框-取消按钮-清空输入框
    $('#addCancelBtn').click(function () {
        $('#addFlight_id').val('');
        $('#addFlight_num').val('');
        $('#addFlight_departuretime').val('');
        $('#addFlight_arrivetime').val('');
        $('#addFlight_departureCity').val('');
        $('#addFlight_arriveCity').val('');
        $('#addFlight_companyName').val('');

    });

    /**
     * 添加模态框-确认按钮-向数据库中添加数据
     * 利用AJAX发送请求
     */
    //
    $('#addSureBtn').click(function () {
        var Flight_id = $('#addFlight_id').val();
        var Flight_num = $('#addFlight_num').val();
        var Flight_departuretime = $('#addFlight_departuretime').val();
        var Flight_arrivetime = $('#addFlight_arrivetime').val();
        var Flight_departureCity = $('#addFlight_departureCity').val();
        var Flight_arriveCity = $('#addFlight_arriveCity').val();
        var Flight_companyName = $('#addFlight_companyName').val();

        //alert(airportName + cityBelong);
        //向相应的Controller发送请求
        $.ajax({
            url: '/FlightInfo/AddFlightMsg',
            type: 'post',
            data: { Flight_id: Flight_id, Flight_num: Flight_num, Flight_departuretime: Flight_departuretime, Flight_arrivetime: Flight_arrivetime, Flight_departureCity: Flight_departureCity, Flight_arriveCity: Flight_arriveCity, Flight_companyName: Flight_companyName},
            success: function (data) {
                console.log("新增数据成功");
                console.log(data);
                //进行数据的局部刷新
                //$('#cityMsgTable').DataTable().destroy();
                //$('#cityMsgTable').empty();
                //弹窗提示插件
                //swal('新增数据成功', 'success');
                location.reload();
            },
            error: function (err) {
                console.log(err);
            }
        });
    });

    /**
     * 修改模态框-确认按钮-修改数据库中的数据
     * 利用AJAX发送请求
     */
    $('#changeSureBtn').click(function () {
        var Flight_id = $('#changeFlight_ID').val();
        var Flight_num = $('#changeFlight_Num').val();
        var Flight_departuretime = $('#changeFlight_Departuretime').val();
        var Flight_arrivetime = $('#changeFlight_Arrivetime').val();
        var Flight_departureCity = $('#changeFlight_DepartureCity').val();
        var Flight_arriveCity = $('#changeFlight_ArriveCity').val();
        var Flight_companyName = $('#changeFlight_CompanyName').val();



        //向相应的Controller发送请求
        $.ajax({
            url: '/AirportAdmin/ChangeCityMsg',
            type: 'post',
            data: { Flight_id: Flight_id, Flight_num: Flight_num, Flight_departuretime: Flight_departuretime, Flight_arrivetime: Flight_arrivetime, Flight_departureCity: Flight_departureCity, Flight_arriveCity: Flight_arriveCity, Flight_companyName: Flight_companyName},
            success: function (data) {
                console.log("数据修改成功");
                console.log(data);
                location.reload();
            },
            error: function (err) {
                console.log(err);
            }
        });
    });

    //用于DataTable的汉化
    $('#FlightMsgTable').DataTable({
        language: {
            "sProcessing": "处理中...",
            "sLengthMenu": "显示 _MENU_ 项结果",
            "sZeroRecords": "没有匹配结果",
            "sInfo": "显示第 _START_ 至 _END_ 项结果，共 _TOTAL_ 项",
            "sInfoEmpty": "显示第 0 至 0 项结果，共 0 项",
            "sInfoFiltered": "(由 _MAX_ 项结果过滤)",
            "sInfoPostFix": "",
            "sSearch": "搜索:",
            "sUrl": "",
            "sEmptyTable": "表中数据为空",
            "sLoadingRecords": "载入中...",
            "sInfoThousands": ",",
            "oPaginate": {
                "sFirst": "首页",
                "sPrevious": "上页",
                "sNext": "下页",
                "sLast": "末页"
            },
            "oAria": {
                "sSortAscending": ": 以升序排列此列",
                "sSortDescending": ": 以降序排列此列"
            }
        }
    });
});