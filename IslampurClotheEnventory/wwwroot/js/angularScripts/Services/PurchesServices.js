myApp.service('PurchesServices', function ($http) {
    return {
        productsearch: function (product) {
            
            return $http.post('/Purches/Search/', product)
        },

        getpurchesinfo: function () {
            return $http.get('/Purches/AllPurches/')

        },
        deleteProduct: function (id) {
            
            return $http.post('/Purches/DeleteProduct/', id)
        },
        addpurches: function (purches) {
            debugger
            return $http.post('/Purches/Add/', purches)
        }
    }

})
