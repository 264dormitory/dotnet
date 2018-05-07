//修改按钮的点击事件
function change(id, airportName, cityName) {
    //通过传参获取表格中每一项的数据
    $('#changeAirportID').val(id);
    $('#changeAirportName').val(airportName);
    $('#changeCityBelong').val(cityName);
}

//删除按钮的点击事件
function Delete(id) {
    //用于DataTable的汉化
    $('#cityMsgTable').DataTable({
        "language": {
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
        },
        "destory": true,
        "retrieve": true
    });
    $('#cityMsgTable').dataTable().fnDestroy();

    swal({
        title: '确定要删除此机场信息吗?',
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
            url: '/AirportAdmin/DeleteCityMsg',
            type: 'post',
            data: { airportID: id },
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
        $('#addAirportName').val('');
        $('#addCityBelong').val('');
    });

    /**
     * 添加模态框-确认按钮-向数据库中添加数据
     * 利用AJAX发送请求
     */
    //
    $('#addSureBtn').click(function () {
        var airportName = $('#addAirportName').val();
        var cityBelong = $('#addCityBelong').val();
        //alert(airportName + cityBelong);
        //向相应的Controller发送请求
        $.ajax({
            url: '/AirportAdmin/AddCityMsg',
            type: 'post',
            data: { airportName: airportName, cityName: cityBelong },
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
        var airportID = $('#changeAirportID').val();
        var airportName = $('#changeAirportName').val();
        //向相应的Controller发送请求
        $.ajax({
            url: '/AirportAdmin/ChangeCityMsg',
            type: 'post',
            data: { airportID: airportID, airportName: airportName },
            success: function (data) {
                console.log("数据修改成功");
                console.log(data);
                //$('#cityMsgTable').dataTable().fnClearTable(this);
                //$('#cityMsgTable').dataTable().fnReloadAjax();
                location.reload();
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
});