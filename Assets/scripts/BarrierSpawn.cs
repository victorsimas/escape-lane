using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawn : MonoBehaviour
{
    public GameObject [] Barrier;
    public FloorSpawn floor;
    public Vector3 spawn;

    private void Start()
    {
        Barrier = GameObject.FindGameObjectsWithTag("Barrier" + floor.GetComponent<FloorSpawn>().counter);
    }

    private void Update()
    {
        
    }
}
