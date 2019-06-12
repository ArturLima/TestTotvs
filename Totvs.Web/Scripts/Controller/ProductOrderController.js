var ProductOrderController = function (Service) {

    var init = function () {

        $("#AddProduct").on('click', AddProduct);
        $(document).on('click', ".Trash", removeLine);
        $("#SaveOrder").on('click', SaveOrder);
    };

    var AddProduct = function () {

        Service.ManipulateProductOrder($("#products").val(),done,fail);
    };

    var done = function (data) {
        console.log(data);
        $('#MyTable').append('<tr class="linha-pedido" data-valor="' + data.Value + '" data-id="'+data.ProductId+'"><td>' + data.ProductName + '</td> <td>1</td> <td class="attrValue">' + data.Value + '</td> <td><button class="Trash" style="border: none;"><i class="fa fa-trash-o"></i></button></td> </tr>');
        
        var saldo = parseInt($("#Totalvalue").text());
        $('#Totalvalue').html(saldo + parseInt(data.Value));
    };

    var fail = function (data) {
        console.error(data);
    };

    var removeLine = function () {
        var par = $(this).parent().parent(); //tr

        totalvalue = parseInt(par.data("valor"));
        var saldo = parseInt($("#Totalvalue").text());
        $('#Totalvalue').html(saldo - totalvalue);

        par.remove();
        
    };    

    var SaveOrder = function () {

        var idCustomer = parseInt($("#customers").val());
        var deliveryDate = $("#DeliveryDate").val();
        var totalValue = parseInt($("#Totalvalue").text());

        var ArrayProduct = [];
        $(function () {
            $('#MyTable tbody tr').each(function (a, b) {
                var id = $(this).data("id");
                var value = $('.attrValue', b).text();
                ArrayProduct.push({ IdProduct: id, Value: value});
            });
        });

        var result = validate(DeliveryDate);

        if (result) {
            var Order = {};
            Order.IdCustomer = idCustomer;
            Order.DeliveryDate = deliveryDate;
            Order.Products = ArrayProduct;
            Order.TotalValue = totalValue;

            Service.SaveOrder(Order, done, fail); 
            toastr.success("Pedido adicionado");
            $('#MyTable tbody tr').children().remove();
            $('#Totalvalue').html("0");
            $("#DeliveryDate").val("");
        }
    };


    var validate = function (data) {
        var today = new Date();
        var todayFormat = formatDate(today);
        var data2 = $("#DeliveryDate").val();
        var res = true;

        if (todayFormat > data2 && $("#DeliveryDate").val() !== "" ) {
            toastr.error("Data não pode ser menor que hoje"); 
            res = false;
        } else if ($("#DeliveryDate").val() === "") {
            toastr.error("Selecione uma data");
            res = false;
        }
        return res;
    };


    var formatDate = function(date){

            var d = new Date(date),
                month = '' + (d.getMonth() + 1),
                day = '' + d.getDate(),
                year = d.getFullYear();

            if (month.length < 2) month = '0' + month;
            if (day.length < 2) day = '0' + day;

            return [year, month, day].join('-');
      

    };



    return {
        init: init
    };
}(ProductOrderService);


