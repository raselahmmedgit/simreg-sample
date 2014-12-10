//-----------------------------------------------------
//start Add, Edit, Delete - Success Funtion

function RefreshDataList(url) {

    $("#dataTableZone").html('');

    $.get(url, function (data) {
        $("#dataTableZone").html(data);
    });

}

//Common Success Function
function DialogSuccess() {

    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#commonDialog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Data saved successfully.", "dialogSuccess");

        var url = "/Category/GetIndex";
        RefreshDataList(url);

    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

function DialogSuccess(message) {

    if ($("#updateTargetId").html() == "True") {


        var isSaveMode = $("#IsSaveMode").val();
        if (isSaveMode == "True") {
            $("#updateTargetId").html('');
            $("#updateTargetId").addClass('');
            $("#updateTargetId").html(message);
        }
        else {
            //now we can close the dialog
            $('#commonDialog').dialog('close');

            //JQDialogAlert mass, status
            JQDialogAlert(message, "dialogSuccess");


        }

        var url = "/Category/GetIndex";

        RefreshDataList(url);


    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

function DialogOpen(linkObj) {

    var dialogDiv = $('#commonDialog');
    var viewUrl = linkObj.attr('href');

    $.get(viewUrl, function (data) {
        dialogDiv.html(data);
        //validation
        var $form = $("#commonDialogForm");
        // Unbind existing validation
        $form.unbind();
        $form.data("validator", null);
        // Check document for changes
        $.validator.unobtrusive.parse(document);
        // Re add validation with changes
        $form.validate($form.data("unobtrusiveValidation").options);
        //open dialog
        dialogDiv.dialog('open');
    });

}

//end Add, Edit, Delete - Success Funtion
//-----------------------------------------------------

$(function () {

    //-------------------------------------------------------
    //start Add, Edit, Delete - Dialog, Click Event

    $("#commonDialog").dialog({
        autoOpen: false,
        width: 500,
        resizable: false,
        modal: true
    });

    //add Category
    $('#lnkAddCategory').click(function () {

        //change the title of the dialog
        var linkObj = $(this);
        DialogOpen(linkObj);

        return false;

    });

    $('#categoryDataTable tbody td a.lnkEditCategory').live('click', function () {
        //$('#categoryDataTable tbody td .lnkEditCategory').on('click', 'a', function () {

        //change the title of the dialog
        var linkObj = $(this);
        DialogOpen(linkObj);

        return false;

    });

    $('#categoryDataTable tbody td a.lnkDeleteCategory').live('click', function () {
        //$('#categoryDataTable tbody td .lnkDeleteCategory').on('click', 'a', function () {

        //change the title of the dialog
        var linkObj = $(this);
        DialogOpen(linkObj);

        return false;

    });

    $('#categoryDataTable tbody td a.lnkDetailsCategory').live('click', function () {
        //$('#categoryDataTable tbody td .lnkDetailsCategory').on('click', 'a', function () {

        var linkObj = $(this);
        DialogOpen(linkObj);

        return false;

    });

    //end Add, Edit, Delete - Dialog, Click Event
    //-------------------------------------------------------

});