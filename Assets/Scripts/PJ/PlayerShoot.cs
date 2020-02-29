using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0;
    public float Damage = 10;
    public float limitBullet = 100;
    public LayerMask whatToHit;

    public Transform BulletPrefab;

    private float timeToFire = 0;
    Transform firePoint;

    // Start is called before the first frame update
    private void Awake()
    {
        firePoint = transform.Find("FirePoint");

        if (firePoint == null)
        {
            Debug.LogError("NO FIREPOINT");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(fireRate == 0)
        {
            if(Input.GetButtonDown("Fire2"))
            {
                Shoot();
            }
        }
        else
        {
            if(Input.GetButton ("Fire2") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x,firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, mousePosition - firePointPosition, limitBullet, whatToHit);

        SpawnBullet();

        Debug.DrawLine(firePointPosition, mousePosition);

        if(hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.blue);
            Debug.Log(hit.collider.name);
        }
    }

    private void SpawnBullet()
    {
        Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
    }
}
