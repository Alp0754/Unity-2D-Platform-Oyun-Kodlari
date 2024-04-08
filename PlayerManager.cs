using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    bool dead = false;
    Transform muzzle;
    public Transform bullet,FloatingText,bloodParticle;
    public float bulletSpeed;
    public Slider slider;
   
    void Start()
    {
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        bool mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;

        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {
            ShootBullet();
        }
    }

    public void GetDamage(float damage)
    {
        Instantiate(FloatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text=damage.ToString();
        if ((health - damage) >= 0)
        {
            health = health - damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
    }

    void AmIDead()
    {
        if (health<=0)
        {
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity),3f);
            DataManager.instance.LoseProcess();
            dead = true;
            Destroy(gameObject);
        }
    }

    void ShootBullet()
    {
        Transform tempBullet;
        tempBullet=Instantiate(bullet,muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward*bulletSpeed);
        DataManager.instance.ShotBullet++;

    }

}
