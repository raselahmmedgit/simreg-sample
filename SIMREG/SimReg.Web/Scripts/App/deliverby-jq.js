//-----------------------------------------------------
//start Add, Edit, Delete - Success Funtion
// Add DeliverBy Success Function
function AddDeliverBySuccess() {

    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#addDeliverByDialog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Data saved successfully.", "dialogSuccess");

        ResetDeliverByGrid();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

// Edit DeliverBy Success Function
function EditDeliverBySuccess() {
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#editDeliverByDialog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Data updated successfully.", "dialogSuccess");

        ResetDeliverByGrid();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

// Delete DeliverBy Success Function
function DeleteDeliverBySuccess() {
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#deleteDeliverByDailog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Data deleted successfully.", "dialogSuccess");

        ResetDeliverByGrid();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();

    }
}
//end Add, Edit, Delete - Success Funtion
//-----------------------------------------------------

function ResetDeliverByGrid() {
    $("#DeliverByJQGrid").jqGrid().trigger("reloadGrid")
}


$(function () {
    //start JQGrid Script

    $("#DeliverByJQGrid").jqGrid({
        url: "/DeliverBy/GetDeliverByList",
        datatype: "json",
        mtype: 'POST',
        colNames: ['DELIVEREDBYID',
				  'Title',
                  'Login Name',
                  'Can Edit',

                 'Actions'],
        colModel: [
			{ name: 'DELIVEREDBYID', index: 'DELIVEREDBYID', key: true, width: 0, hidden: true },
            { name: 'TITLE', index: 'TITLE', width: 300, align: 'left' },
            { name: 'USERNAME', index: 'USERNAME', width: 100, align: 'left' },
            { name: 'CANEDIT', index: 'CANEDIT', width: 50, align: 'left' },

			{ name: 'ActionLink', index: 'ActionLink', width: 150, align: 'center' }
        ],
        pager: $('#DeliverByJQGrid_Pager'),                        //pager div
        rowNum: 10,                                //default page size
        rowList: [10, 20, 30, 40, 50],                 //option of page size
        height: "100%",                          //grid height
        //width: "100%",                          //grid width
        width: "700px",
        sortname: 'DELIVEREDBYID',                     //default sort column name
        sortorder: "desc",                       //sorting order
        viewrecords: true,                         //by default records show?
        loadonce: true,
        caption: 'Deliver By List',
        multiselect: false                        //checkbox list

    });

    //end JQGrid Script

    //-------------------------------------------------------
    //start Add, Edit, Delete - Dialog, Click Event

    $("#addDeliverByDialog").dialog({
        autoOpen: false,
        width: 500,
        resizable: false,
        modal: true,
        buttons: {
            "Save": function () {
                //make sure there is nothing on the message before we continue 
                $("#updateTargetId").html('');
                $("#addDeliverByForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    //add DeliverBy
    $('#lnkAddDeliverBy').click(function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#addDeliverByDialog');
        var viewUrl = linkObj.attr('href');

        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#addDeliverByForm");
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

    //edit DeliverBy
    $("#editDeliverByDialog").dialog({
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
                $("#editDeliverByForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }

    });

    $('#DeliverByJQGrid tbody td a.lnkEditDeliverBy').live('click', function () {
        //$('#postDataTable tbody td .lnkEditDeliverBy').on('click', 'a', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#editDeliverByDialog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#editDeliverByForm");
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

    //delete DeliverBy
    $("#deleteDeliverByDailog").dialog({
        autoOpen: false,
        width: 400,
        resizable: false,
        modal: true,
        buttons: {
            "Yes": function () {
                //make sure there is nothing on the message before we continue                         
                $("#updateTargetId").html('');
                $("#deleteDeliverByForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#DeliverByJQGrid tbody td a.lnkDeleteDeliverBy').live('click', function () {
        //$('#postDataTable tbody td .lnkDeleteDeliverBy').on('click', 'a', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#deleteDeliverByDailog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#deleteDeliverByForm");
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

    //For details DeliverBy
    $("#detailsDeliverByDialog").dialog({
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

    $('#DeliverByJQGrid tbody td a.lnkDetailsDeliverBy').live('click', function () {
        //$('#postDataTable tbody td .lnkDetailsDeliverBy').on('click', 'a', function () {

        var linkObj = $(this);
        var dialogDiv = $('#detailsDeliverByDialog');
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