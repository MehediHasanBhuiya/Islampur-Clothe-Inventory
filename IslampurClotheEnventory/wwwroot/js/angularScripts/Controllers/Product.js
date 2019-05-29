
var myApp = angular.module('app', []);
myApp.controller('product', function ($scope, $window, $http, productService) {

    productService.getproduct().then(function (response) {
        $scope.products = response.data;
    });

    $scope.EditItem = {};
    $scope.Add = function () {
        if (typeof ($scope.pName) == "undefined" || typeof ($scope.pQuentity) == "undefined" || typeof ($scope.pPurchesPrice) == "undefined" || typeof ($scope.pSalePrice) == "undefined") {
            return;
        }
        var product = {
            productName: $scope.pName,
            productQuentity: $scope.pQuentity,
            productPurchesPrice: $scope.pPurchesPrice,
            productSalePrice: $scope.pSalePrice,
            isStoed: $scope.isStoed
        };
        productService.createProduct(product).then(function (response) {
            console.log = response.data;
            toastr.options.positionClass = 'toast-bottom-right';
            toastr.success('Product add successfully');
            toastr.options.newestOnTop = false;
            productService.getproduct().then(function (response) {
                $scope.products = response.data;
            }).catch(function onError(error) {
                console.log(error);
            });
        }).catch(function onError(error) {
            console.log(error);
        });
        $scope.pName = "";
        $scope.pQuentity = "";
        $scope.pPurchesPrice = "";
        $scope.pSalePrice = "";

    }

    $scope.Edit = function (index) {
        debugger
        
        $scope.products[index].EditModel = true;
        $scope.EditItem.productName = $scope.products[index].productName;
        $scope.EditItem.productQuentity = $scope.products[index].productQuentity;
        $scope.EditItem.productPurchesPrice = $scope.products[index].productPurchesPrice;
        $scope.EditItem.productSalePrice = $scope.products[index].productSalePrice;

    };

    $scope.Cancel = function (index) {
        $scope.products[index].productName = $scope.EditItem.productName;
        $scope.products[index].productQuentity = $scope.EditItem.productQuentity;
        $scope.products[index].productPurchesPrice = $scope.EditItem.productPurchesPrice;
        $scope.products[index].productSalePrice = $scope.EditItem.productSalePrice;

        $scope.products[index].EditModel = false;

        $scope.EditItem = {};

    };


    $scope.Update = function (index) {

        var product = $scope.products[index];
        productService.post(product).then(function (response) {
            debugger
            $scope.products[index].EditModel = false;
            toastr.options.positionClass = 'toast-bottom-right';
            toastr.success('Product update successfully');
            
            console.log = response.data;
        }).catch(function onError(error) {
            console.log(error);
        });
    };

    $scope.Delete = function (id) {
        if ($window.confirm("Are you Sure ?")) {
            productService.deleteProduct(id).then(function (response) {
                debugger
                console.log = response.data;
                toastr.options.positionClass = 'toast-bottom-right';
                toastr.warning('Product delete successfully');
                productService.getproduct().then(function (response) {
                    $scope.products = response.data;
                    
                }).catch(function onError(error) {
                    console.log(error);
                });
            });
        }

    };
});