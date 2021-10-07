using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float Damage = 10.0f;

    public float Speed = 5.0f;

    public GameObject target;

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                                                    target.transform.position,
                                                    Speed*Time.deltaTime);

            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                                                        target.transform.rotation,
                                                        30.0f);
        }
        else {
            DestroySelf();
        }
    }

    public void DestroySelf() {
        Destroy(this.gameObject);
    }
}
