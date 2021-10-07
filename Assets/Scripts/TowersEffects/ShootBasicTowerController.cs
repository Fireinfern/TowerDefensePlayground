using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBasicTowerController : MonoBehaviour
{
    [SerializeField]
    private GameObject range;

    [SerializeField]
    private float ShootTimer = 0.25f;

    [SerializeField]
    private GameObject Bullet;

    void Start()
    {

    }

    void Update()
    {
        TimerUpdate();
    }

    void TimerUpdate()
    {
        if (ShootTimer <= 0)
        {   
            ShootProyectile();
            ShootTimer = 0.5f;
            return;
        }
        ShootTimer -= Time.deltaTime;
    }

    void ShootProyectile()
    {
        if (range.GetComponent<RangeController>().getEnemiesInRange().Count > 0)
        {   
            Bullet.GetComponent<ProjectileController>().Speed = 5.0f;
            Bullet.GetComponent<ProjectileController>().target = range.GetComponent<RangeController>().getPriorityEnemy();
            GameObject newBullet = Instantiate(Bullet, transform.position, transform.rotation);
        }
    }
}
