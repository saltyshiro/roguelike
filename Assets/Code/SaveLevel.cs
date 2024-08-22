using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLevel : MonoBehaviour
{
    string sceneName;
    Scene currentScene;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the scene loading event
    }

    void Update()
    {
        if (Stairs.goingUp)
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneName = scene.name;

        if (sceneName == "Battle")
        {
            gameObject.SetActive(false); // Disable object when Battle scene is loaded
        }
        else if (sceneName == "Test Dungeon")
        {
            gameObject.SetActive(true); // Enable object when Test Dungeon scene is loaded
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from the scene loading event
    }
}

