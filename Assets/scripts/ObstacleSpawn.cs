using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public int numObs = 5;
    public GameObject[] Obs;
    public GameObject obstacle;
    public FloorSpawn floor;
    public Vector3 spawn;

    private void Start()
    {
        obstacle = GameObject.FindWithTag("Obstacle");
        Obs = new GameObject[numObs];
        for (int i = 0; i < numObs; i++)
        {
            GameObject gameObject = Instantiate(obstacle, new Vector3((float)i, 1, 0), Quaternion.identity) as GameObject;
            gameObject.transform.localScale = Vector3.one;
            Obs[i] = gameObject;
        }
    }

    private void Update()
    {
        
    }
}
