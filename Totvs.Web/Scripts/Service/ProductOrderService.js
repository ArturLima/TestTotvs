var ProductOrderService = function () {

    var ManipulateProductOrder = function (ProductId, done, fail) {

            $.ajax({
                url: '/Product/getProduct/' + ProductId,
                type: 'GET',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    done(data);

                },
                error: function (data) {
                    fail(data);
                }
            });
    };

    var SaveOrder = function (Order, done, fail) {
        console.log(Order);

        $.ajax({
            url: '/Order/SaveOrder/',
            type: 'POST',
            data: JSON.stringify(Order),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                done(data);

            },
            error: function (data) {
                fail(data);
            }
        });
    };


    return {
        ManipulateProductOrder: ManipulateProductOrder,
        SaveOrder: SaveOrder
    };

}();

