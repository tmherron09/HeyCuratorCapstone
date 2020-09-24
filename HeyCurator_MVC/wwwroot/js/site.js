// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$('.loadingButton').attr("disabled", true)
$('.loadingButton').addClass("cursor-not-allowed");

$(document).ready(function () {

    //$('.loadingButton').removeAttr("disabled", true)
    $('.loadingButton').attr("disabled", false)
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
}

function updateRecordModal(button) {
    $('#modalContainer').load('/item/ModifyRecordPartial/' + button.getAttribute('data-id'));
    $('#displayModal').modal('show');
}


