(function () {
    'use strict';
    var controllerId = 'media';
    angular.module('app').controller(controllerId, ['$routeParams', 'common', 'datacontext', viewmodel]);

    function viewmodel($routeParams, common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.media = null; 

        activate();

        function activate() {
            common.activateController([getRequestedMedia()], controllerId)
                .then(function () { log('Activated MediaDetail View'); });
        }

        function getRequestedMedia() {
            var val = $routeParams.id;
            datacontext.getMediaById(val).then(function(data) {
                vm.media = data; 
            });
        }
    }
})();