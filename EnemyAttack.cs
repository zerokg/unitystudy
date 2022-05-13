using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    GameObject player;
    bool bInRange;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            bInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            bInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 0.5f && bInRange)
        {
            timer = 0;
            player.GetComponent<PlayerHealth>().Damage(10);
            if(player.GetComponent<PlayerHealth>().hp <= 0)
            {
                GetComponent<Animator>().SetTrigger("PlayerDeath");
            }
        }
    }
}
