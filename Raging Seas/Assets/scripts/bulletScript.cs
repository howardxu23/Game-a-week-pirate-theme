using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public int damage=1;
    public float speed = 20;
    [SerializeField]
    private float shotLifespan=2;
    // Update is called once per frame
    void Update()
    {
        transform.Translate((transform.up * speed * Time.deltaTime));

        //destorys itself when time expires
        shotLifespan-=Time.deltaTime;
        if(shotLifespan <= 0)
        {
            Destroy(gameObject);
        }
    }
}
