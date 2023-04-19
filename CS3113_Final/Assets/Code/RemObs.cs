using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemObs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        print("col");
        if (other.gameObject.tag == "Enemy")
            Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
