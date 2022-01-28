using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    public event Action<int> Collided;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag=="Ring")
        {
            Collided?.Invoke(100); //event happens on collison

            Debug.Log("collided with ring");

        }
        
    }
}
