var ViewModel = function () {
    var self = this;
    self.orders = ko.observableArray();
    self.error = ko.observable();


    var ordersUri = '/api/Orders/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    self.orderDetail = ko.observable();

    self.getOrderDetail = function (item) {
        ajaxHelper(ordersUri + item.Id,'GET').done(function (data) {
            self.orderDetail(data);
        });
    }

    function getAllOrders() {
        ajaxHelper(ordersUri, 'GET').done(function (data) {
            self.orders(data);
        });
    }

    getAllOrders();

};

ko.applyBindings(new ViewModel());