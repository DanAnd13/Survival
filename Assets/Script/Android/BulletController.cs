using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float bulletSpeed = 60f;
    public static float bulletDamage;
    Vector3 direction;
    private void Start()
    {
        bulletDamage = BulletMovement.bulletDamage;
    }
    private void OnEnable()
    {
        direction = WeaponController.direction;
    }
    void FixedUpdate()
    {
        Vector3 velocity = direction.normalized * bulletSpeed * Time.deltaTime;
        transform.position = transform.position + velocity;
    }
}
