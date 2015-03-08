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
        vm.mediaFilter = mediaFilter;
        vm.mediaSearch = $routeParams.search || '';
        vm.predicate = '';
        vm.refresh = refresh; 
        vm.reverse = false;
        vm.search = search;
        vm.setSort = setSort; 
        vm.title = 'Media Catalog';

        activate();

        function activate() {
            common.activateController([getMediaPartials()], controllerId)
                .then(function () {
                    applyFilter = common.createSearchThrottle(vm, 'media');
                    if (vm.mediaSearch) { applyFilter(true); }
                    log('Activated Media View');
            });
        }

        function applyFilter() {
            vm.filteredMedia = vm.media.filter(mediaFilter);
        }

        function getMediaPartials() {
            datacontext.getMediaPartials().then(function (data) {
                vm.media = vm.filteredMedia = data;
                applyFilter();
                return vm.media;
            });
        }

        function gotoMedia(media) {
            $location.path('/media/' + media.id);
        }

        function mediaFilter(media) {
            var textContains = common.textContains;
            var searchText = vm.mediaSearch;
            var isMatch = searchText ?
                textContains(media.title, searchText)
                    || textContains(media.company_Name, searchText)
                    || textContains(media.mediaType_Name, searchText)
                    || textContains(media.iSBN, searchText)
                : true;
            return isMatch;
        }

        function refresh() { getMediaPartials(); }

        function search($event) {
            if ($event.keyCode === keyCodes.esc) {
                vm.mediaSearch = '';
                applyFilter(true);
            } else {
                applyFilter();
            }
        }

        function setSort(prop) {
            vm.predicate = prop;
            vm.reverse = !vm.reverse;
        }
    }
})();