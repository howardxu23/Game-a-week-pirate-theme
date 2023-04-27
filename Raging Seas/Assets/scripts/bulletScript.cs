using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public int damage=1;
    public float speed = 20;
    [SerializeField]
    private float shotLifespan=2;
    Rigidbody2D rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = new Vector2(transform.up.x*speed,transform.up.y*speed);
        //destorys itself when time expires
        shotLifespan-=Time.deltaTime;
        if(shotLifespan <= 0)
        {
            Destroy(gameObject);
        }
    }
}
