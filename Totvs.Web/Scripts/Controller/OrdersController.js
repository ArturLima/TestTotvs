var OrdersController = function (Service) {

    var init = function () {

        $("#SearchCustomer").on('click', SearchCustomer);
    };

    var SearchCustomer = function () {
        //$("#MyTable tbody > tr").remove();
        var id = parseInt($("#customers").val());
        var InitialDate = $("#InitalDate").val();
        var EndDate = $("#FinalDate").val();
            var result = validateDate(InitialDate, EndDate);


        if (result) {
        if (InitialDate !== "" && EndDate !== "") {
            Service.GetAOrdersEntryDate(id, InitialDate, EndDate, done, fail);
        } else if (id === 0)
            Service.GetAllOrders(done, fail);
        else
            Service.GetOrders(id, done, fail);    
        }
    };

    var done = function (data) {
        $("tbody").children().remove();
        clearField();
        AddTableRow = function (IdPedido, NameCustomer, TotalValue) {

            var newRow = $("<tr>");
            var cols = "";
            cols += '<td>' + IdPedido + '</td>';
            cols += '<td>' + NameCustomer + '</td>';
            cols += '<td>' + TotalValue + '</td> </tr>';
            newRow.append(cols);
            $("#MyTable").append(newRow);
        };

        

        for (var i = 0; i < data.length; i++) {
            AddTableRow(data[i].IdPedido, data[i].NameCustomer, data[i].TotalValue);
        }
    };

    var fail = function (data) {
        console.log("deu ruim");
    };


    var clearField = function () {
        $("#InitalDate").val("");
        $("#FinalDate").val("");
    }


    var validateDate = function (InitDate, EndDate) {
        var res = true;

        if (InitDate !== "" && EndDate === "" || InitDate === "" && EndDate !== "") {
            toastr.error("Insira as duas datas para pesquisa");
            res = false;
        }else if (InitDate > EndDate) {
            toastr.error("Data Inicio nao pode ser maior que data Fim");
            res = false;
        } else if (EndDate < InitDate) {
            toastr.error("Data Fim nao pode ser menor que data inicio");
            res = false;
        }
        return res;
    };


    return {
        init: init
    };
}(OrdersService);


