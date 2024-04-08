using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float healt;
    public float damage;
    bool colliderBusy = false;
    public Slider slider;
    
   
    void Start()
    {
        slider.maxValue = healt;
        slider.value = healt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player") {
            colliderBusy = true;
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }
        else if (other.tag == "Bullet")
        {
            GetDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }
        

        
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            colliderBusy = false;
        }
    }

    public void GetDamage(float damage)
    {
        if ((healt - damage) >= 0)
        {
            healt = healt - damage;
        }
        else
        {
            healt = 0;
        }
        slider.value = healt;
        AmIDead();
    }

    void AmIDead()
    {
        if (healt <= 0)
        {
            DataManager.instance.EnemyKilled++;
            Destroy(gameObject);
            
        }
    }

}
