function ToReLogin()
{
    location.href  = "/Manage/Layout/Login.aspx?action=relogin";
}
// 检查登录状态
function CheckUpLoginState() {
    $.getJSON("/Module/LoginManage/GetLoginInfo.ashx",
        {
            m: "CheckUpLoginState"
        }
        , function (json) {
            if (json!=null&&json.IsSuccess == false) {
                alert("会话失效，请重新登录。");
                ToReLogin();
            }
        });
}
// 统一修改easyui datebox的日期格式
$.fn.datebox.defaults.formatter = function (date) {
    var y = date.getFullYear();
    var m = date.getMonth() + 1;
    var d = date.getDate();
    return y + '-' + (m < 10 ? '0' + m : m) + '-' + (d < 10 ? '0' + d : d);
};

// 是否添加
function IsAdd() {
    if (location.href.indexOf("id=") < 0) {
        return true;
    } else {
        return false;
    }
}

function SetCode_NumberAutoAdd(objInput, keyCode)
{
    $.getJSON("/DataAccess/SystemSetupTBL/GetData_Ext.ashx",
        {
            m: "GetCode_NumberAutoAdd",
            KeyCode:keyCode
        }
        , function (json) {
            //$("#" + objInput).val(json.ReturnMessage);
            if (json.IsSuccess) {
                $("#" + objInput).val(json.ReturnMessage);
            } else {
                if (json.ReturnTitle == "Login") {
                    alert("会话失效，请重新登录。");
                    ToReLogin();
                }
            }
        });
}
function IsExist(url, colName, val, pKeyVal) {
    try {
        var exist = false;
        $.ajaxSettings.async = false;
        $.getJSON(url,
            {
                m: "IsExist",
                ColName: colName,
                Val: val,
                ID: pKeyVal
            }
            , function (json) {
                exist = json.IsSuccess;
            });
        $.ajaxSettings.async = true;
        return exist;
    } catch (e) {
        return false;
    }
}
function sleep(numberMillis) {
    var now = new Date();
    var exitTime = now.getTime() + numberMillis;
    while (true) {
        now = new Date();
        if (now.getTime() > exitTime)
            return;
    }
}

//  如果IsSingle为false Val的值为""
function GetKeyValueJsonDataByDataTable(DataTable, KeyField, ValueField, IsSingle, Val) {
    var currentasync = $.ajaxSettings.async;
    if (currentasync) {
        $.ajaxSettings.async = false;
    }
    var JsonData;
    $.getJSON("/DataAccessCommon/GetData.ashx?m=GetKeyValueJsonDataByDataTable&DataTable=" + DataTable + "&KeyField=" + KeyField + "&ValueField=" + ValueField + "&IsSingle=" + IsSingle + "&Val=" + Val, function (json) {
        JsonData = json;
    });
    $.ajaxSettings.async = currentasync;
    return JsonData;
}




