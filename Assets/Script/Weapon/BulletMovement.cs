using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletMovement : MonoBehaviour
{
    float bulletSpeed = 60f;
    [HideInInspector]
    public float bulletDamage = 5f;
    Vector3 direction;
    Vector3 mouseWorldPosition;
    void Start()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.y -= 2;
        transform.rotation = Quaternion.Euler(0, 0, WeaponMovement.angle);
        direction = mouseWorldPosition - transform.position;
    }
    void FixedUpdate()
    {
        Vector3 velocity = direction.normalized * bulletSpeed * Time.deltaTime;
        transform.position = transform.position + velocity;
        Destroy(gameObject, 1f);
    }
}
