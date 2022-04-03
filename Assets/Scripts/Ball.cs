using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private bool hit = false;
    public bool usePool = false;



    private void OnCollisionEnter(Collision collision)
    {
        if (hit)
        {
            Destroy(this.gameObject);
        }
        else if (hit && usePool)
        {
            collision.gameObject.SetActive(false);
        }
    }

}
