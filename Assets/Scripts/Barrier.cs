using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Barrier : MonoBehaviour
{
    
    public int speed = 5;
    private float leftEdge;


    public float getLeftEdge()
    {
        return this.leftEdge;
    }
    
    
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
