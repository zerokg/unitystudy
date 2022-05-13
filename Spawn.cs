using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject obj;
    public float time;
    public Transform[] point;

    public int Max;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Create", time, time);
    }

    void Create()
    {
        if (count >= Max)
            return;
        count++;
        int i = Random.Range(0, point.Length);
        Instantiate(obj, point[i]);
    }
}
