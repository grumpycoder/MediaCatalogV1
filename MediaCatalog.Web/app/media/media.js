(function () {
    'use strict';
    var controllerId = 'media';
    angular.module('app').controller(controllerId, ['$location', 'common', 'datacontext', media]);

    function media($location, common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.gotoMedia = gotoMedia;
        vm.media = []; 
        vm.title = 'Media Catalog';

        activate();

        function activate() {
            common.activateController([getMediaPartials()], controllerId)
                .then(function() {
                    log('Activated Media View');
                    log('vm.media', vm.media);

            });
        }

        function gotoMedia(media) {
            $location.path('/mediadetail/' + media.id);
        }

        function getMediaPartials() {
            datacontext.getMediaPartials().then(function (data) {
                log('data', data);
                return vm.media = data; 
            });
        }
    }
})();