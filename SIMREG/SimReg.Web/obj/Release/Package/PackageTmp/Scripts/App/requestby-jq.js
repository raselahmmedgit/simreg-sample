//-----------------------------------------------------
//start Add, Edit, Delete - Success Funtion
// Add RequestBy Success Function
function AddRequestBySuccess() {

    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#addRequestByDialog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Data saved successfully.", "dialogSuccess");

        ResetRequestByGrid();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

// Edit RequestBy Success Function
function EditRequestBySuccess() {
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#editRequestByDialog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Data updated successfully.", "dialogSuccess");

        ResetRequestByGrid();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

// Delete RequestBy Success Function
function DeleteRequestBySuccess() {
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#deleteRequestByDailog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Data deleted successfully.", "dialogSuccess");

        ResetRequestByGrid();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();

    }
}
//end Add, Edit, Delete - Success Funtion
//-----------------------------------------------------

function ResetRequestByGrid() {
    $("#RequestByJQGrid").jqGrid().trigger("reloadGrid")
}


$(function () {
    //start JQGrid Script

    $("#RequestByJQGrid").jqGrid({
        url: "/RequestBy/GetRequestByList",
        datatype: "json",
        mtype: 'POST',
        colNames: ['REQUESTEDBYID',
				  'Title',

                 'Actions'],
        colModel: [
			{ name: 'REQUESTEDBYID', index: 'REQUESTEDBYID', key: true, width: 0, hidden: true },
            { name: 'TITLE', index: 'TITLE', width: 500, align: 'left' },

			{ name: 'ActionLink', index: 'ActionLink', width: 150, align: 'center' }
        ],
        pager: $('#RequestByJQGrid_Pager'),                        //pager div
        rowNum: 10,                                //default page size
        rowList: [10, 20, 30, 40, 50],                 //option of page size
        height: "100%",                          //grid height
        //width: "100%",                          //grid width
        width: "700px",
        sortname: 'REQUESTEDBYID',                     //default sort column name
        sortorder: "desc",                       //sorting order
        viewrecords: true,                         //by default records show?
        loadonce: true,
        caption: 'Request By List',
        multiselect: false                        //checkbox list

    });

    //end JQGrid Script

    //-------------------------------------------------------
    //start Add, Edit, Delete - Dialog, Click Event

    $("#addRequestByDialog").dialog({
        autoOpen: false,
        width: 500,
        resizable: false,
        modal: true,
        buttons: {
            "Save": function () {
                //make sure there is nothing on the message before we continue 
                $("#updateTargetId").html('');
                $("#addRequestByForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    //add RequestBy
    $('#lnkAddRequestBy').click(function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#addRequestByDialog');
        var viewUrl = linkObj.attr('href');

        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#addRequestByForm");
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

    //edit RequestBy
    $("#editRequestByDialog").dialog({
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
                $("#editRequestByForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }

    });

    $('#RequestByJQGrid tbody td a.lnkEditRequestBy').live('click', function () {
        //$('#postDataTable tbody td .lnkEditRequestBy').on('click', 'a', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#editRequestByDialog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#editRequestByForm");
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

    //delete RequestBy
    $("#deleteRequestByDailog").dialog({
        autoOpen: false,
        width: 400,
        resizable: false,
        modal: true,
        buttons: {
            "Yes": function () {
                //make sure there is nothing on the message before we continue                         
                $("#updateTargetId").html('');
                $("#deleteRequestByForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#RequestByJQGrid tbody td a.lnkDeleteRequestBy').live('click', function () {
        //$('#postDataTable tbody td .lnkDeleteRequestBy').on('click', 'a', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#deleteRequestByDailog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#deleteRequestByForm");
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

    //For details RequestBy
    $("#detailsRequestByDialog").dialog({
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

    $('#RequestByJQGrid tbody td a.lnkDetailsRequestBy').live('click', function () {
        //$('#postDataTable tbody td .lnkDetailsRequestBy').on('click', 'a', function () {

        var linkObj = $(this);
        var dialogDiv = $('#detailsRequestByDialog');
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