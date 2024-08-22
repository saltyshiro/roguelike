using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAndDestroyPlayer : MonoBehaviour
{
    private static CheckAndDestroyPlayer instance;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance != null)
        {
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
