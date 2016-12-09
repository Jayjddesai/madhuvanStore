function addtionalData() {
    return {
        ledgerid: getInputValueById("PartyLedgerId")
    };
}

function OnLedgerSelect(e) {
    // alert();
   // $('#gridOnAccount').data('kendoGrid').dataSource.read();

    onCheckboxChecked();
}

function onCheckboxChecked() {
    $('#gridOnAccount').on('click', '.chkView', function () {
        var checked = $(this).is(':checked');
        var grid = $('#gridOnAccount').data().kendoGrid;
        var dataItem = grid.dataItem($(this).closest('tr'));
        if (checked == true) {
            dataItem.set('PayAmount', dataItem.OnAccountAmount);
        } else {
            dataItem.set('PayAmount', 0);
        }
        dataItem.set('IsFullPay', checked);
        //setTotalValueFromGrid();
        checkPaidAmountWithTotal();
    });
}

//NetPayableAmount

function changeNumericPurchaseVoucher(e) {

    var grid = $('#gridOnAccount').data().kendoGrid;
    var dataItem = grid.dataItem($(this.element).closest("tr"));

    if (dataItem.PayAmount > dataItem.OnAccountAmount) {
        dataItem.set('PayAmount', dataItem.OnAccountAmount);
    }

    dataItem.set('IsFullPay', false);
    // setTotalValueFromGrid();
    checkPaidAmountWithTotal();
}


function SavePurchaseVoucherWithJsonData()
{
    var gridRev = kendo.stringify($("#gridOnAccount").data("kendoGrid").dataSource.data());
    setInputValueById('jsonData', gridRev);
}


function checkPaidAmountWithTotal() {
    var netPayableAmount = $("#NetPayableAmount").val();


    var totalAmount = 0;
   
    var dataSource = $("#gridOnAccount").data("kendoGrid").dataSource;
    var data = dataSource.data();
    $.each(data, function (index, rowItem) {
        totalAmount = parseFloat(totalAmount) + parseFloat(rowItem.PayAmount);
    });

    if (totalAmount > netPayableAmount) {
        var notification = $("#notification").data("kendoNotification");
        notification.show({
            title: "Alert",
            message: "You Cannot Pay More than Voucher Amount."
        }, "error");
    }


}

