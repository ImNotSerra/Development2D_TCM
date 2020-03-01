using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDetection : MonoBehaviour
{
    GameObject exclamation;

    private void Awake()
    {
        exclamation = transform.GetChild(0).gameObject;
            
    }
 
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("trap"))
        {
            exclamation.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("trap"))
        {
            exclamation.SetActive(false);
        }
    }
}
