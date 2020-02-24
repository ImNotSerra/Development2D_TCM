using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShiftAttention : MonoBehaviour
{
    Collider2D myCollider;

    GameObject cameraObj;

    [Range(0f, 1f)] public float interpolation = 0.05f;

    int numberOfPlayersIn;
    public int collidersIn = 2;

    List<Collider2D> collidedObjects = new List<Collider2D>();


    // Use this for initialization
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        cameraObj = Camera.main.gameObject;

        numberOfPlayersIn = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*   if (collision.CompareTag("Player"))
           {
               numberOfPlayersIn++;

               if (numberOfPlayersIn == 2)
               {
                   cameraObj.GetComponent<cameraFollow>().enabled = false;
               }
           }*/
        if (!collidedObjects.Contains(collision) && collision.tag == "Player")
        {
            collidedObjects.Add(collision);

            if (collidedObjects.Count >= collidersIn)
            {
                print("Aproching");
                cameraObj.GetComponent<CameraMovment>().enabled = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // OnTriggerEnter2D(collision);

        if (collidedObjects.Count >= collidersIn)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, Camera.main.transform.position.z), interpolation);
            print("Stay");
        }

    }

    private void Update()
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*   if (collision.tag == "Player")
           {
               numberOfPlayersIn--;

               if(numberOfPlayersIn < 2)
                   cameraObj.GetComponent<cameraFollow>().enabled = true;
           }*/

        if (collidedObjects.Contains(collision) && collision.tag == "Player")
        {
            collidedObjects.Remove(collision);
            cameraObj.GetComponent<CameraMovment>().enabled = true;

        }
    }

    private void OnDestroy()
    {
        if (cameraObj != null)
        {
            cameraObj.GetComponent<CameraMovment>().enabled = true;
        }
    }
}
