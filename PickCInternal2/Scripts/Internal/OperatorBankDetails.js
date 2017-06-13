$(function () {
    $('#frmBank').validate({
        rules: {
            txtBankName: {
                required: true
            },
            txtBranch: {
                required: true
            },
            txtAccNumber: {
                required: true
            },
            txtAccType: {
                required: true
            }
        }
    });
});
var gIndex = -1;
function EditBankDetails(index) {
    debugger;
    gIndex = index;
    var baseID = 'operator_BankDetails_' + index + '__';
    $('#txtBankName').val($('#' + baseID + 'txtBankName').val());
    $('#txtBranch').val($('#' + baseID + 'txtBranch').val());
    $('#txtAccNumber').val($('#' + baseID + 'txtAccNumber').val());
    $('#txtAccType').val($('#' + baseID + 'txtAccType').val());
    $('#bankDetailsModal').modal('show');

}
function DeleteBankDetails(index) {
    var id = '#operator_BankDetails_' + index + '__IsActive';
    $(id).val('False');
    $('#trRow_' + index).css({
        color: 'red',
        'text-decoration': 'line-through',
        'font-style': 'italic'
    });
}
function btnSaveBank() {
    debugger;
    if (!$('#frmBank').valid())
        return;

    if (gIndex != -1) {
        var baseID = 'operator_BankDetails_' + gIndex + '__';
        $('#' + baseID + 'txtBankName').val($('#txtBankName').val());
        $('#' + 'txtBankName_span_' + gIndex).text($('#txtBankName').val());

        $('#' + baseID + 'txtBranch').val($('#txtBranch').val());
        $('#' + 'txtBranch_span_' + gIndex).text($('#txtBranch').val());

        $('#' + baseID + 'txtAccNumber').val($('#txtAccNumber').val());
        $('#' + 'txtAccNumber_span_' + gIndex).text($('#txtAccNumber').val());

        $('#' + baseID + 'txtAccType').val($('#txtAccType').val());
        $('#' + 'txtAccType_span_' + gIndex).text($('#txtAccType').val());
    } else {
        var index = $('.trRowCss').length;
        var html = '<tr id="trRow_' + index + '">' +
                        '<td>' +
                            '<span id="txtBankName_span_' + index + '">' + $('#txtBankName').val() + '</span>' +
                            '<input id="operator_BankDetails_' + index + '__txtBankName" name="OPerator.BankDetails[' + index + '].BankName" type="hidden"  value="' + $('#txtBankName').val() + '">' +
                        '</td>' +
                        '<td>' +
                            '<span id="txtBranch_span_' + index + '">' + $('#txtBranch').val() + '</span>' +
                            '<input id="operator_BankDetails_' + index + '__txtBranch" name="OPerator.BankDetails[' + index + '].Branch" type="hidden" value="' + $('#txtBranch').val() + '">' +
                        '</td>' +
                         '<td>' +
                            '<span id="txtAccNumber_span_' + index + '">' + $('#txtAccNumber').val() + '</span>' +
                            '<input id="operator_BankDetails_' + index + '__txtAccNumber" name="OPerator.BankDetails[' + index + '].AccountNumber" type="hidden" value="' + $('#txtAccNumber').val() + '">' +
                        '</td>' +
                         '<td>' +
                            '<span id="txtAccType_span_' + index + '">' + $('#txtAccType').val() + '</span>' +
                            '<input id="operator_BankDetails_' + index + '__txtAccType" name="OPerator.BankDetails[' + index + '].AccountType" type="hidden" value="' + $('#txtAccType').val() + '">' +
                        '</td>' +
                        '<td>' +
                         '<a class="hand" onclick="EditBankDetails(\'' + index + '\')">Edit</a>&nbsp;|&nbsp;' +
                            '<a class="hand" onclick="DeleteBankDetails(\'' + index + '\')">Delete</a>' +
                        '</td>'
        '</tr>';
        $('#trBodyBank').append(html);
        $('#txtBankName').val('');
        $('#txtBranch').val('');
        $('#txtAccNumber').val('');
        $('#txtAccType').val('');
    }


    $('#bankDetailsModal').modal('hide');
    gIndex = -1;
}
function AddDriver(index) {
    gIndex = -1;
    $('#txtBankName, #txtBranch, #txtAccNumber, #txtAccType').val('');
    $('#bankDetailsModal').modal('show');
}