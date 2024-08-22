using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    /*public List<GameObject> allRooms;
    public float waitTime;
    bool stairsSpawned = false;
    public GameObject stairs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime <= 0)
        {
            if(!stairsSpawned)
            {
                Instantiate(stairs, new Vector3(allRooms[Random.Range(0, allRooms.Count + 1)].transform.position.x, -1, allRooms[Random.Range(0, allRooms.Count + 1)].transform.position.z), Quaternion.identity);
                stairsSpawned = true;
            }
                
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    
    }*/
}
