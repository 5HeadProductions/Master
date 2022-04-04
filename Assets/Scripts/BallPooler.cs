using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPooler : MonoBehaviour
{

    public static BallPooler _instance;
    public GameObject ball;
    public int size = 1000;
    private List<GameObject> ballList;
    // Start is called before the first frame update
    void Start()
    {

        _instance = this;
        ballList = new List<GameObject>();
        for(int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(ball);
            obj.SetActive(false);
            ballList.Add(obj);

        }
    }

    public GameObject GetPooledBall()
    {
        if(ballList.Count > 0)
        {
            for(int i = 0; i < ballList.Count; i++)
            {
                if (!ballList[i].activeInHierarchy)
                {
                    return ballList[i];
                }
            }
        }
        return null;
    }
    public void Stop()
    {
        ballList.Clear();
    }
}
