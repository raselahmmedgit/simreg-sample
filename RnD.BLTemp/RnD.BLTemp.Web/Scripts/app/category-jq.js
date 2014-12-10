//-----------------------------------------------------
//start Add, Edit, Delete - Success Funtion

// Add Category Success Function
function AddCategorySuccess() {

    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#addCategoryDialog').dialog('close');

        alert("Data saved successfully.");

    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

// Edit Category Success Function
function EditCategorySuccess() {
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#editCategoryDialog').dialog('close');

        alert("Data updated successfully.");

    }
    else {
        //show message in popup
        $("#updateTargetId").show();
    }
}

// Delete Category Success Function
function DeleteCategorySuccess() {
    if ($("#updateTargetId").html() == "True") {

        //now we can close the dialog
        $('#deleteCategoryDailog').dialog('close');

        alert("Data deleted successfully.");

    }
    else {
        //show message in popup
        $("#updateTargetId").show();

    }
}
//end Add, Edit, Delete - Success Funtion
//-----------------------------------------------------

$(function () {

    //-------------------------------------------------------
    //start Add, Edit, Delete - Dialog, Click Event

    $("#addCategoryDialog").dialog({
        autoOpen: false,
        width: 500,
        resizable: false,
        modal: true,
        buttons: {
            "Add": function () {
                //make sure there is nothing on the message before we continue 
                $("#updateTargetId").html('');
                $("#addCategoryForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    //add Category
    $('#lnkAddCategory').click(function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#addCategoryDialog');
        var viewUrl = linkObj.attr('href');

        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#addCategoryForm");
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

    //edit Category
    $("#editCategoryDialog").dialog({
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
                $("#editCategoryForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }

    });

    $('#categoryDataTable tbody td a.lnkEditCategory').live('click', function () {
        //$('#categoryDataTable tbody td .lnkEditCategory').on('click', 'a', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#editCategoryDialog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#editCategoryForm");
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

    //delete Category
    $("#deleteCategoryDailog").dialog({
        autoOpen: false,
        width: 400,
        resizable: false,
        modal: true,
        buttons: {
            "Yes": function () {
                //make sure there is nothing on the message before we continue                         
                $("#updateTargetId").html('');
                $("#deleteCategoryForm").submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#categoryDataTable tbody td a.lnkDeleteCategory').live('click', function () {
        //$('#categoryDataTable tbody td .lnkDeleteCategory').on('click', 'a', function () {

        //change the title of the dialog
        var linkObj = $(this);
        var dialogDiv = $('#deleteCategoryDailog');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            //validation
            var $form = $("#deleteCategoryForm");
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

    //For details Category
    $("#detailsCategoryDialog").dialog({
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

    $('#categoryDataTable tbody td a.lnkDetailsCategory').live('click', function () {
        //$('#categoryDataTable tbody td .lnkDetailsCategory').on('click', 'a', function () {

        var linkObj = $(this);
        var dialogDiv = $('#detailsCategoryDialog');
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