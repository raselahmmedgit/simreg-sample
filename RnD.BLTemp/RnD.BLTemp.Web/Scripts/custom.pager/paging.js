//Start Paging

function Loadpage() {
    try {

        //reload page using new page size
        var url = $(location).attr('href');
        var index = "Index=1";

        if (url.indexOf('?Index') > 0) {
            index = url.split('?')[1];
            index = index.split('&')[0];
        }

        var page = $('#hdSize').val();

        if (page > 0) {

            url = url.split('?')[0] + "?" + index + "&Size=" + page + "";
            window.location.href = url;

        }


    } catch (e) {
        alert(e);
    }
}

function Loadpage(page, index) {
    try {

        //reload page using new page size
        var url = $(location).attr('href');

        var innerIndex = "Index=" + index;

        if (url.indexOf('?Index') > 0) {

            innerIndex = url.split('?')[1];
            innerIndex = innerIndex.split('&')[0];

        }

        if (page > 0) {

            url = url.split('?')[0] + "?" + innerIndex + "&Size=" + page + "";
            window.location.href = url;

        }

    } catch (e) {
        alert(e);
    }
}

$(document).ready(function () {

    var hdPage = $('#hdSize').val();

    $('#ddlPageNumber').val(hdPage);

    $('#ddlPageNumber').on('change', function (e) {

        var optionSelected = $("option:selected", this);
        var valueSelected = this.value;

        var page = valueSelected;
        var index = $('#hdIndex').val();

        Loadpage(page, index);

    });


});

//End Paging