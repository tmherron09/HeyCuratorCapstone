$('.loadingButton').attr("disabled", true)

$(document).ready(function () {

    $('.loadingButton').removeAttr("disabled", true)
});

$(function () {
    $('#modalIcon').on('click', function () {
        $('#modalContainer').load('/item/CreateRecordPartial/' + this.getAttribute('data-id'));
        $('#displayModal').modal('show');
    })
});

function viewExpiredModal(button) {
    $('#modalContainer').load('/item/CreateRecordPartial/' + button.getAttribute('data-id'));
    $('#displayModal').modal('show');
};