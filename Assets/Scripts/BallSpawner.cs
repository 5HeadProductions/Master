using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    private float range = 50f;
    private Vector2 spawnLocation;

    public bool usePool = false;
    public int poolSize;
    private List<GameObject> ballPool;
    private void Awake()
    {
        ballPool = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            spawnLocation = new Vector2(Random.Range(-range, range), Random.Range(-range, range));
            GameObject obj = Instantiate(ball, new Vector3(spawnLocation.x, transform.position.y, spawnLocation.y), Quaternion.identity);
            obj.SetActive(false);
            ballPool.Add(obj);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(usePool == true)
        {
            SpawnBall();
        }
        else
        {
            spawnLocation = new Vector2(Random.Range(-range, range), Random.Range(-range, range));
            Instantiate(ball, new Vector3(spawnLocation.x, transform.position.y, spawnLocation.y), Quaternion.identity);
        }
        
    }

    public GameObject SpawnBall()
    {
        if(ballPool.Count > 0)
        {
            foreach (GameObject ball in ballPool)
            {
                if (!ball.activeInHierarchy)
                {
                    ball.SetActive(true);
                    return ball;
                }

            }
        }
        return null;
    }
}
