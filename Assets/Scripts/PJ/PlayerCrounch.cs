using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrounch : MonoBehaviour
{
    public void OnCrounch()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("Me agacho");
    }

    public void OnCrounchRelease()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        Debug.Log("Me levanto");
    }
}
