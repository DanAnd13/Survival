using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    SpriteRenderer weapon;
    public static float angle;
    public GameObject bullet;
    public Transform barrel;
    void Start()
    {
        weapon = GetComponent<SpriteRenderer>();
    }
    public void AngleToCursor()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 direction = mouseWorldPosition - transform.position;
        direction.z = 0;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    void FlipWeapon()
    {
        if (angle > 90 | angle < - 90)
        {
            weapon.flipY = true;
        }
        else if (angle > - 90 | angle < 90)
        {
            weapon.flipY = false;
        }
    }
    void ShootByCklick()
    {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject shootingBullet = Instantiate(bullet);
                shootingBullet.transform.localScale = bullet.transform.lossyScale;
                shootingBullet.SetActive(true);
                shootingBullet.transform.parent = barrel;
                shootingBullet.transform.position = barrel.position;
            }
    }
    void Update()
    {
        AngleToCursor();

        FlipWeapon();

        ShootByCklick();
    }
}
