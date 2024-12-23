using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
   public GameObject[] prefab;
   public float spawnRate;

   public float minHeight = -1f;
   public float maxHeight = 1f;
   
   

   private void OnEnable()
   {
       InvokeRepeating(nameof(Spanw), spawnRate, spawnRate);
    }
  
  
   void Start()
   {
      StartCoroutine(Spanw());
   }

   IEnumerator Spanw()
   {
      while (true)
      {
         for (int i = 0; i < prefab.Length; i++)
         {

            var randomElement = prefab[Random.Range(0, prefab.Length)];
            
               GameObject barrier = Instantiate(randomElement, transform.position, Quaternion.identity);
               barrier.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
               yield return new WaitForSeconds(1);
            
         }
      }
   }
   
   

   private void OnDisable()
   {
      CancelInvoke(nameof(Spanw));
   }

 
}
