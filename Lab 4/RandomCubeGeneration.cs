using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubeGeneration : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public int numberOfObject = 40;
    public float delay = 3.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;
    public Material[] materialList;
    

    void Start()
    {
        //Lab 4 Zadanie 1
        Vector3 planeBounds = GetComponent<Collider>().bounds.size;
        List<(int, int)> Cords = new List<(int, int)>();
        Collider da32w = gameObject.GetComponent<Collider>();
        int x;
        int z;
        int tmp = numberOfObject;
        while (tmp > 0)
        {
            x = (int)UnityEngine.Random.Range(da32w.bounds.center.x - (planeBounds.x / 2), da32w.bounds.center.x + (planeBounds.x / 2));
            z = (int)UnityEngine.Random.Range(da32w.bounds.center.z - (planeBounds.z / 2), da32w.bounds.center.z+ (planeBounds.z/2));
            if (!Cords.Contains((x, z)))
            {
                Cords.Add((x, z));
                tmp--;
            }
        }

        for (int i = 0; i < numberOfObject; i++)
        {
            this.positions.Add(new Vector3(Cords[i].Item1, 5, Cords[i].Item2));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
   
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            this.block.GetComponent<Renderer>().material = materialList[UnityEngine.Random.Range(0,materialList.Count())];
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
