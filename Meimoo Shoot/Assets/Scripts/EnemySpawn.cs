using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemySpawn : MonoBehaviour 
{
    [SerializeField] float _spawnRate = 3.0f;
    [SerializeField] float _spawnRadius = .6f;
    [SerializeField] float _spawnHeight = 1.0f;
    [SerializeField] int _maxNumberofSpawn = 5;
    [SerializeField] GameObject _spawnObject;

    int _currentSpawn = 0;

	// Use this for initialization
	void Start ()
    {
        Assert.IsNotNull(_spawnObject);
        StartCoroutine(SpawnAlienEnemy());
	}
	
    IEnumerator SpawnAlienEnemy()
    {
        yield return new WaitForSeconds(_spawnRate);

        while(_currentSpawn < _maxNumberofSpawn)
        {
            if(GameManager.Instance.GameRunning)
            {
                Instantiate(_spawnObject, GetRandomPosition(), _spawnObject.transform.rotation);
                _currentSpawn = Mathf.Min(_currentSpawn + 1, _maxNumberofSpawn);
            }
            yield return new WaitForSeconds(_spawnRate);
        }
    }


    Vector3 GetRandomPosition()
    {
        Vector3 randomPos = Random.insideUnitSphere * _spawnRadius + transform.position;
        Vector3 newPos = new Vector3(randomPos.x, transform.position.y + _spawnHeight, randomPos.z);

        return newPos;
    }
}
