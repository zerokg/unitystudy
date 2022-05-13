using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    public AudioClip clipHeart;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ItemHeart")
        {
            GetComponent<AudioSource>().PlayOneShot(clipHeart);
            GetComponent<PlayerHealth>().SetHP(100);
            Destroy(other.gameObject);
        }
    }
}
