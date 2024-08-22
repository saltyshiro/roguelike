using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class StairSpawn : MonoBehaviour
{
    public GameObject stair;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(stair, this.transform.position, this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
