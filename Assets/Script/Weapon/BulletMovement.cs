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
    public Vector3 direction;
    private void Start()
    {
        bulletDamage = 5f;
    }
    private void OnEnable()
    {
        direction = WeaponMovement.direction;
    }
    void FixedUpdate()
    {
        Vector3 velocity = direction.normalized * bulletSpeed * Time.deltaTime;
        transform.position = transform.position + velocity;
    }
}
