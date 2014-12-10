//-----------------------------------------------------
//start Add, Edit, Delete - Success Funtion
// Add RequestType Success Function
function AddRequestTypeSuccess() {

    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#addRequestTypeDialog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Data saved successfully.", "dialogSuccess");

        ResetRequestTypeGrid();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

// Edit RequestType Success Function
function EditRequestTypeSuccess() {
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#editRequestTypeDialog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Data updated successfully.", "dialogSuccess");

        ResetRequestTypeGrid();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

// Delete RequestType Success Function
function DeleteRequestTypeSuccess() {
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#deleteRequestTypeDailog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Data deleted successfully.", "dialogSuccess");

        ResetRequestTypeGrid();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();

    }
}
//end Add, Edit, Delete - Success Funtion
//-----------------------------------------------------

function ResetRequestTypeGrid() {
    $("#RequestTypeJQGrid").jqGrid().trigger("reloadGrid")
}


$(function () {
    //start JQGrid Script

    $("#RequestTypeJQGrid").jqGrid({
        url: "/RequestType/GetRequestTypeList",
        datatype: "json",
        mtype: 'POST',
        colNames: ['REQUESTEDTYPEID',
				  'Title',

                 'Actions'],
        colModel: [
			{ name: 'REQUESTEDTYPEID', index: 'REQUESTEDTYPEID', key: true, width: 0, hidden: true },
            { name: 'TITLE', index: 'TITLE', width: 500, align: 'left' },

			{ name: 'ActionLink', index: 'ActionLink', width: 150, align: 'center' }
        ],
        pager: $('#RequestTypeJQGrid_Pager'),                        //pager div
        rowNum: 10,                                //default page size
        rowList: [10, 20, 30, 40, 50],                 //option of page size
        height: "100%",                          //grid height
        //width: "100%",                          //grid width
        width: "700px",
        sortname: 'REQUESTEDTYPEID',                     //default sort column name
        sortorder: "desc",                       //sorting order
        viewrecords: true,                         //by default records show?
        loadonce: true,
        caption: 'Request Type List',
        multiselect: false                        //checkbox list

    });

    //end JQGrid Script

    //-------------------------------------------------------
    //start Add, Edit, Delete - Dialog, Click Event

    $("#addRequestTypeDialog").dialog({
        autoOpen: false,
        width: 500,
        resizable: false,
        modal: true,
        buttons: {
            "Save": function () {
                //make sure there is nothing on the message before we continue 
                $("#updateTargetId").html('');
                $("#addRequestTypeForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    //add RequestType
    $('#lnkAddRequestType').click(function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#addRequestTypeDialog');
        var viewUrl = linkObj.attr('href');

        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#addRequestTypeForm");
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
        return false;

    });

    //edit RequestType
    $("#editRequestTypeDialog").dialog({
        autoOpen: false,
        width: 500,
        resizable: false,
        closeOnEscape: false,
        modal: true,
        close: function (event, ui) {
            $(".popover").hide();
        },
        buttons: {
            "Update": function () {
                //make sure there is nothing on the message before we continue   
                $("#updateTargetId").html('');
                $("#editRequestTypeForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }

    });

    $('#RequestTypeJQGrid tbody td a.lnkEditRequestType').live('click', function () {
        //$('#postDataTable tbody td .lnkEditRequestType').on('click', 'a', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#editRequestTypeDialog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#editRequestTypeForm");
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
        return false;

    });

    //delete RequestType
    $("#deleteRequestTypeDailog").dialog({
        autoOpen: false,
        width: 400,
        resizable: false,
        modal: true,
        buttons: {
            "Yes": function () {
                //make sure there is nothing on the message before we continue                         
                $("#updateTargetId").html('');
                $("#deleteRequestTypeForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#RequestTypeJQGrid tbody td a.lnkDeleteRequestType').live('click', function () {
        //$('#postDataTable tbody td .lnkDeleteRequestType').on('click', 'a', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#deleteRequestTypeDailog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#deleteRequestTypeForm");
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
        return false;

    });

    //For details RequestType
    $("#detailsRequestTypeDialog").dialog({
        autoOpen: false,
        width: 500,
        resizable: false,
        modal: true,
        buttons: {
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#RequestTypeJQGrid tbody td a.lnkDetailsRequestType').live('click', function () {
        //$('#postDataTable tbody td .lnkDetailsRequestType').on('click', 'a', function () {

        var linkObj = $(this);
        var dialogDiv = $('#detailsRequestTypeDialog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            dialogDiv.dialog('open');
        });
        return false;

    });

    //end Add, Edit, Delete - Dialog, Click Event
    //-------------------------------------------------------

});