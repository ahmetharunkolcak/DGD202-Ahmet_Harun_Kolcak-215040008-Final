using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_Controller : MonoBehaviour
{
    public float movespeed;

    private Path thepath;
    private int currentpoint;
    private bool reachedend;

    public float timebetweenattacks, damageperattack;
    private float attackcounter;

    private Castle thecastle;

    private int selectattackpoint;


    // Start is called before the first frame update
    void Start()
    {
        if (thepath == null)
        {

            thepath = FindObjectOfType<Path>();
        }
        if (thecastle == null)
        {
            thecastle = FindObjectOfType<Castle>();
        }

        attackcounter = timebetweenattacks;

    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.Instance.levelactive)
        {
            if (reachedend == false)
            {
                transform.LookAt(thepath.points[currentpoint]);

                transform.position = Vector3.MoveTowards(transform.position, thepath.points[currentpoint].position, movespeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, thepath.points[currentpoint].position) < .01f)
                {
                    currentpoint = currentpoint + 1;
                }
                if (currentpoint >= thepath.points.Length)
                {
                    reachedend = true;

                    selectattackpoint = Random.Range(0, thecastle.attackpoints.Length);
                }

            }
            else
            {
                transform.position = Vector3.MoveTowards
                    (transform.position, thecastle.attackpoints[selectattackpoint].position, movespeed * Time.deltaTime);

                attackcounter -= Time.deltaTime;
                if (attackcounter <= 0)
                {
                    attackcounter = timebetweenattacks;

                    thecastle.TakeDamage(damageperattack);
                }
            }
        }
    }

    public void Setup(Castle newcastle,Path newpath)
    {
        thecastle = newcastle;
        thepath = newpath;
            
    }
}
