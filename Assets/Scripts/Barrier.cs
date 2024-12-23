using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Barrier : MonoBehaviour
{
    
    public int speed = 5;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
     
    }

    
    void Update()
    {
        
        
        
        
        transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
        
        
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        } 
        
        
    }
}
