using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAttack : MonoBehaviour
{
    float timer;
    LineRenderer line;
    Transform ShootPoint;
    public GameObject obj;

    public AudioClip clipGunShot;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        ShootPoint = transform.Find("ShootPoint");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(CrossPlatformInputManager.GetButton("Fire1") && timer >= 0.2f)
        {
            timer = 0;
            Shoot();
            GetComponent<AudioSource>().PlayOneShot(clipGunShot);
            GetComponent<Light>().enabled = true;
        }
        if (timer >= 0.05f)
        {
            line.enabled = false;
            GetComponent<Light>().enabled = false;
        }
    }
    void Shoot()
    {
        Ray ray = new Ray(ShootPoint.position, ShootPoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Shootable")))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            Transform tr = hit.collider.GetComponent<Transform>();
            if (enemyHealth != null)
            {
                enemyHealth.Damage(50);
                Instantiate(obj, tr);
                Score.score += 10;
            }
            line.enabled = true;
            line.SetPosition(0, ShootPoint.position);
            line.SetPosition(1, hit.point);
        }
        else
        {
            line.enabled = true;
            line.SetPosition(0, ShootPoint.position);
            line.SetPosition(1, ShootPoint.position + ray.direction * 100);
        }
    }
}
