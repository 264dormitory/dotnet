$(document).ready(function()
{
    $('#flight-time').selectpicker({
        style: 'btn-link',
        size: '4',
        noneSelectedText: '起飞时间',
        iconBase: 'glyphicon',
        tickIcon: 'glyphicon-ok',
        showIcon: 'true',
        showTick: 'true',
        width: 'fit'
    });
    $('#company').selectpicker({
        style: 'btn-link',
        size: '4',
        noneSelectedText: '航空公司',
        iconBase: 'glyphicon',
        tickIcon: 'glyphicon-ok',
        showIcon: 'true',
        showTick: 'true',
        width: 'fit'
    });
    $('#plane-type').selectpicker({
        style: 'btn-link',
        size: '4',
        noneSelectedText: '机型',
        iconBase: 'glyphicon',
        tickIcon: 'glyphicon-ok',
        showIcon: 'true',
        showTick: 'true',
        width: 'fit'
    });
    $('#time-sort').selectpicker({
        style: 'btn-link',
        size: '2',
        noneSelectedText: '起飞时间排序',
        title: '起飞时间排序',
        iconBase: 'glyphicon',
        tickIcon: 'glyphicon-ok',
        showIcon: 'true',
        showTick: 'true',
        width: 'fit'
    });
    $('#plane-sort').selectpicker({
        style: 'btn-link',
        size: '2',
        noneSelectedText: '价格排序',
        title: '价格排序',
        iconBase: 'glyphicon',
        tickIcon: 'glyphicon-ok',
        showIcon: 'true',
        showTick: 'true',
        width: 'fit'
    });
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
                var list = data.content;
                console.log(list);
                for (var i = 0; i < list.length; i++) {
                    list[i][0].departureTime = list[i][0].departureTime.substring(11, 16);
                    $('#flight-time').append("<option value='" + list[i][0].departureTime + "'>"
                            + list[i][0].departureTime + "</option>");
                    $('#company').append("<option value='" + list[i][0].plane.company.companyName + "'>"
                            + list[i][0].plane.company.companyName + "</option>");
                }
                $('#flight-time').selectpicker('refresh');
                $('#company').selectpicker('refresh');
            },
            error: function (data) {
                console.log(data.responseJSON.message);
            }
        });
    }
    else {

    }

	/* 用于置顶按钮 */
	$.scrollUp({
		scrollName: 'scrollUp',      // Element ID
		scrollDistance: 300,         // Distance from top/bottom before showing element (px)
		scrollFrom: 'top',           // 'top' or 'bottom'
		scrollSpeed: 300,            // Speed back to top (ms)
		easingType: 'linear',        // Scroll to top easing (see http://easings.net/)
		animation: 'fade',           // Fade, slide, none
		animationSpeed: 200,         // Animation speed (ms)
		scrollTrigger: false,        // Set a custom triggering element. Can be an HTML string or jQuery object
		scrollTarget: false,         // Set a custom target element for scrolling to. Can be element or number
		scrollText: 'Scroll to top', // Text for element, can contain HTML
		scrollTitle: false,          // Set a custom <a> title if required.
		scrollImg: true,             // Set true to use image
		activeOverlay: true,        // Set CSS color to display scrollUp active point, e.g '#00FFFF'
		zIndex: 2147483647           // Z-Index for the overla
	});
	$("#next-page").click(function()
	{
		
	});	
});