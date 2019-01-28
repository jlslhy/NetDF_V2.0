// Author: LHY
// 结合 JQ 1.7使用
// v1.0002

// 让指定的元素显示或者隐藏,传的参数值为目标元素的ID
function ShowOrHide(TargetID) {
    var displayState = $("#" + TargetID)[0].style.display;
    $("#" + TargetID)[0].style.display = displayState == "none" ? "block" : "none";
}

// 获取url地址中的参数值
function ReqStr(url, par) {
    url = $.trim(url);
    var tempurl = url.toLowerCase();
    var temppar = par.toLowerCase();
    var parValue = "";
    var startIndex = tempurl.indexOf("?" + temppar + "=");
    if (startIndex < 0) {
        startIndex = tempurl.indexOf("&" + temppar + "=");
    }
    if (startIndex < 0) {
        throw "参数错误，不存在此url参数：'" + par + "'";
    }
    var partUrl = url.substring(startIndex + 2 + par.length, url.length);
    var endIndex = partUrl.indexOf("&");
    if (endIndex >= 0) {
        parValue = partUrl.substring(0, endIndex);
    } else {
        endIndex = partUrl.indexOf("#");
        if (endIndex >= 0) {
            parValue = partUrl.substring(0, endIndex);
        } else {
            parValue = partUrl;
        }
    }

    return parValue;

}

// 为url地址添加或更改参数值

function changeURLPar(url, paramName, par_value) {
   
    var patternStr = "(?:[\\?&]{1})" + paramName + "=[^&]{0,}";
    var re = new RegExp(patternStr, "i"); // 创建正则表达式对象。

    var temp;
    try {
        temp = url.match(re);
    } catch (e)
      { }
    if (temp==null||temp == undefined) {
        temp = "";
    } else {
        temp = temp.toString();
    }
    var oldparamval = "";
    var newparamval = paramName + "=" + par_value;
    if (temp.indexOf("?") == 0) {
        oldparamval = temp.substring(1);
    } else if (temp.indexOf("&") == 0) {
        oldparamval = temp.substring(1);
    }

    var tempurl = url;

    if (temp == "") {
       
        if (tempurl.indexOf("?") > 0) {
            tempurl = tempurl + "&" + newparamval;
        } else {
            tempurl = tempurl + "?" + newparamval;
        }
    } else {
        tempurl = tempurl.replace(oldparamval, newparamval);
    }


    return tempurl;


}
// 判断网址是否包含某参数。
function UrlHasParam(url, par) {
    var tempurl = url.toLowerCase();
    var temppar = par.toLowerCase();
    return (tempurl.indexOf("?" + temppar + "=") >= 0 || tempurl.indexOf("&" + temppar + "=") > 0);
}



// 用于ajax的刷新,返回的格式如：act=12
function AjaxRefresh() {
    return  "act="+Math.random();
}

// 获取最新版本的URL
function GetLastVerUrl(url, isRefresh) {
    var vernumber = localStorage.getItem(url);
    if (vernumber == null) {
        vernumber = 1;
    }
    if (isRefresh) {
        vernumber = parseInt(vernumber) + 1;
        localStorage.setItem(url,vernumber);
    }
    if (url.indexOf("?") > 0) {
         return url + "&ver=" + vernumber;
    } else {
         return url + "?ver=" + vernumber;
    }

}


// 判断是否是有理数
//function isDigit(s) {
function isRational(s){
    // var   patrn=/^[0123456789.]{1,20}$/;
    var patrn = /^[-+]{0,1}[0-9]{1,20}(\.[0-9]{1,})?$/; 
    return patrn.test(s);
}

//是否为空，返回Boolean值，如果是空，则弹出提示窗口。
function isEmptyMsg(id, msg) {
    if ($.trim($("#" + id).val()) == "") {
        alert(msg);
        $("#" + id).focus();
        return true;
    }
    return false;
}
//是否都为空，返回Boolean值，如果是空，则弹出提示窗口。
function isEmptyMsg2(id1, id2, msg) {
    if ($.trim($("#" + id1).val()) == "" && $.trim($("#" + id2).val()) == "") {
        alert(msg);
        $("#" + id1).focus();
        return true;
    }
    return false;
}

//判断是否为空
function isEmpty(id) {
    if ($.trim($("#" + id).val()) == "") {
        return true;
    }
    return false;
}

// 显示待选值 例：onclick='ShowDropdownList(this,[{"T":"tttt","V":"vvvv"}]);'  Design By LHY 

// 显示待选值 LHY
function ShowDropdownList(obj, jsondata) {
    divid = "div_" + obj.id;
    ishide = false;
    document.body.onmousedown = function () {
        if (ishide) {
            $("#" + divid).hide();
        }
    }
    if ($("#" + divid)[0] != undefined) {
        $("#" + divid).show();
        ishide = true;
        return;
    }
    var selectobj = document.createElement("select");
    for (var i = 0; i < jsondata.length; i++) {
        selectobj.options.add(new Option(jsondata[i].T, jsondata[i].V));
    }
    var divobj = document.createElement("div");
    $(divobj).attr("id", divid);
    $(divobj).append(selectobj);
    $(obj).parent().append(divobj);
    selectobj.onmouseover = function () { ishide = false; }
    selectobj.onchange = function () { $(obj).val(selectobj.value); $(divobj).hide(); ishide = true; }
    selectobj.onblur = function () { $(divobj).hide(); ishide = true; }
    ishide = true;
}



function ShowBox(titleText, width, height, top) {
    if (typeof ($("#CoverDiv")[0]) == 'undefined') {
        var CoverDiv = document.createElement("div");
        $("body").append(CoverDiv);
        $(CoverDiv).attr("id", "CoverDiv");
        $(CoverDiv).css({ "position": "absolute", "top": "0px", "width": "100%", "z-index": "101", "display": "none", "background-color": "#86B7E1" });
        $(CoverDiv).height($(document).height());

        var AjaxContentDiv = document.createElement("div");
        $("body").append(AjaxContentDiv);
        $(AjaxContentDiv).attr("id", "AjaxContentDiv");
        $(AjaxContentDiv).css({ "z-index": "101", "position": "absolute", "background-color": "White", "display": "none", "border": "1px solid #9BBC7A" });


        var AjaxContentDiv_Title = document.createElement("div");
        $(AjaxContentDiv_Title).attr("id", "AjaxContentDiv_Title");
        $(AjaxContentDiv_Title).css({ "text-align": "left", "font-size": "14px", "z-index": "101", "padding-left": "10px", "line-height": "28px", "background-color": "#BBD7DE", "height": "28px" });
        $(AjaxContentDiv_Title).html("<label style='float:right;z-index:101; cursor:pointer;' onclick='hideBox();' > X关闭 &nbsp; </label><div style='padding-left:18px;' id='AjaxContentDiv_Title_Text'></div>");
        $(AjaxContentDiv).append(AjaxContentDiv_Title);

        var AjaxContentDiv_Content = document.createElement("div");
        $(AjaxContentDiv_Content).attr("id", "AjaxContentDiv_Content");
        $(AjaxContentDiv_Content).css({ "height": (height - 50) + "px" });
        $(AjaxContentDiv).append(AjaxContentDiv_Content);


    }
    $("#AjaxContentDiv").width(width);
    $("#AjaxContentDiv").height(height);
    $("#AjaxContentDiv").css("top", $(document).scrollTop() + top);
    $("#AjaxContentDiv").css("left", ($(document).width() - $("#AjaxContentDiv").width()) / 2);

    $("#AjaxContentDiv_Title_Text").html(titleText);
    $("#CoverDiv").fadeTo("fast", 0.68);
    $("#AjaxContentDiv").fadeTo("slow", 0.98);

}


function ShowIFrameBox(titleText,url, width, height, top) {
    if (typeof ($("#CoverDiv")[0]) == 'undefined') {
        var CoverDiv = document.createElement("div");
        $("body").append(CoverDiv);
        $(CoverDiv).attr("id", "CoverDiv");
        $(CoverDiv).css({ "position": "absolute", "top": "0px", "width": "100%", "z-index": "101", "display": "none", "background-color": "#86B7E1" });
        $(CoverDiv).height($(document).height());

        var AjaxContentDiv = document.createElement("div");
        $("body").append(AjaxContentDiv);
        $(AjaxContentDiv).attr("id", "AjaxContentDiv");
        $(AjaxContentDiv).css({ "z-index": "101", "position": "absolute", "background-color": "White", "display": "none", "border": "1px solid #9BBC7A" });


        var AjaxContentDiv_Title = document.createElement("div");
        $(AjaxContentDiv_Title).attr("id", "AjaxContentDiv_Title");
        $(AjaxContentDiv_Title).css({ "text-align": "left", "font-size": "14px", "z-index": "101", "padding-left": "10px", "line-height": "28px", "background-color": "#BBD7DE", "height": "28px" });
        $(AjaxContentDiv_Title).html("<label style='float:right;z-index:101; cursor:pointer;' onclick='hideBox();' > X关闭 &nbsp; </label><div style='padding-left:18px;' id='AjaxContentDiv_Title_Text'></div>");
        $(AjaxContentDiv).append(AjaxContentDiv_Title);

        var AjaxContentDiv_IFrame = document.createElement("iframe");
        $(AjaxContentDiv_IFrame).attr("id", "AjaxContentDiv_IFrame");
        //$(AjaxContentDiv_IFrame).attr("src", url);
        $(AjaxContentDiv_IFrame).attr("frameborder", "0");
        $(AjaxContentDiv_IFrame).css({ "width": (width - 5) + "px" });
        $(AjaxContentDiv_IFrame).css({ "height": (height - 33) + "px" });
        $(AjaxContentDiv).append(AjaxContentDiv_IFrame);

         

    }
    $("#AjaxContentDiv").width(width);
    $("#AjaxContentDiv").height(height);
    $("#AjaxContentDiv").css("top", $(document).scrollTop() + top);
    $("#AjaxContentDiv").css("left", ($(document).width() - $("#AjaxContentDiv").width()) / 2);

    $("#AjaxContentDiv_Title_Text").html(titleText);
    $("#CoverDiv").fadeTo("fast", 0.68);
    $("#AjaxContentDiv").fadeTo("slow", 0.98);
    $("#AjaxContentDiv_IFrame").attr("src", url);
    
}





function hideBox() {
    $("#CoverDiv").hide();
    $("#AjaxContentDiv").hide();
}

// 把对象移到document 的中央。
function ToDocCenter(id) {
    var l = ($(document).width() - $("#" + id).width()) / 2;
    var t = $(document).scrollTop() + 18;

    $("#" + id).css("left", l);
    $("#" + id).css("top", t);
}

// 把对象移到document 的不可视区域
function ToDocStealth(id) {
    $("#" + id).css("left", "-10000px");
    $("#" + id).css("top","-10000px");
}


// 显示遮盖层，层次居于1000
function ShowCoverDiv() {
    if (typeof ($("#CoverDiv")[0]) == 'undefined') {
        var CoverDiv = document.createElement("div");
        $("body").append(CoverDiv);
        $(CoverDiv).attr("id", "CoverDiv");
        $(CoverDiv).css({ "position": "absolute", "top": "0px", "width": "100%", "z-index": "1000", "display": "none", "background-color": "#86B7E1" });
        $(CoverDiv).height($(document).height());
    }
    $("#CoverDiv").fadeTo("slow",0.6);
}

// 隐藏遮盖层
function HideCoverDiv() {
    if (typeof ($("#CoverDiv")[0]) != 'undefined') {
        $("#CoverDiv").hide();
    }
}





















 


