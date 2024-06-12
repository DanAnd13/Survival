using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    SpriteRenderer weapon;
    float angle;
    public Transform barrel;
    public AudioSource gunShot;
    public static Vector3 direction;
    ObjectPool bulletPool;
    float timer;
    float reloadTime = 0.2f;
    void Start()
    {
        weapon = GetComponent<SpriteRenderer>();
        bulletPool = GetComponentInChildren<ObjectPool>();
    }
    public void AngleToCursor()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.y -= 2;
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
            gunShot.Play();
            shootingBullet.SetActive(true);
            StartCoroutine(BulletLiveTime(shootingBullet));
        }
    }
    void LateUpdate()
    {
        AngleToCursor();

        FlipWeapon();

        if (timer <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShootByCklick();
                timer = reloadTime;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
    IEnumerator BulletLiveTime(GameObject bullet)
    {
        yield return new WaitForSeconds(1.3f);
        bullet.SetActive(false);
    }
}
