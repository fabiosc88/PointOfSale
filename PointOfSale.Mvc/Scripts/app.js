(() => {
    angular.module('pointOfSale', [])
        .controller('MainController', function ($scope, cartService) {
            $scope.itemsCount = cartService.getItemsCount();
        })
        .service('cartService', function ($window) {
            let vm = this;

            vm.getItem = (id) => {
                return $window.sessionStorage.getItem(id);
            };

            vm.setItem = (id, value) => {
                $window.sessionStorage.setItem(id, value);
            };

            vm.addItemToCart = (id) => {
                let count = vm.getItem(id);

                if (count != null) {
                    count++;
                } else {
                    count = 1;
                }

                vm.setItem(id, count);
            };

            vm.changeItemAmount = (id, amount) => {
                vm.setItem(id, amount);
            };

            vm.removeItem = (id) => {
                $window.sessionStorage.removeItem(id);
            };

            vm.getItemsCount = () => {
                return $window.sessionStorage.length;
            }

            vm.clearCart = () => {
                $window.sessionStorage.clear();
            }

            vm.getAllItems = () => {
                let keys = [];
                for (var key in $window.sessionStorage) {
                    keys.push(key)
                }
                return keys;
            }
            
        });

})()