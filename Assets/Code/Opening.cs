using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        Invoke("GoToTitle", 28f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
