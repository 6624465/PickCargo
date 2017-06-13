$(function () {
    $('#frmDriver').validate({
        rules: {
            operatorDriverList_DriverName: {
                required: true
            },
            operatorDriverList_DriverLicenseNo: {
                required: true
            },
            operatorDriverList_DriverMobileNo: {
                required: true
            },
            operatorDriverList_VehicleNo: {
                required: true
            }
        }
    });
});
var gIndex = -1;
function EditOperatorDriver(index) {
    debugger;
    gIndex = index;
    var baseID = 'driver_OperatorDriverList_' + index + '__';
    $('#operatorDriverList_DriverName').val($('#' + baseID + 'operatorDriverList_DriverName').val());
    $('#operatorDriverList_DriverLicenseNo').val($('#' + baseID + 'operatorDriverList_DriverLicenseNo').val());
    $('#operatorDriverList_DriverMobileNo').val($('#' + baseID + 'operatorDriverList_DriverMobileNo').val());
    $('#operatorDriverList_VehicleNo').val($('#' + baseID + 'operatorDriverList_VehicleNo').val());
    $('#DriverModal').modal('show');

}
function DeleteOperatorDriver(index) {
    var id = '#driver_OperatorDriverList_' + index + '__IsActive';
    $(id).val('False');
    $('#trRow_' + index).css({
        color: 'red',
        'text-decoration': 'line-through',
        'font-style': 'italic'
    });
}
function btnSavedriver() {
    debugger;
    if (!$('#frmDriver').valid())
        return;

    if (gIndex != -1) {
        var baseID = 'driver_OperatorDriverList_' + gIndex + '__';
        $('#' + baseID + 'operatorDriverList_DriverName').val($('#operatorDriverList_DriverName').val());
        $('#' + 'operatorDriverList_DriverName_span_' + gIndex).text($('#operatorDriverList_DriverName').val());

        $('#' + baseID + 'operatorDriverList_DriverLicenseNo').val($('#operatorDriverList_DriverLicenseNo').val());
        $('#' + 'operatorDriverList_DriverLicenseNo_span_' + gIndex).text($('#operatorDriverList_DriverLicenseNo').val());

        $('#' + baseID + 'operatorDriverList_DriverMobileNo').val($('#operatorDriverList_DriverMobileNo').val());
        $('#' + 'operatorDriverList_DriverMobileNo_span_' + gIndex).text($('#operatorDriverList_DriverMobileNo').val());

        $('#' + baseID + 'operatorDriverList_VehicleNo').val($('#operatorDriverList_VehicleNo').val());
        $('#' + 'operatorDriverList_VehicleNo_span_' + gIndex).text($('#operatorDriverList_VehicleNo').val());
    } else {
        var index = $('.trRowCss').length;
        var html = '<tr id="trRow_' + index + '">' +
                        '<td>' +
                            '<span id="operatorDriverList_DriverName_span_' + index + '">' + $('#operatorDriverList_DriverName option:selected').text() + '</span>' +
                            '<input id="driver_OperatorDriverList_' + index + '__operatorDriverList_DriverName" name="OPerator.OperatorDriverList[' + index + '].DriverName" type="hidden"  value="' + $('#operatorDriverList_DriverName').val() + '">' +
                        '</td>' +
                        '<td>' +
                            '<span id="operatorDriverList_DriverLicenseNo_span_' + index + '">' + $('#operatorDriverList_DriverLicenseNo').val() + '</span>' +
                            '<input id="driver_OperatorDriverList_' + index + '__operatorDriverList_DriverLicenseNo" name="OPerator.OperatorDriverList[' + index + '].DriverLicenseNo" type="hidden" value="' + $('#operatorDriverList_DriverLicenseNo').val() + '">' +
                        '</td>' +
                         '<td>' +
                            '<span id="operatorDriverList_DriverMobileNo_span_' + index + '">' + $('#operatorDriverList_DriverMobileNo').val() + '</span>' +
                            '<input id="driver_OperatorDriverList_' + index + '__operatorDriverList_DriverMobileNo" name="OPerator.OperatorDriverList[' + index + '].DriverMobileNo" type="hidden" value="' + $('#operatorDriverList_DriverMobileNo').val() + '">' +
                        '</td>' +
                         '<td>' +
                            '<span id="operatorDriverList_VehicleNo_span_' + index + '">' + $('#operatorDriverList_VehicleNo').val() + '</span>' +
                            '<input id="driver_OperatorDriverList_' + index + '__operatorDriverList_VehicleNo" name="OPerator.OperatorDriverList[' + index + '].VehicleattachedNo" type="hidden" value="' + $('#operatorDriverList_VehicleNo').val() + '">' +
                        '</td>' +
                        '<td>' +
                         '<a class="hand" onclick="EditOperatorDriver(\'' + index + '\')">Edit</a>&nbsp;|&nbsp;' +
                            '<a class="hand" onclick="DeleteOperatorDriver(\'' + index + '\')">Delete</a>' +
                        '</td>'
                    '</tr>';
                    $('#trBodyDriver').append(html);
                    $('#operatorDriverList_DriverName').val('');
                    $('#operatorDriverList_DriverLicenseNo').val('');
                    $('#operatorDriverList_DriverMobileNo').val('');
                    $('#operatorDriverList_VehicleNo').val('');
    }


    $('#DriverModal').modal('hide');
    gIndex = -1;
}
function AddDriver(index) {
    gIndex = -1;
    $('#operatorDriverList_DriverName, #operatorDriverList_DriverLicenseNo, #operatorDriverList_DriverMobileNo, #operatorDriverList_VehicleNo').val('');
    $('#DriverModal').modal('show');
}