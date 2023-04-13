using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : MonoBehaviour
{
    public bool blossoms = false;
    int speed = 60;
    // Start is called before the first frame update
    void Start()
    {
        if (!blossoms) {
            var r = Random.Range(0, 2);
            print(r);
            if ( r == 1) {
                transform.Rotate (0, 0, 90);
            }
        }
    }

    void FixedUpdate()
    {
        if (blossoms) {
            transform.Rotate (new Vector3 (0, 0, speed) * Time.deltaTime);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
