using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private float range = 50f;
    private Vector2 spawnLocation;


    // Update is called once per frame
    void Update()
    {
        GameObject obj = BallPooler._instance.GetPooledBall();
        if (obj == null) return;

        spawnLocation = new Vector2(Random.Range(-range, range), Random.Range(-range, range));

        obj.transform.position = new Vector3(spawnLocation.x, transform.position.y, spawnLocation.y);
        obj.SetActive(true);

        //Instantiate(BallPooler._instance.ball, new Vector3(spawnLocation.x, transform.position.y, spawnLocation.y), Quaternion.identity); 


    }

}
