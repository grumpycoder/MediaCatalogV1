(function () {
	'use strict';

	var serviceId = 'datacontext';
	angular.module('app').factory(serviceId, ['common', 'config', 'entityManagerFactory', 'model', datacontext]);

	function datacontext(common, config, emFactory, model) {
		var entityNames = model.entityNames;
		var EntityQuery = breeze.EntityQuery;
		var getLogFn = common.logger.getLogFn;
		var log = getLogFn(serviceId);
		var logError = getLogFn(serviceId, 'error');
		var logSuccess = getLogFn(serviceId, 'success');
		var manager = emFactory.newManager();
		var primePromise;
		var $q = common.$q;

		var service = {
			getMediaById: getMediaById,
			getMediaPartials: getMediaPartials,
			prime: prime
		};

		return service;

		init();

		function getMediaById(id) {
			return EntityQuery.from('Media').expand('Company')
				//.select('id, title, iSBN, companyId, company.name, mediaType.name').expand('Company')
				.where('id', '==', id)
				.toType('Media')
				.using(manager)
				.execute().then(success, _queryFailed);

			function success(data) {
				var entity = data.results[0];
				logSuccess('Retrieved [Media] id: ' + entity.id + ' from remote.', null, true);
				return entity;
			}
		}

		function getMediaPartials() {
			var order = 'title';
			var media;

			return EntityQuery.from('Media')
				.select('id, title, iSBN, companyId, company.name, mediaType.name')
				.orderBy(order)
				.using(manager)
				.execute()
				.then(success, _queryFailed);

			function success(data) {
				media = data.results;
				log('Retrieved [Media Partials] from remote data source', media.length, true);
				return media;
			}
		}

		//function getMediaPartials() {
		//	var orderBy = 'title';
		//	var media;

		//	return EntityQuery.from('Media')
		//        //.expand('Company')
		//		.select('id, title, iSBN, companyId, company.name, mediaType.name').expand('Company')
		//		.orderBy(orderBy)
		//		.toType('Media')
		//		.using(manager)
		//		.execute()
		//		.then(querySucceeded, _queryFailed);

		//	function querySucceeded(data) {
		//		media = data.results;
		//		log('Retrieved [Media Partials] from remote data source', media.length, true);
		//		log('media', media, false);
		//		return media;
		//	}
		//}

		function init() {
			manager.fetchMetadata().fail(function (error) {
				logError('Failed to fetch metadata', error, true);
			});
		}


		function prime() {
			if (primePromise) return primePromise;

			primePromise = $q.all([getLookups()])
				.then(success);
			return primePromise;

			function success() {
				setLookups();
				logSuccess('Primed the data');
			}
		}

		function setLookups() {
			service.lookupCachedData = {
				mediaTypes: _getAllLocal(entityNames.mediaType, 'name'),
				roles: _getAllLocal(entityNames.role, 'name'),
			};
		}

		function getLookups() {
			return EntityQuery.from('Lookups')
				.using(manager).execute()
				.then(querySucceeded, _queryFailed);

			function querySucceeded(data) {
				log('Retrieved [Lookups]', data, true);
				return true;
			}
		}

		function _getAllLocal(resource, ordering, predicate) {
			return EntityQuery.from(resource)
				.orderBy(ordering)
				.where(predicate)
				.using(manager)
				.executeLocally();
		}

		function _queryFailed(error) {
			var msg = config.appErrorPrefix + 'Error retrieving data' + error.message;
			logError(msg, error);
			throw error;
		}


	}
})();