function DataPage_GoToPage() {
    var url = window.location.href;
    var pagenumber = $("#pagenumberIpt").val();
    pagenumber = parseInt(pagenumber);
    if ( isNaN( pagenumber)  || pagenumber == undefined) {
        pagenumber = 0;
        
    } else {
        pagenumber -= 1;
    }

    url = DataPage_changeURLPar(url, "CurrentPageIndex", pagenumber);
    window.location.href = url;
}
// 为url地址添加或更改参数值

function DataPage_changeURLPar(url, paramName, par_value) {

    var patternStr = "(?:[\\?&]{1})" + paramName + "=[^&]{0,}";
    var re = new RegExp(patternStr, "i"); // 创建正则表达式对象。

    var temp;
    try {
        temp = url.match(re);
    } catch (e)
      { }
    if (temp == null || temp == undefined) {
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