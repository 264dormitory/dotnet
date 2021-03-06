<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>航班信息管理</title>
  <!-- 李世杰于2017.06.10编写订单填写页面 -->
  <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,400italic,600,700' rel='stylesheet' type='text/css'>
  <link href="../css/font-awesome.min.css" rel="stylesheet">
  <link href="../css/bootstrap.min.css" rel="stylesheet">
  <link href="../css/flexslider.css" rel="stylesheet"> 
  <link href="../css/templatemo-style.css" rel="stylesheet">

  <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <!-- favicon -->
    <link rel="shortcut icon" href="../images/favicon.png">

  </head>
  <body class="tm-gray-bg" style="background-color:rgb(255,255,255);">
	<!-- Header -->
	<?php
		require_once("../pagemodule/header_back.php");
	?>
	<!-- gray bg -->	
	<section id="airport-detail" class="container tm-home-section-1" id="more" style="min-height: 550px;">
	  	<!-- 增添数据模态框 -->
  	<div id="cityadd" class="modal fade" tabindex="-1" role="dialog">
	  <div class="modal-dialog" role="document" style="width: 750px;">
	    <div class="modal-content">
	      <div class="modal-header">
	        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
	        <h4 class="modal-title">增加机场信息</h4>
	      </div>
	      <div class="modal-body">
	        <form class="form-horizontal" style="font-family: 宋体">
              <div class="form-group form-group-lg" style="margin-bottom: 20px;">
                <label for="城市名称" class="col-sm-2 control-label" 
                  style="letter-spacing: 5px;">
                   城市名称
                </label>
                <div class="col-sm-10">
                  <input type="text" class="form-control" id="r_user" placeholder="您的账户名和用户名" maxlength="20">
                </div>
              </div>              
              <div class="form-group form-group-lg" style="margin-bottom: 20px;">
                <label for="机场名称" class="col-sm-2 control-label" 
                  style="letter-spacing: 5px;">
                  机场名称
                </label>
                <div class="col-sm-10">
                  <input type="text" class="form-control" id="r_user" placeholder="您的账户名和用户名" maxlength="20">
                </div>
              </div>
            </form>
	      </div>
	      <div class="modal-footer">
	        <button type="button" class="btn btn-default" data-dismiss="modal">取消</button>
	        <button type="button" class="btn btn-primary">保存</button>
	      </div>
	    </div><!-- /.modal-content -->
	  </div><!-- /.modal-dialog -->
	</div><!-- /.modal -->
	<!-- 修改数据模态框 -->
	<div id="cityModify" class="modal fade" tabindex="-1" role="dialog">
	  <div class="modal-dialog" role="document" style="width: 750px;">
	    <div class="modal-content">
	      <div class="modal-header">
	        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
	        <h4 class="modal-title">修改机场信息</h4>
	      </div>
	      <div class="modal-body">
	        <form class="form-horizontal" style="font-family: 宋体">
              <div class="form-group form-group-lg" style="margin-bottom: 20px;">
                <label for="城市名称" class="col-sm-2 control-label" 
                  style="letter-spacing: 5px;">
                   城市名称
                </label>
                <div class="col-sm-10">
                  <input type="text" class="form-control" id="r_user" placeholder="您的账户名和用户名" maxlength="20">
                </div>
              </div>              
              <div class="form-group form-group-lg" style="margin-bottom: 20px;">
                <label for="机场名称" class="col-sm-2 control-label" 
                  style="letter-spacing: 5px;">
                  机场名称
                </label>
                <div class="col-sm-10">
                  <input type="text" class="form-control" id="r_user" placeholder="您的账户名和用户名" maxlength="20">
                </div>
              </div>
            </form>
	      </div>
	      <div class="modal-footer">
	        <button type="button" class="btn btn-default" data-dismiss="modal">取消</button>
	        <button type="button" class="btn btn-primary">保存</button>
	      </div>
	    </div><!-- /.modal-content -->
	  </div><!-- /.modal-dialog -->
	</div><!-- /.modal -->
		<!-- 我的订单信息展示页面 -->
		<div class="section-margin-top"></div>
		<div class="container">
			<div class="row" style="margin-top:20px;">
				<button class="btn btn-primary" style="margin-bottom:5px;" data-toggle="modal" data-target="#cityadd">添加</button>
				<table class="table table-striped table-bordered">
					<thead>
						<tr>
							<th>航空公司名称</th>
							<th>退票规则</th>
							<th>改签规则</th>
							<th style="text-align:center;">操作</th>
						</tr>
					</thead>
					<tbody>
						<tr v-for="(item, index) in message">
							<td>{{item.companyName}}</td>
							<td>{{item.freeTicketRule.touristClassScale}}</td>
							<td>￥{{item.endorseRule.touristClassMoney}}</td>
							<td style="text-align:center;">
								<a href="#">修改</a>
								<i>&nbsp|&nbsp</i>
								<a href="#">删除</a>
							</td>
						</tr>
					</tbody>
				</table>
			</div>
		</div>
	</section>	
	<!-- footer -->
	<footer style="height: 87.8px;border-top: 0.8px solid rgb(153, 153, 153);text-align:center;">
		<p style="margin-top:20px;color:rgb(153, 153, 153);">N-Travel网服务保障&nbsp版权所有©2018 京ICP备05021087号</p>
	</footer>
	<script type="text/javascript" src="../js/jquery-1.11.2.min.js"></script>	
	<!-- jQuery -->
	<script type="text/javascript" src="../js/bootstrap.min.js"></script>			
	<!-- bootstrap js -->
    <script src="../js/jQuery.URL.Parse.js"></script>
    <!-- 用于地址解析 -->
   	<script type="text/javascript" src="../js/Vue.js"></script>
	<script type="text/javascript" src="../js/Vue.min.js"></script>
	<script type="text/javascript">
		var airport = new Vue({
			el:"#airport-detail",
			data:{
				message:"",
			},
			methods:{
				getCityMessage:function()
				{
					jQuery.ajax({
						url: 'http://localhost:8081/Company/getAll',  //向后台传输数据
			          	type: 'GET',
			          	contentType: 'application/json;charset=UTF-8',
			          	success: function(data)
			          	{
			          		airport.message = data;
			            	console.log(airport.message);
			          	},
			          	error: function(data)
			          	{
			            	console.log(data);                   
			          	}
					});
				}
			}
		})
		airport.getCityMessage();
	</script>
	<!-- Vue.js -->
  	<script type="text/javascript" src="../js/moment.js"></script>					
  	<!-- moment.js -->
	<script type="text/javascript" src="../js/jquery.flexslider-min.js"></script>
   	<script type="text/javascript" src="../js/templatemo-script.js"></script>
 </body>
 </html>
