function FullScreen() {
    $("#Frame0", window.parent.document)[0].rows = "0px,*";
    $("#Frame1", window.parent.document)[0].cols = "0px,*";
}

function WinRestore() {
    $("#Frame0", window.parent.document)[0].rows = "100px,*";
    $("#Frame1", window.parent.document)[0].cols = "180px,*";
}