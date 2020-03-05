using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int moveBulletSpeed = 250;
    public float timeAfterDestroyBullet = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveBulletSpeed);
        Destroy(this.gameObject, timeAfterDestroyBullet);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
