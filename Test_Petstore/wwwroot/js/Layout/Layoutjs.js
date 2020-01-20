function sendAjax(model, urlAction, succ) {

    $.ajax({
        type: "post",
        url: urlAction,
        data: model,
        datatype: "json",
        cache: false,
        success: function (data) {
            succ(data);
        },
        error: function (xhr) {
            alert('No Valid Data');
        }
    });

}