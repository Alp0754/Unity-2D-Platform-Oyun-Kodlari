using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyME : MonoBehaviour
{
    // Start is called before the first frame update
    public int lifeTime;
    void Start()
    {
        Destroy(gameObject,lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
