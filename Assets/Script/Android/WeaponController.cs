using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    SpriteRenderer weapon;
    public static float angle;
    public Transform barrel;
    public AudioSource gunShot;
    public static Vector3 direction;
    public GameObject bullets;
    ObjectPool bulletPool;
    float timer;
    float reloadTime = 0.4f;
    public MoveJoystick joystick; // Додано джойстик

    void Start()
    {
        weapon = GetComponent<SpriteRenderer>();
        bulletPool = bullets.GetComponent<ObjectPool>();
    }

    public void AngleToJoystick()
    {
        Vector2 joystickInput = new Vector2(joystick.Horizontal(), joystick.Vertical());

        if (joystickInput != Vector2.zero) // Перевіряємо, що джойстик не у нейтральному положенні
        {
            direction = joystickInput.normalized;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void FlipWeapon()
    {
        if (angle > 90 || angle < -90)
        {
            weapon.flipY = true;
        }
        else
        {
            weapon.flipY = false;
        }
    }

    void Shoot()
    {
        GameObject shootingBullet = bulletPool.SharedInstance.GetPooledObject();
        if (shootingBullet != null)
        {
            shootingBullet.transform.position = barrel.position;
            shootingBullet.transform.rotation = Quaternion.Euler(0, 0, angle);
            shootingBullet.transform.rotation = transform.rotation; // Повертаємо кулю у напрямку зброї
            gunShot.Play();
            shootingBullet.SetActive(true);
            StartCoroutine(BulletLiveTime(shootingBullet));
        }
    }
    private void Update()
    {
        AngleToJoystick();

        FlipWeapon();
    }
    void LateUpdate()
    {
        

        if (timer <= 0f)
        {
            if (joystick.Horizontal() !=0 & joystick.Vertical()!=0 & joystick.tag == "GameController")
            {
                Shoot();
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
