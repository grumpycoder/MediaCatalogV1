(function () {
    'use strict';
    var controllerId = 'mediacatalog';
    angular.module('app').controller(controllerId,
        ['$location', '$routeParams', 'common', 'config', 'datacontext', viewmodel]);

    function viewmodel($location, $routeParams, common, config, datacontext) {
        var vm = this;
        var keyCodes = config.keyCodes;
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        
        vm.filteredMedia = []; 
        vm.gotoMedia = gotoMedia;
        vm.media = [];
        vm.mediaSearch = $routeParams.search || '';
        vm.predicate = '';
        vm.reverse = false;
        vm.search = search;
        vm.setSort = setSort; 
        vm.title = 'Media Catalog';

        activate();

        function activate() {
            common.activateController([getMediaPartials()], controllerId)
                .then(function() {
                    log('Activated Media View');
            });
        }

        function applyFilter() {
            vm.filteredMedia = vm.media.filter(mediaFilter);
        }

        function getMediaPartials() {
            datacontext.getMediaPartials().then(function (data) {
                vm.media = data;
                applyFilter();
                return vm.media;
            });
        }

        function gotoMedia(media) {
            $location.path('/media/' + media.id);
        }

        function mediaFilter(media) {
            var isMatch = vm.mediaSearch
                ? common.textContains(media.title, vm.mediaSearch)
                : true;
            return isMatch;
        }

        function search($event) {
            if ($event.keyCode === keyCodes.esc) {
                vm.mediaSearch = ''; 
            }
            applyFilter();
        }

        function setSort(prop) {
            vm.predicate = prop;
            vm.reverse = !vm.reverse;
        }
    }
})();