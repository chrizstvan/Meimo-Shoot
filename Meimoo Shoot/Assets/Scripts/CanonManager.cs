using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanonManager : MonoSingleton<CanonManager>
{
    [SerializeField] GameObject projectile;
    [SerializeField] int maxAmmo = 3;
    [SerializeField] float replenishTime = 3.0f;
    [SerializeField] float shotForce = 100.0f;

    int _currentAmmo = 0;

    public int MaxAmmo { get { return maxAmmo; }}
    public int CurrentAmmo { get { return _currentAmmo; } }

    public override void Init()
    {
        base.Init();
    }

    void Start()
    {
        StartCoroutine(ReplenishAmmo());
    }

    void Update()
    {
        FireShot();    
    }

    IEnumerator ReplenishAmmo()
    {
        while(true)
        {
            if (GameManager.Instance.GameRunning)
            {
                _currentAmmo = Mathf.Min(_currentAmmo + 1, maxAmmo);
            }
            yield return new WaitForSeconds(replenishTime);
        }
    }

    void FireShot()
    {
        if (!GameManager.Instance.GameRunning)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (_currentAmmo > 0 /*&& !EventSystem.current.IsPointerOverGameObject()*/)
            {
                GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
                Rigidbody projBody = newProjectile.GetComponent<Rigidbody>();
                projBody.AddForce(transform.forward * shotForce);
                _currentAmmo--;
                SoundManager.Instance.ShotSoundPlay();
            } 
        }
    }
}
