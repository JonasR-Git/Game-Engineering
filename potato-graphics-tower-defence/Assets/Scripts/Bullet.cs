using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    private float bulletSpeed;
    private float damage;

    public GameObject impactPrefab;

    public void Prepare (Transform _target, float _bulletSpeed, float _damage)
    {
        target = _target;
        bulletSpeed = _bulletSpeed;
        damage = _damage;
    }

    void Update()
    {

        //If target get lost, clear the bullet
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distancePerFrame = bulletSpeed * Time.deltaTime;

        if(dir.magnitude <=distancePerFrame)
        {
            Hit();
            return;
        }

        transform.Translate(dir.normalized * distancePerFrame, Space.World);
    }

   void Hit()
    {
        GameObject effect = (GameObject)Instantiate(impactPrefab, transform.position, transform.rotation);
        //Makes sure that the effect is destroyed completly
        Destroy(effect, 2);
        Damage(target);
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }
}
