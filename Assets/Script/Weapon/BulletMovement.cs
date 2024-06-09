using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletMovement : MonoBehaviour
{
    float bulletSpeed = 60f;
    public static float bulletDamage;
    Vector3 direction;
    private void Start()
    {
        bulletDamage = 5f;
    }
    private void OnEnable()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.y -= 2;
        direction = mouseWorldPosition - transform.position;
        direction.z = 0;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    void FixedUpdate()
    {
        Vector3 velocity = direction.normalized * bulletSpeed * Time.deltaTime;
        transform.position = transform.position + velocity;
    }
    public static float BulletDamage()
    {
        return bulletDamage;
    }
}
