using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    /*
     1 = bottom
     2 = top
     3 = left
     4 = right*/
    private RoomTemplates roomTemplates;
    private int roomIndex;
    public bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", .1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (!spawned)
        {
            switch (openingDirection)
            {
                case 1:
                    roomIndex = Random.Range(0, roomTemplates.bottomRooms.Length);
                    Instantiate(roomTemplates.bottomRooms[roomIndex], transform.position, roomTemplates.bottomRooms[roomIndex].transform.rotation);
                    break;
                case 2:
                    roomIndex = Random.Range(0, roomTemplates.topRooms.Length);
                    Instantiate(roomTemplates.topRooms[roomIndex], transform.position, roomTemplates.topRooms[roomIndex].transform.rotation);
                    break;
                case 3:
                    roomIndex = Random.Range(0, roomTemplates.leftRooms.Length);
                    Instantiate(roomTemplates.leftRooms[roomIndex], transform.position, roomTemplates.leftRooms[roomIndex].transform.rotation);
                    break;
                case 4:
                    roomIndex = Random.Range(0, roomTemplates.rightRooms.Length);
                    Instantiate(roomTemplates.rightRooms[roomIndex], transform.position, roomTemplates.rightRooms[roomIndex].transform.rotation);
                    break;
            }
            spawned = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spawnpoint"))
        {
            Destroy(gameObject);
            /*
            RoomSpawner roomSpawner = other.GetComponent<RoomSpawner>();
            if (roomSpawner != null)
            {
                if (roomSpawner.spawned == true)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.LogWarning("RoomSpawner component not found on the collided object.");
            }*/
        }
    }
}
