using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveRandom : MonoBehaviour
{
    public Vector2 minPos;
    public Vector2 maxPos;
    public Vector2 speedVar;
    public Vector2 newPosTimeVar;
    public Vector2 newSpeedTimeVar;

    float posTimer;
    float speedTimer;
    float newPosTime;
    float newSpeedTime;

    NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        SetRandomPosition();
        SetRandomSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        posTimer += Time.deltaTime;
        speedTimer += Time.deltaTime;

        if (posTimer >= newPosTime)
            SetRandomPosition();
        if (speedTimer >= newSpeedTime)
            SetRandomSpeed();
    }

    void SetRandomPosition()
    {
        float newX = Random.Range(minPos.x, maxPos.x);
        float newZ = Random.Range(minPos.y, maxPos.y);
        nav.destination = new Vector3(newX, -1f, newZ);

        newPosTime = Random.Range(newPosTimeVar.x, newPosTimeVar.y);
        posTimer = 0f;
    }

    void SetRandomSpeed()
    {
        nav.speed = Random.Range(speedVar.x, speedVar.y);
        newSpeedTime = Random.Range(newSpeedTimeVar.x, newSpeedTimeVar.y);
        speedTimer = 0f;
    }
}
