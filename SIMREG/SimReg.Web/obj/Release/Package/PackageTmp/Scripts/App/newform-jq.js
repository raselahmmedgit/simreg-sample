//-----------------------------------------------------
//start Add, Edit, Delete - Success Funtion
// Add SimRegister Success Function
function AddSimRegisterSuccess() {

    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#addSimRegisterDialog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Data saved successfully.", "dialogSuccess");

        ResetSimRegisterGrid();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

// Edit SimRegister Success Function
function EditSimRegisterSuccess() {
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#editSimRegisterDialog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Data updated successfully.", "dialogSuccess");

        ResetSimRegisterGrid();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

// Delete SimRegister Success Function
function DeleteSimRegisterSuccess() {
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#deleteSimRegisterDailog').dialog('close');

        //JQDialogAlert mass, status
        JQDialogAlert("Data deleted successfully.", "dialogSuccess");

        ResetSimRegisterGrid();

    }
    else {
        //show message in popup
        $("#updateTargetId").show();

    }
}
//end Add, Edit, Delete - Success Funtion
//-----------------------------------------------------

function ResetSimRegisterGrid() {

    var msisdnTitle = $("#MSISDNTITLE").val() == "" ? "" : $("#MSISDNTITLE").val();
    var requestById = $("#REQUESTEDBYID").val() == "" ? "" : $("#REQUESTEDBYID").val();
    var requestFromDate = $("#REQUESTEDDATEFrom").val() == "" ? "" : $("#REQUESTEDDATEFrom").val();
    var requestToDate = $("#REQUESTEDDATETo").val() == "" ? "" : $("#REQUESTEDDATETo").val();
    var deliverFromDate = $("#DELIVEREDBYDATEFrom").val() == "" ? "" : $("#DELIVEREDBYDATEFrom").val();
    var deliverToDate = $("#DELIVEREDBYDATETo").val() == "" ? "" : $("#DELIVEREDBYDATETo").val();

    //requestFromDate, requestToDate, deliverFromDate, deliverToDate

    var url = "";
    url = "/SimRegister/GetSimRegisterList?msisdnTitle=" + msisdnTitle + "&requestById=" + requestById + "&requestFromDate=" + requestFromDate + "&requestToDate=" + requestToDate + "&deliverFromDate=" + deliverFromDate + "&deliverToDate=" + deliverToDate;
    $("#SimRegisterJQGrid").setGridParam({ url: url });
    $("#SimRegisterJQGrid").trigger("reloadGrid");

}

//ClearSimRegisterGrid
function ClearSimRegisterGrid() {

    $("#MSISDNTITLE").val("");
    $("#REQUESTEDBYID").val(0);
    $("#REQUESTEDDATEFrom").val("");
    $("#REQUESTEDDATETo").val("");
    $("#DELIVEREDBYDATEFrom").val("");
    $("#DELIVEREDBYDATETo").val("");

    $("#SimRegisterJQGrid").trigger("reloadGrid");

}


function ResetSimRegisterSearchRptGrid() {

    var msisdnTitle = $("#MSISDNTITLE").val() == "" ? "" : $("#MSISDNTITLE").val();
    var requestById = $("#REQUESTEDBYID").val() == "" ? "" : $("#REQUESTEDBYID").val();
    var requestTypeId = $("#REQUESTEDTYPEID").val() == "" ? "" : $("#REQUESTEDTYPEID").val();
    var deliverById = $("#DELIVEREDBYID").val() == "" ? "" : $("#DELIVEREDBYID").val();
    var requestFromDate = $("#REQUESTEDDATEFrom").val() == "" ? "" : $("#REQUESTEDDATEFrom").val();
    var requestToDate = $("#REQUESTEDDATETo").val() == "" ? "" : $("#REQUESTEDDATETo").val();
    var deliverFromDate = $("#DELIVEREDBYDATEFrom").val() == "" ? "" : $("#DELIVEREDBYDATEFrom").val();
    var deliverToDate = $("#DELIVEREDBYDATETo").val() == "" ? "" : $("#DELIVEREDBYDATETo").val();

    //requestFromDate, requestToDate, deliverFromDate, deliverToDate

    var url = "";
    url = "/SimRegister/GetSimRegisterListByParam?msisdnTitle=" + msisdnTitle + "&requestById=" + requestById + "&requestTypeId=" + requestTypeId + "&deliverById=" + deliverById + "&requestFromDate=" + requestFromDate + "&requestToDate=" + requestToDate + "&deliverFromDate=" + deliverFromDate + "&deliverToDate=" + deliverToDate;
    $("#SimRegisterSearchJQGrid").setGridParam({ url: url });
    $("#SimRegisterSearchJQGrid").trigger("reloadGrid");

}

//ClearSimRegisterSearchRptGrid
function ClearSimRegisterSearchRptGrid() {

    $("#MSISDNTITLE").val("");
    $("#REQUESTEDBYID").val(0);
    $("#REQUESTEDTYPEID").val(0);
    $("#DELIVEREDBYID").val(0);
    $("#REQUESTEDDATEFrom").val("");
    $("#REQUESTEDDATETo").val("");
    $("#DELIVEREDBYDATEFrom").val("");
    $("#DELIVEREDBYDATETo").val("");

    $("#SimRegisterSearchJQGrid").trigger("reloadGrid");

}

$(function () {

    //start JQ Input Mask

    $("#MSISDNTITLE").mask("1999999999");

    //end JQ Input Mask

    //start JQGrid Script

    var msisdnTitle = $("#MSISDNTITLE").val() == "" ? "" : $("#MSISDNTITLE").val();
    var requestById = $("#REQUESTEDBYID").val() == "" ? "" : $("#REQUESTEDBYID").val();
    var requestTypeId = $("#REQUESTEDTYPEID").val() == "" ? "" : $("#REQUESTEDTYPEID").val();
    var deliverById = $("#DELIVEREDBYID").val() == "" ? "" : $("#DELIVEREDBYID").val();
    var requestFromDate = $("#REQUESTEDDATEFrom").val() == "" ? "" : $("#REQUESTEDDATEFrom").val();
    var requestToDate = $("#REQUESTEDDATETo").val() == "" ? "" : $("#REQUESTEDDATETo").val();
    var deliverFromDate = $("#DELIVEREDBYDATEFrom").val() == "" ? "" : $("#DELIVEREDBYDATEFrom").val();
    var deliverToDate = $("#DELIVEREDBYDATETo").val() == "" ? "" : $("#DELIVEREDBYDATETo").val();

    $("#SimRegisterJQGrid").jqGrid({
        //url: "/SimRegister/GetSimRegisterList",
        url: "/SimRegister/GetSimRegisterList?msisdnTitle=" + msisdnTitle + "&requestById=" + requestById + "&requestFromDate=" + requestFromDate + "&requestToDate=" + requestToDate + "&deliverFromDate=" + deliverFromDate + "&deliverToDate=" + deliverToDate,
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

                 'Actions'],
        colModel: [
			{ name: 'ID', index: 'ID', key: true, width: 0, hidden: true },
			{ name: 'MSISDNID', index: 'MSISDNID', width: 0, align: 'left', hidden: true },
            { name: 'MSISDNTITLE', index: 'MSISDNTITLE', width: 120, align: 'left' },

            { name: 'REQUESTEDDATE', index: 'REQUESTEDDATE', width: 120, align: 'left' },

            { name: 'REQUESTEDBYID', index: 'REQUESTEDBYID', width: 0, align: 'left', hidden: true },
            { name: 'REQUESTEDBYTITLE', index: 'REQUESTEDBYTITLE', width: 250, align: 'left' },

            { name: 'REQUESTEDTYPEID', index: 'REQUESTEDTYPEID', width: 0, align: 'left', hidden: true },
            { name: 'REQUESTEDTYPETITLE', index: 'REQUESTEDTYPETITLE', width: 250, align: 'left' },

            { name: 'DELIVEREDBYDATE', index: 'DELIVEREDBYDATE', width: 120, align: 'left' },

            { name: 'DELIVEREDBYID', index: 'DELIVEREDBYID', width: 0, align: 'left', hidden: true },
            { name: 'DELIVEREDBYTITLE', index: 'DELIVEREDBYTITLE', width: 200, align: 'left' },

			{ name: 'ActionLink', index: 'ActionLink', width: 150, align: 'center' }
        ],
        pager: $('#SimRegisterJQGrid_Pager'),                        //pager div
        pagerpos: 'left',
        rowNum: 10,                                //default page size
        rowList: [10, 20, 30, 40, 50],                 //option of page size
        rownumbers: true,
        height: "100%",                          //grid height
        //width: "100%",                          //grid width
        //width: "800px",
        sortname: 'ID',                     //default sort column name
        sortorder: "desc",                       //sorting order
        viewrecords: true,                         //by default records show?
        //loadonce: true,
        caption: 'Sim Register List',
        multiselect: false                        //checkbox list

    });

    $("#SimRegisterSearchJQGrid").jqGrid({
        //url: "/SimRegister/GetSimRegisterListByParam",
        url: "/SimRegister/GetSimRegisterListByParam?msisdnTitle=" + msisdnTitle + "&requestById=" + requestById + "&requestTypeId=" + requestTypeId + "&deliverById=" + deliverById + "&requestFromDate=" + requestFromDate + "&requestToDate=" + requestToDate + "&deliverFromDate=" + deliverFromDate + "&deliverToDate=" + deliverToDate,
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
                  'DELIVERED BY'],
        colModel: [
			{ name: 'ID', index: 'ID', key: true, width: 0, hidden: true },
			{ name: 'MSISDNID', index: 'MSISDNID', width: 0, align: 'left', hidden: true },
            { name: 'MSISDNTITLE', index: 'MSISDNTITLE', width: 120, align: 'left' },

            { name: 'REQUESTEDDATE', index: 'REQUESTEDDATE', width: 120, align: 'left' },

            { name: 'REQUESTEDBYID', index: 'REQUESTEDBYID', width: 0, align: 'left', hidden: true },
            { name: 'REQUESTEDBYTITLE', index: 'REQUESTEDBYTITLE', width: 250, align: 'left' },

            { name: 'REQUESTEDTYPEID', index: 'REQUESTEDTYPEID', width: 0, align: 'left', hidden: true },
            { name: 'REQUESTEDTYPETITLE', index: 'REQUESTEDTYPETITLE', width: 250, align: 'left' },

            { name: 'DELIVEREDBYDATE', index: 'DELIVEREDBYDATE', width: 120, align: 'left' },

            { name: 'DELIVEREDBYID', index: 'DELIVEREDBYID', width: 0, align: 'left', hidden: true },
            { name: 'DELIVEREDBYTITLE', index: 'DELIVEREDBYTITLE', width: 200, align: 'left' },

        ],
        pager: $('#SimRegisterSearchJQGrid_Pager'),                        //pager div
        pagerpos: 'center',
        rowNum: 10,                                //default page size
        rowList: [10, 20, 30, 40, 50],                 //option of page size
        height: "100%",                          //grid height
        //width: "100%",                          //grid width
        //width: "800px",
        sortname: 'ID',                     //default sort column name
        sortorder: "desc",                       //sorting order
        viewrecords: true,                         //by default records show?
        //loadonce: true,
        caption: 'Sim Register Report List',
        multiselect: false                        //checkbox list

    });

    //end JQGrid Script

    //SimRegister Search
    $('#btnSimRegisterSearch').click(function () {
        ResetSimRegisterGrid();
        return false;

    });

    //SimRegister Clear
    $('#btnSimRegisterClear').click(function () {
        ClearSimRegisterGrid();
        return false;

    });

    //
    //SimRegister Search Rpt
    $('#btnSimRegisterSearchRpt').click(function () {
        ResetSimRegisterSearchRptGrid();
        return false;

    });

    //SimRegister Clear Rpt
    $('#btnSimRegisterClearRpt').click(function () {
        ClearSimRegisterSearchRptGrid();
        return false;

    });

    //-------------------------------------------------------
    //start Add, Edit, Delete - Dialog, Click Event

    $("#addSimRegisterDialog").dialog({
        autoOpen: false,
        width: 500,
        resizable: false,
        modal: true,
        buttons: {
            "Save": function () {
                //make sure there is nothing on the message before we continue 
                $("#updateTargetId").html('');
                $("#addSimRegisterForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    //add SimRegister
    $('#lnkAddSimRegister').click(function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#addSimRegisterDialog');
        var viewUrl = linkObj.attr('href');

        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#addSimRegisterForm");
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

    //edit SimRegister
    $("#editSimRegisterDialog").dialog({
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
                $("#editSimRegisterForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }

    });

    $('#SimRegisterJQGrid tbody td a.lnkEditSimRegister').live('click', function () {
        //$('#postDataTable tbody td .lnkEditSimRegister').on('click', 'a', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#editSimRegisterDialog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#editSimRegisterForm");
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

    //delete SimRegister
    $("#deleteSimRegisterDailog").dialog({
        autoOpen: false,
        width: 400,
        resizable: false,
        modal: true,
        buttons: {
            "Yes": function () {
                //make sure there is nothing on the message before we continue                         
                $("#updateTargetId").html('');
                $("#deleteSimRegisterForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#SimRegisterJQGrid tbody td a.lnkDeleteSimRegister').live('click', function () {
        //$('#postDataTable tbody td .lnkDeleteSimRegister').on('click', 'a', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#deleteSimRegisterDailog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#deleteSimRegisterForm");
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

    //For details SimRegister
    $("#detailsSimRegisterDialog").dialog({
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

    $('#SimRegisterJQGrid tbody td a.lnkDetailsSimRegister').live('click', function () {
        //$('#postDataTable tbody td .lnkDetailsSimRegister').on('click', 'a', function () {

        var linkObj = $(this);
        var dialogDiv = $('#detailsSimRegisterDialog');
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