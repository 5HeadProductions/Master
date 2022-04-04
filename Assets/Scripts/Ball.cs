using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {

        this.gameObject.SetActive(false);
        //Destroy(gameObject);
    }

}
