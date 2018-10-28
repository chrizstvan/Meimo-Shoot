namespace Mapbox.Examples
{
	using UnityEngine;
	using Mapbox.Utils;
	using Mapbox.Unity.Map;
	using Mapbox.Unity.MeshGeneration.Factories;
	using Mapbox.Unity.Utilities;
	using System.Collections.Generic;

	public class SpawnOnMap : MonoBehaviour
	{
		[SerializeField]
		AbstractMap _map;

		[SerializeField]
		[Geocode]
		string[] _locationStrings;
		Vector2d[] _locations;

		[SerializeField]
		float _spawnScale = 100f;

		[SerializeField]
		GameObject _markerPrefab;

        [SerializeField]
        GameObject _petsPrefab;

		List<GameObject> _spawnedObjects;
        List<GameObject> _spawnPets;

		void Start()
		{
            OnStartEnemySpawn();
            OnStartPetsSpawn();
		}

		private void Update()
		{
            OnUpdateEnemySpawn();
            OnUpdatePetsSpawn();
		}

        void OnStartEnemySpawn()
        {
            _locations = new Vector2d[_locationStrings.Length];
            _spawnedObjects = new List<GameObject>();
            for (int i = 0; i < _locationStrings.Length; i++)
            {
                var locationString = _locationStrings[i];
                _locations[i] = Conversions.StringToLatLon(locationString);
                var instance = Instantiate(_markerPrefab);
                instance.transform.localPosition = _map.GeoToWorldPosition(_locations[i], true);
                instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
                _spawnedObjects.Add(instance);
            }
        }

        void OnUpdateEnemySpawn()
        {
            int count = _spawnedObjects.Count;
            for (int i = 0; i < count; i++)
            {
                var spawnedObject = _spawnedObjects[i];
                var location = _locations[i];
                spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
                spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
            }
        }

        void OnStartPetsSpawn()
        {
            _locations = new Vector2d[_locationStrings.Length];
            _spawnPets = new List<GameObject>();
            for (int i = 0; i < _locationStrings.Length; i++)
            {
                var locationString = _locationStrings[i];
                _locations[i] = Conversions.StringToLatLon(locationString);
                var instance = Instantiate(_petsPrefab);
                instance.transform.localPosition = _map.GeoToWorldPosition(_locations[i], true);
                instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
                _spawnPets.Add(instance);
            }
        }

        void OnUpdatePetsSpawn()
        {
            int count = _spawnPets.Count;
            for (int i = 0; i < count; i++)
            {
                var spawnedObject = _spawnPets[i];
                var location = _locations[i];
                spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
                spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
            }
        }
	}
}