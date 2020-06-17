
// ReSharper disable InconsistentNaming
var pdf = new jsPDF('p', 'in', 'letter');

pdf.addHTML(document.getElementById('printDiv'), function () {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!

    var yyyy = today.getFullYear();
    var hh = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    var pdfName = dd + "" + mm + "" + yyyy + "" + hh + "" + m + "" + s;

    //pdf.save("Invoice-" + pdfName + '.pdf');
    alert("Rename file after downloaded to your machine...");
    pdf.save("DoyinGo_Report-" + pdfName + '.pdf');

});
