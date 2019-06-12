var OrdersService = function () {

    var GetOrders = function (Id, done, fail) {
        console.log("entrou 1")
        $.ajax({
            url: '/Order/GetOrder/' + Id,
            type: 'GET',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                done(data);
            },
            error: function (data) {
                console.log("deu ruim");
            }
        });
    };


    var GetAllOrders = function (done, fail) {
        console.log("entrou 2 ")
        $.ajax({
            url: '/Order/GetAllOrder/',
            type: 'GET',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                done(data);
            },
            error: function (data) {
                console.log("deu ruim");
            }
        });
    };

    var GetAOrdersEntryDate = function (id,startDate, endDate, done, fail) {
        console.log("entrou 3")
        $.ajax({
            url: '/Order/GetOrderEntryDate/',
            type: 'GET',
            dataType: "json",
            data: { "id": id, "startDate": startDate, "endDate": endDate },
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                done(data);
            },
            error: function (data) {
                console.log("deu ruim");
            }
        });
    };

    return {
        GetOrders: GetOrders,
        GetAllOrders: GetAllOrders,
        GetAOrdersEntryDate: GetAOrdersEntryDate
    };

}();

