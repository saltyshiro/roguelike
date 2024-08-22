using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsRoom : MonoBehaviour
{
    private static StairsRoom instance;
    public GameObject room, room1, room2, room3;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance != null)
        {
            if (this.gameObject.name == "Stairs Room 1")
            {
                Instantiate(room1, this.transform.position, Quaternion.identity);
            }
            if (this.gameObject.name == "Stairs Room")
            {
                Instantiate(room, this.transform.position, Quaternion.identity);
            }
            if (this.gameObject.name == "Stairs Room 2")
            {
                Instantiate(room2, this.transform.position, Quaternion.identity);
            }
            if (this.gameObject.name == "Stairs Room 3")
            {
                Instantiate(room3, this.transform.position, Quaternion.identity);
            }
            // If an instance already exists, destroy this duplicate object
            Destroy(gameObject);
        }
        else
        {
            // If this is the first instance, set it as the instance
            instance = this;

            // Mark this object to not be destroyed when loading new scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Reset the instance when this object is destroyed
        if (instance == this)
        {
            instance = null;
        }
    }
}
