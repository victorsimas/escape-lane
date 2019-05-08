using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawn : MonoBehaviour
{
    public GameObject Floor;
    public GameObject newFloor;
    public GameObject Player;
    public Vector3 nextFloor;
    public int counter = 0;
    public bool create;

    private void Start()
    {
        Floor = GameObject.FindWithTag("Floor" + counter);
        Player = GameObject.FindWithTag("Player");
        nextFloor = Floor.transform.position;
        create = false;
    }

    public void Update()
    {
        if (Player.transform.position.z > Floor.transform.position.z)
        {
            if (create != true)
            {
                if (Floor.tag == "Floor0") {
                    counter++;
                }
                if (Floor.tag == "Floor1")
                {
                    counter--;
                }
                newFloor = Instantiate(Floor) as GameObject;
                nextFloor.z += Floor.GetComponent<Collider>().bounds.size.z/2;
                newFloor.transform.position = nextFloor;
                create = true;
                newFloor.transform.gameObject.tag = "Floor" + counter;
                newFloor.transform.gameObject.name = "Floor";
            }

            Debug.Log(Player.GetComponent<PlayerCollision>().floorRun);

            if (Player.GetComponent<PlayerCollision>().floorRun != true)
            {
                GameObject.Destroy(Floor);
                Floor = GameObject.FindWithTag("Floor" + counter);
                create = false;
            }
        }
    }
}
