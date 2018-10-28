using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour 
{
    [Header("using Classic mode")]
    [SerializeField] float _moveSpeed = .5f;
    [SerializeField] float _travelTime = 1.0f;
    [SerializeField] Vector3 _rotationAxis;

    //// Use this for initialization
    void Start () 
    {
        StartCoroutine(Move());
        _nav = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (gameObject.transform.position.y < -2)
            Destroy(gameObject);
        //Movement();
    }
    IEnumerator Move()
    {
        float time = 0f;
        while (time < _travelTime)
        {
            time += Time.deltaTime;
            transform.Translate(transform.forward * _moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.Rotate(_rotationAxis, Random.Range(0, 360));
        StartCoroutine(Move());
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projectile") || other.CompareTag("Pets"))
        {
            Destroy(gameObject);
        }
    }

    [Header("using AI mode")]
    [SerializeField] float _timer;
    [SerializeField] int _newTarget;
    [SerializeField] float _speed;
    [SerializeField] NavMeshAgent _nav;
    [SerializeField] Vector3 _target;
    [SerializeField] int _randomValue;

    void Movement()
    {
        _nav.speed = _speed;
        _timer += Time.deltaTime;

        if (_timer >= _newTarget)
        {
            NewTarget();
            _timer = 0;
        }
    }

    void NewTarget()
    {
        float myX = gameObject.transform.position.x;
        float myZ = gameObject.transform.position.z;

        float xPos = myX + Random.Range(myX - _randomValue, myX + _randomValue);
        float zPos = myZ + Random.Range(myZ - _randomValue, myZ + _randomValue);

        _target = new Vector3(xPos, transform.position.y, zPos);

        _nav.SetDestination(_target);
    }
}
