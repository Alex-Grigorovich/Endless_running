using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefab;
    public float spawnRate = 1;
    public float minGap = 1;
    public float maxGap = 10;
    public int barriersOnScreen = 5;

    private int idx = 0;
    public int rightX = 15;

    public IEnumerator<GameObject> BarrierGen()
    {
        while (true)
        {
            // var randomElement = prefab[0];

            var randomElement = prefab[Random.Range(0, prefab.Length)];

            yield return randomElement;
        }
    }


    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), 1 / spawnRate, 1 / spawnRate);
    }


    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        var barrierGener = BarrierGen();
        while (true)
        {
            barrierGener.MoveNext();

            GameObject barrier2 = Instantiate(barrierGener.Current, transform.position, Quaternion.identity);
            var lastPos = transform.position;
            for (int i = 0; i < barriersOnScreen - 1; i++)
            {
                barrierGener.MoveNext();
                lastPos += new Vector3(Random.Range(minGap, maxGap), 0, 0);
                barrier2 = Instantiate(barrierGener.Current, lastPos, Quaternion.identity);
            }

            yield return new WaitUntil(() => rightX > barrier2.transform.position.x);
        }
    }


    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
}