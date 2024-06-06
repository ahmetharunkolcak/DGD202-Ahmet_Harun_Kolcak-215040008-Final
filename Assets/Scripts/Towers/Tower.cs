using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3f;
    public LayerMask whatisenemy;

    private Collider[] colliderinrange;
    public List<Enemy_Controller> enemiesinrange = new List<Enemy_Controller>();

    private float checkcounter;
    public float checktime = .2f;

    [HideInInspector]
    public bool enemiesupdated;



    public int cost = 100;

    // Start is called before the first frame update
    void Start()
    {
        checkcounter = checktime;
        
    }

    // Update is called once per frame
    void Update()
    {
        enemiesupdated = false;

      checkcounter -= Time.deltaTime;
        if (checkcounter <= 0)
        {
            checkcounter = checktime;


            colliderinrange = Physics.OverlapSphere(transform.position, range, whatisenemy);
            enemiesinrange.Clear();
            foreach (Collider col in colliderinrange)
            {
                enemiesinrange.Add(col.GetComponent<Enemy_Controller>());
            }
            enemiesupdated = true;
        }
    }
}
