var airlineRecommand = new Vue({
    el: '#airline-recommand',
    data: {
        airline: "",
    },
    methods: {
        showData: function () {
            jQuery.ajax({
                url: 'http://localhost:8081/Flight/getAllOfLowPrice/5',  //向后台传输数据
                type: 'get',
                contentType: 'application/json;charset=UTF-8',
                success: function (data) {
                    airline = data;
                    console.log(airline[0]);
                },
                error: function (data) {
                    console.log(data.responseJSON.message);
                }
            })
        }
    }
});
airlineRecommand.showData();