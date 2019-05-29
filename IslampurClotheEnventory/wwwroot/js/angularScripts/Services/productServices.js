myApp.service('productService', function ($http) {
    return {
        post: function (product) {
            return $http.post('/Products/Edit/', product)
        },

        getproduct: function () {
            return $http.post('/Products/Any/')

        },
        deleteProduct: function (id) {
            debugger
            return $http.post('/Products/DeleteProduct/', id)
        },
        createProduct: function (product) {
            debugger
            return $http.post('/Products/Create/', product)
        }
    }
    
})
    