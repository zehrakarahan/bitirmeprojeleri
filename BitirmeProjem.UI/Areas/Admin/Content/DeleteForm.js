function deleteItem(params) {
    $.ajax({
        url: params.url,
        type: 'POST',
        data: {
            __RequestVerificationToken: params.token,
            ID: params.id
        },
        success: function (result) {
            params.succFunction(result);
        }
    });
}
function getDetail(url,id) {
    $.ajax({
        url: url,
        type: 'POST',
        data: {
           id:id
        },
        success: function (result) {
            console.log(result);
            $("#ID").val(result.ID);
            $("#OrderCode").html(result.OrderCode);
            $("#Shipping").val(result.ShippingCode);
            $("#Customer").html(result.Customer);
            $("#Date").html(result.Date);
            $("#DesignType").html(result.DesignType);
            $("#DesignCode").html(result.DesignCode);
            $("#FontName").html(result.FontName);
            $("#Text").html(result.Text);
            $("#Address").html(result.Address);
            setValue($("#DesignCode2"), result.DesignCode2);
            setValue($("#FontName2"), result.FontName2);
            setValue($("#Text2"), result.Text2);
            $("#Mail").html(result.Mail);
            $("#Phone").html(result.Phone);
            $("#City").html(result.City);
            $("#District").html(result.District);
            $("#Price").html(result.Price + " TL");
            $("#Print").attr("href",'/Admin/Orders/Pdf/'+id);
            $("#order-detail-model").modal();
            var status = result.Status;
            if (status!=1) {
                $("#frmComplete").hide();
            }
        }
    });
}
function setValue(item, value) {
   
    if (value==undefined || value.length == 0) {
        $(item).parent().parent().hide();
    } else {
        $(item).html(value);
        $(item).parent().parent().show();
    }
}