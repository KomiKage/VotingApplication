using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject canvas;
    public GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            GameObject go = Instantiate(objectToSpawn, transform.position, transform.rotation);
            go.transform.parent = canvas.transform;
        }
    }
}
