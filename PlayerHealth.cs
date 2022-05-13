using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 100;
    Vector3 posRespawn;

    bool bDamage;
    public Image imgDamage;
    public Image imgBar;
    public Slider sliderHP;

    public AudioClip clipHurt;
    public AudioClip clipDeath;

    void Start()
    {
        posRespawn = transform.position;
    }

    void Update()
    {
        if(bDamage)
        {
            imgDamage.color = new Color(1, 0, 0, 1);
        }
        else
        {
            imgDamage.color = Color.Lerp(imgDamage.color, Color.clear, 200 * Time.deltaTime);
        }
        bDamage = false;
    }
    public void Respawn()
    {
        hp = 100;
        transform.position = posRespawn;
        GetComponent<Animator>().SetTrigger("Respawn");
        GetComponent<PlayerMove>().enabled = true;
        GetComponent<PlayerAttack>().enabled = true;
        imgBar.transform.localScale = new Vector3(1, 1, 1);
        sliderHP.value = hp;
    }

    public void Damage(int amount)
    {
        if (hp <= 0)
            return;
        hp -= amount;
        bDamage = true;
        imgBar.transform.localScale = new Vector3(hp / 100.0f, 1, 1);
        sliderHP.value = hp;
        GetComponent<AudioSource>().PlayOneShot(clipHurt);
        if(hp <= 0)
        {
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<PlayerMove>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<AudioSource>().PlayOneShot(clipDeath);
            Invoke("Respawn", 3);
        }
    }

    public void SetHP(int value)
    {
        if (value < 0 || value > 100)
            return;
        hp = value;
        imgBar.transform.localScale = new Vector3(hp / 100.0f, 1, 1);
        sliderHP.value = hp;
    }
}
