$(document).ready(function () {
    $("#aSearch").click(function () {
        var aTag = document.getElementById("aSearch");
        var d = document.getElementById("divSearch");
        if (aTag.style.display == 'block') {
            d.style.display = 'block';
            aTag.style.display = 'none';
        } else {
            d.style.display = 'none';
            aTag.style.display = 'block';
        }
    });
    $("#closeSearch").click(function () {
        var aTag = document.getElementById("aSearch");
        var d = document.getElementById("divSearch");
        if (d.style.display == 'block') {
            aTag.style.display = 'block';
            d.style.display = 'none';
        } else {
            aTag.style.display = 'none';
            d.style.display = 'block';
        }
    });
});

function ClearAllControls() {
    for (var i = 0; i < document.forms[0].length; i++) {
        var doc = document.forms[0].elements[i];
        switch (doc.type) {
            case "text":
                doc.value = "";
                break;

            case "checkbox":
                doc.checked = false;
                break;

            case "radio":
                doc.checked = false;
                break;

            case "select-one":
                doc.options[doc.selectedIndex].selected = false;
                break;

            case "select-multiple":
                while (doc.selectedIndex != -1) {
                    var indx = doc.selectedIndex;
                    doc.options[indx].selected = false;
                }
                doc.selected = false;
                break;
            default:
                break;
        }
    }
}