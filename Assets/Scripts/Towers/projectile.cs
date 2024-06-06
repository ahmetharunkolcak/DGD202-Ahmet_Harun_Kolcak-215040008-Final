using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public Rigidbody therb;
    public float movespeed;

    public float damageamount;

    private bool hasdamaged;
    // Start is called before the first frame update
    void Start()
    {
        therb.velocity = transform.forward * movespeed;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Enemy" && !hasdamaged)
        {
            other.GetComponent<enemy_health_controller>().takedamage(damageamount);
            hasdamaged = true;
        }
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
