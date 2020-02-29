using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilMovPlayer : MonoBehaviour
{
    public int bulletSpeed = 100;
    public int proyectilDamage;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * bulletSpeed);
        //Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemies"))
        {
            Debug.Log("LE DISTE WEEEY");
            other.GetComponent<EnemyController>().TakeDamage(proyectilDamage);
        }
    }
}
