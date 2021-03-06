<div class="modal fade" id="regist" tabindex="-1" role="dialog" aria-labelledby="registLabel">
    <div id="r_alert" class="row in fade" style="margin-top: 25px;font-family: 宋体;display: none;">
        <div class="alert alert-danger alert-dismissible col-sm-offset-3 col-sm-6" role="alert" style="text-align: center;">

        </div>
    </div>
    <div class="modal-dialog" role="document" style="width: 650px;">
      <div class="modal-content">
         <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="registLabel">欢迎注册</h4>
        </div>
        <div class="modal-body">
            <form class="form-horizontal" style="font-family: 宋体">
              <!-- 用户名输入框 -->
              <div class="form-group form-group-lg" style="margin-bottom: 0px;">
                <label for="用户名" class="col-sm-2 control-label" 
                  style="letter-spacing: 5px;">
                  用户名
                </label>
                <div class="col-sm-10">
                  <input type="text" class="form-control" id="r_user" placeholder="您的账户名和用户名" maxlength="20">
                </div>
              </div>
              <div id="regist-tips1" style="height: 42px;padding-top: 5px;">
                  <span class="col-sm-2"></span>
                  <span id="tips1-waring" class="col-sm-10  glyphicon glyphicon-exclamation-sign" style="font-size: 13px;color: #c5c5c5;display: none;">
                      支持字母、数字、"-"、"_"的组合，4-20个字符
                  </span>
                  <span id="tips1-error" class="col-sm-10 glyphicon glyphicon-remove-circle" style="font-size: 13px;color: #c5c5c5;display: none;color: #e22;">
                  </span>
                  <span id="tips1-success" class="col-sm-10 glyphicon glyphicon-ok-circle" style="font-size: 13px;color: #c5c5c5;display: none;color: #3c763d;">
                  </span>
              </div>
              <!-- 手机号码输入框 -->
              <div class="form-group form-group-lg" style="margin-bottom: 0px;">
                <label for="手机号码" class="col-sm-2 control-label">
                  手机号码
                </label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" id="r_phone" placeholder="请输入手机号码（+86）" maxlength="11">
                </div>
              </div>
              <div id="regist-tips6" style="height: 42px;padding-top: 5px;">
                  <span class="col-sm-2"></span>
                  <span id="tips6-waring" class="col-sm-10 glyphicon glyphicon-info-sign" style="font-size: 13px;color: #c5c5c5;display: none;" >
                      手机号可用于订单填写、订单查询等
                  </span>
                  <span id="tips6-error" class="col-sm-10 glyphicon glyphicon-remove-circle" style="font-size: 13px;color: #c5c5c5;display: none;color: #e22;">
                  </span>
                  <span id="tips6-success" class="col-sm-10 glyphicon glyphicon-ok-circle" style="font-size: 13px;color: #c5c5c5;display: none;color: #3c763d;">
                  </span>
              </div>
              <!-- 设置密码输入框 -->
              <div class="form-group form-group-lg" style="margin-bottom: 0px;">
                <label for="密码" class="col-sm-2 control-label">
                  设置密码
                </label>
                <div class="col-sm-10">
                    <input type="password" class="form-control" id="r_password" placeholder="建议至少使用两种字符" maxlength="20">
                </div>
              </div>
              <div id="regist-tips2" style="height: 42px;padding-top: 5px;">
                  <span class="col-sm-2"></span>
                  <span id="tips2-waring" class="col-sm-10 glyphicon glyphicon-info-sign" style="font-size: 13px;color: #c5c5c5;display: none;" >
                      建议使用字母、数字和符号两种及以上的组合，6-20个字符
                  </span>
                  <span id="tips2-error" class="col-sm-10 glyphicon glyphicon-remove-circle" style="font-size: 13px;color: #c5c5c5;display: none;color: #e22;">
                  </span>
                  <span id="tips2-success" class="col-sm-10 glyphicon glyphicon-ok-circle" style="font-size: 13px;color: #c5c5c5;display: none;color: #3c763d;">
                  </span>
              </div>
              <!-- 确认密码输入框 -->
              <div class="form-group form-group-lg" style="margin-bottom: 0px;">
                <label for="确认密码" class="col-sm-2 control-label">
                  确认密码
                </label>
                <div class="col-sm-10">
                    <input type="password" class="form-control" id="r_password_again" placeholder="请再次输入密码" maxlength="20">
                </div>
              </div>
              <div id="regist-tips3" style="height: 42px;padding-top: 5px;">
                  <span class="col-sm-2"></span>
                  <span id="tips3-waring" class="col-sm-10 glyphicon glyphicon-info-sign" style="font-size: 13px;color: #c5c5c5;display: none;" >
                      请再次输入密码
                  </span>
                  <span id="tips3-error" class="col-sm-10  glyphicon glyphicon-remove-circle" style="font-size: 13px;color: #c5c5c5;display: none;color: #e22;">
                  </span>
                  <span id="tips3-success" class="col-sm-10 glyphicon glyphicon-ok-circle" style="font-size: 13px;color: #c5c5c5;display: none;color: #3c763d;">
                  </span>
              </div>
              <!-- 验证码输入框 -->
              <div class="form-group form-group-lg" style="margin-bottom: 0px;">
                  <label for="验证码" class="col-sm-2 control-label" style="letter-spacing: 5px;">
                      验证码
                  </label>
                  <div class="col-sm-6">
                      <input type="text" class="form-control" id="r_verify" placeholder="请输入验证码" maxlength="20">
                  </div>
                  <div id="r_code" class="col-sm-4">
                  </div>
              </div>
              <div id="regist-tips4" style="height: 42px;padding-top: 5px;">
                <span class="col-sm-2"></span>
                <span id="tips4-waring" class="col-sm-10 glyphicon glyphicon-info-sign" style="font-size: 13px;color: #c5c5c5;display: none;" >
                    看不清？点击图片更换验证码
                </span>
                <span id="tips4-error" class="col-sm-10  glyphicon glyphicon-remove-circle" style="font-size: 13px;color: #c5c5c5;display: none;color: #e22;">
                </span>
                <span id="tips4-success" class="col-sm-10 glyphicon glyphicon-ok-circle" style="font-size: 13px;color: #c5c5c5;display: none;color: #3c763d;">
                </span>
              </div>
              <!-- 协议同意 -->
              <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                  <div class="checkbox">
                    <label>
                      <input id="r_check" type="checkbox" checked="checked">
                        我已阅读并同意遵守<a href="">《用户服务协议》</a>
                      </label>
                  </div>
                </div>
                <span id="tips5-error" class="col-sm-offset-2 col-sm-10  glyphicon glyphicon-remove-circle" style="font-size: 13px;color: #c5c5c5;display: none;color: #e22;">
                  您必须同意协议的内容才可以进行注册
                </span>
              </div>
            </form>
          </div>
          <div class="modal-footer">
              <button type="button" class="btn btn-default" data-dismiss="modal">取消</button>
              <button id="b_regist" type="button" class="btn btn-primary" data-toggle="collapse" data-target="#regist_alert" aria-expanded="false" aria-controls="regist_alert">
                  立即注册
              </button>
          </div>
    </div>
    </div>
</div>