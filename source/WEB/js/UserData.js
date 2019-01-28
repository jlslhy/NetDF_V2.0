
// 保存userdata prefix:保存值类别 obj 保存的对象
function SaveUserDataForInput(vType, obj) {
    obj.setAttribute(obj.id, obj.value);
    obj.save(vType);
}

function GetUserDataForInput(vType, obj) {
    obj.load(vType);
    return obj.getAttribute(obj.id);
}


function SaveUserData(vType, obj, val) {
    obj.setAttribute(obj.id, val);
    obj.save(vType);
}
function GetUserData(vType, obj) {
    obj.load(vType);
    return obj.getAttribute(obj.id);
}
 