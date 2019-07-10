
myApp.controller('Sales', function ($scope, SaleServices) {

    $scope.hidethisProduct = true;
    $scope.hidethisCustomer = true;

    $scope.searchProduct = function () {

        $scope.hidethisProduct = false;
        var product = {
            productName: $scope.ProductName
        };

        SaleServices.productsearch(product).then(function (response) {
            $scope.productList = response.data;
            console.log = response.data;

        }).catch(function onError(error) {
            console.log(error);
        });
    };

    $scope.FillTextBoxProduct = function (p) {
        $scope.ProductName = p.productName;
        $scope.ProductPrice = p.productSalePrice;
        $scope.productId = p.productId;

        $scope.hidethisProduct = true;

    };

    $scope.tprice = function () {
        $scope.SalePrice = $scope.SaleQuentity * $scope.ProductPrice;
    };

    $scope.cash = function () {
        $scope.OnDebt = $scope.SalePrice - $scope.OnCash;
    };

    $scope.searchCusomer = function () {

        $scope.hidethisCustomer = false;
        var customer = {
            customerName: $scope.CustomerName
        };

        SaleServices.customarSearch(customer).then(function (response) {
            $scope.customerList = response.data;
            console.log = response.data;

        }).catch(function onError(error) {
            console.log(error);
        });
    };

    $scope.FillTextBoxCustomer = function (p) {

        $scope.CustomerName = p.customerName;
        $scope.CustomerAddress = p.customerAddress;
        $scope.CustomerPhoneNumber = p.customerPhoneNumber;
        $scope.CustomerEmail = p.customerEmail;
        $scope.customerId = p.customerId;

        $scope.hidethisCustomer = true;

    };

    $scope.AddSale = function () {
        var sale = {
            ProductId: $scope.productId,
            ProductName: $scope.ProductName,
            ProductPrice: $scope.ProductPrice,
            SaleQuentity: $scope.SaleQuentity,
            SalePrice: $scope.SalePrice,
            OnCash: $scope.OnCash,
            OnDebt: $scope.OnDebt,
            CustomerId: $scope.customerId,
            CustomerName: $scope.CustomerName,
            CustomerAddress: $scope.CustomerAddress,
            CustomerPhoneNumber: $scope.CustomerPhoneNumber,
            CustomerEmail: $scope.CustomerEmail
        };

        SaleServices.addsales(sale).then(function (response) {
            debugger
            console.log = response.data;
            $scope.saleinfo.push = response.data;

            $scope.productId = "";
            $scope.ProductName = "";
            $scope.ProductPrice = "";
            $scope.SaleQuentity = "";
            $scope.SalePrice = "";
            $scope.OnCash = "";
            $scope.OnDebt = "";
            $scope.customerId = "";
            $scope.CustomerName = "";
            $scope.CustomerAddress = "";
            $scope.CustomerPhoneNumber = "";
            $scope.CustomerEmail = "";

        }).catch(function onError(error) {
            console.log(error);

        });


    };

    SaleServices.salesinfo().then(function (response) {
        debugger
        $scope.saleinfo = response.data;
    }).catch(function onError(error) {
        console.log(error);

    });

    SaleServices.revinueInfo().then(function (response) {
        debugger
        var item = response.data;
        
        $scope.tPurches = item.totalPurches;
        $scope.tSale = item.totalSales;
        $scope.tOnDebt = item.totalOndebt;
        $scope.tOnCash = item.totalOnCash;
        $scope.tRevinue = item.revinue;

    }).catch(function onError(error) {
        console.log(error);

    });

    $scope.bestSale = function () {
        debugger
        var dateTime = $scope.date;
        if (dateTime == null) {

            SaleServices.bestSaleInfo("empty").then(function (response) {
                $scope.bestSaledata = response.data;
            }).catch(function onError(error) {
                console.log(error);

            });
        }
        else {
            SaleServices.bestSaleInfo(dateTime).then(function (response) {
                $scope.bestSaledata = response.data;
            }).catch(function onError(error) {
                console.log(error);

            });
        }

    };

});