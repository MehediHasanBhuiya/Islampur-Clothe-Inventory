myApp.service('SaleServices', function ($http) {
    return {
        productsearch: function (product) {

            return $http.post('/Purches/Search/', product)
        },

        customarSearch: function (customer) {
            
            return $http.post('Sale/SearchCusetomer', customer)
        },

        addsales: function (saleinfo) {
            debugger
            return $http.post('Sale/AddSale', saleinfo)
        },

        salesinfo: function () {
            return $http.get('https://localhost:44342/sale/AllSale')
        },

        bestSaleInfo: function (product) {
            return $http.post('https://localhost:44342/sale/BestSaleData', '"'+product+'"')
        },

        revinueInfo: function () {
            return $http.get('https://localhost:44342/sale/RevinueInfo')
        }
    }
});