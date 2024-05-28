using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    SpriteRenderer weapon;
    float angle;
    public Transform barrel;
    Vector3 direction;
    ObjectPool bulletPool;
    void Start()
    {
        weapon = GetComponent<SpriteRenderer>();
        bulletPool = GetComponent<ObjectPool>();
    }
    public void AngleToCursor()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        direction = mouseWorldPosition - transform.position;
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
        GameObject shootingBullet = bulletPool.SharedInstance.GetPooledObject();
        if (shootingBullet != null)
        {
            shootingBullet.transform.position = barrel.position;
            shootingBullet.SetActive(true);
            StartCoroutine(BulletLiveTime(shootingBullet));
        }
    }
    void Update()
    {
        AngleToCursor();

        FlipWeapon();

        if (Input.GetMouseButtonDown(0))
        {
            ShootByCklick();
        }
    }
    IEnumerator BulletLiveTime(GameObject bullet)
    {
        yield return new WaitForSeconds(2f);
        bullet.SetActive(false);
    }
}
