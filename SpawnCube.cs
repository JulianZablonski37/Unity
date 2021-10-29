using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public GameObject myPrefab;
    public int numberOfObstacles;
    List<(float, float)> Cords = new List<(float, float)>();


    void Start()
    {
        float x;
        float y;
        while (numberOfObstacles > 0)
        {
            x = Random.Range(0, 10);
            y = Random.Range(0, 10);
            if(!Cords.Contains((x,y)))
            {
                Cords.Add((x, y));
                numberOfObstacles--;
            }
        }
        foreach((float, float) cord in Cords)
        {
            Instantiate(myPrefab, new Vector3(cord.Item1,1,cord.Item2), Quaternion.identity);
        }
        
    }

}
