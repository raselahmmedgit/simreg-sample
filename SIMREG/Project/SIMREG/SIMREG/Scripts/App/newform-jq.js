//-----------------------------------------------------
//start Add, Edit, Delete - Success Funtion
// Add NEWFORM Success Function
function AddNEWFORMSuccess() {

    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#addNEWFORMDialog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Data saved successfully.", "dialogSuccess");

        ResetNEWFORMGrid();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

// Edit NEWFORM Success Function
function EditNEWFORMSuccess() {
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#editNEWFORMDialog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Data updated successfully.", "dialogSuccess");

        ResetNEWFORMGrid();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

// Delete NEWFORM Success Function
function DeleteNEWFORMSuccess() {
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#deleteNEWFORMDailog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Data deleted successfully.", "dialogSuccess");

        ResetNEWFORMGrid();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();

    }
}
//end Add, Edit, Delete - Success Funtion
//-----------------------------------------------------

function ResetNEWFORMGrid() {
    $("#newformJQGrid").jqGrid().trigger("reloadGrid")
}


$(function () {
    //start JQGrid Script

    $("#newformJQGrid").jqGrid({
        url: "/NEWFORM/GetNEWFORMList",
        datatype: "json",
        mtype: 'POST',
        colNames: ['ID',
				  'MSISDNID',
                  'MSISDN TITLE',
				  'REQUESTED DATE',

                  'REQUESTEDBYID',
                  'REQUESTED BY',

                  'REQUESTEDTYPEID',
                  'REQUESTED TYPE',

                  'DELIVERED DATE',

                  'DELIVEREDBYID',
                  'DELIVERED BY',

                 'ActionLink'],
        colModel: [
			{ name: 'ID', index: 'ID', key: true, width: 0, hidden: true },
			{ name: 'MSISDNID', index: 'MSISDNID', width: 0, align: 'left', hidden: true },
            { name: 'MSISDNTITLE', index: 'MSISDNTITLE', align: 'left' },

            { name: 'REQUESTEDDATE', index: 'REQUESTEDDATE', align: 'left' },

            { name: 'REQUESTEDBYID', index: 'REQUESTEDBYID', width: 0, align: 'left', hidden: true },
            { name: 'REQUESTEDBYTITLE', index: 'REQUESTEDBYTITLE', align: 'left' },

            { name: 'REQUESTEDTYPEID', index: 'REQUESTEDTYPEID', width: 0, align: 'left', hidden: true },
            { name: 'REQUESTEDTYPETITLE', index: 'REQUESTEDTYPETITLE', align: 'left' },

            { name: 'DELIVEREDBYDATE', index: 'DELIVEREDBYDATE', align: 'left' },

            { name: 'DELIVEREDBYID', index: 'DELIVEREDBYID', width: 0, align: 'left', hidden: true },
            { name: 'DELIVEREDBYTITLE', index: 'DELIVEREDBYTITLE', align: 'left' },

			{ name: 'ActionLink', index: 'ActionLink', width: 150, align: 'center' }
			],
        rowNum: 10,                                //default page size
        rowList: [10, 20, 30, 40, 50],                 //option of page size
        height: "100%",                          //grid height
        width: "100%",                          //grid width
        sortname: 'id',                     //default sort column name
        sortorder: "desc",                       //sorting order
        viewrecords: true,                         //by default records show?
        multiselect: false                        //checkbox list

    });

    //end JQGrid Script

    //-------------------------------------------------------
    //start Add, Edit, Delete - Dialog, Click Event

    $("#addNEWFORMDialog").dialog({
        autoOpen: false,
        width: 500,
        resizable: false,
        modal: true,
        buttons: {
            "Add": function () {
                //make sure there is nothing on the message before we continue 
                $("#updateTargetId").html('');
                $("#addNEWFORMForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    //add NEWFORM
    $('#lnkAddNEWFORM').click(function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#addNEWFORMDialog');
        var viewUrl = linkObj.attr('href');

        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#addNEWFORMForm");
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

    //edit NEWFORM
    $("#editNEWFORMDialog").dialog({
        autoOpen: false,
        width: 500,
        resizable: false,
        closeOnEscape: false,
        modal: true,
        close: function (event, ui) {
            $(".popover").hide();
        },
        buttons: {
            "Edit": function () {
                //make sure there is nothing on the message before we continue   
                $("#updateTargetId").html('');
                $("#editNEWFORMForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }

    });

    $('#newformJQGrid tbody td a.lnkEditNEWFORM').live('click', function () {
        //$('#postDataTable tbody td .lnkEditNEWFORM').on('click', 'a', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#editNEWFORMDialog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#editNEWFORMForm");
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

    //delete NEWFORM
    $("#deleteNEWFORMDailog").dialog({
        autoOpen: false,
        width: 400,
        resizable: false,
        modal: true,
        buttons: {
            "Yes": function () {
                //make sure there is nothing on the message before we continue                         
                $("#updateTargetId").html('');
                $("#deleteNEWFORMForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#newformJQGrid tbody td a.lnkDeleteNEWFORM').live('click', function () {
        //$('#postDataTable tbody td .lnkDeleteNEWFORM').on('click', 'a', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#deleteNEWFORMDailog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#deleteNEWFORMForm");
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

    //For details NEWFORM
    $("#detailsNEWFORMDialog").dialog({
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

    $('#newformJQGrid tbody td a.lnkDetailsNEWFORM').live('click', function () {
        //$('#postDataTable tbody td .lnkDetailsNEWFORM').on('click', 'a', function () {

        var linkObj = $(this);
        var dialogDiv = $('#detailsNEWFORMDialog');
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