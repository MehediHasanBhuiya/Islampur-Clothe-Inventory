﻿
myApp.controller('Purches', function ($scope, PurchesServices) {

    toastr.options.positionClass = 'toast-bottom-right';
    toastr.options.newestOnTop = false;

    $scope.hidethis = true;

    $scope.search = function () {

        $scope.hidethis = false;
        var product = {
            productName: $scope.ProductName
        };

        PurchesServices.productsearch(product).then(function (response) {
            $scope.productList = response.data;
            console.log = response.data;

        }).catch(function onError(error) {
            console.log(error);
        });
    };


    $scope.FillTextBox = function (p) {
        $scope.ProductName = p.productName;

        $scope.isStoed = p.isStoed;
        $scope.hidethis = true;

    };

    $scope.cash = function () {
        $scope.OnDebt = $scope.TotalPrice - $scope.OnCash;
    };

    $scope.Add = function () {
        debugger
        var pur = {
            PurchesPersonName: $scope.Name,
            PurchesPersonPhoneNumber: $scope.PhoneNumber,
            PurchesPersonEmail: $scope.Email,
            PurchesPrice: $scope.TotalPrice,
            PurchesOnCash: $scope.OnCash,
            PurchesOnDebt: $scope.OnDebt,
            ProductName: $scope.ProductName,
            ProductQuentity: $scope.ProductQuentity,
            ProductPurchesPrice: $scope.ProductPurchesPrice,
            ProductSalePrice: $scope.ProductSalePrice,
            isStoed: $scope.isStoed
        };

        PurchesServices.addpurches(pur).then(function (response) {
            if (response.data.isSuccess) {
                toastr.success(response.data.message);
            }
            else {
                toastr.warning(response.data.message);
            }
            
        }).catch(function onError(error) {
            console.log(error);
        });

    };

    PurchesServices.getpurchesinfo().then(function (response) {
        $scope.purchesinfo = response.data;
        
    });

});