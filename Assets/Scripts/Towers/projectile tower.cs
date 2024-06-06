using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectiletower : MonoBehaviour
{
    private Tower thetower;

    public GameObject projectile;
    public Transform firepoint;
    public float timebetweenshots = 1f;
    private float shotcounter;

    private Transform target;
    public Transform launchermodel;

    // Start is called before the first frame update
    void Start()
    {
        thetower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            launchermodel.rotation = Quaternion.Slerp(launchermodel.rotation, Quaternion.LookRotation(target.position - transform.position), 5f * Time.deltaTime);
        launchermodel.rotation = Quaternion.Euler(0f,launchermodel.rotation.eulerAngles.y,0f);
        }
        shotcounter -= Time.deltaTime;
        if (shotcounter <= 0 && target != null)
        {
            shotcounter = timebetweenshots;

            firepoint.LookAt(target);

            Instantiate(projectile, firepoint.position, firepoint.rotation);
        }
        if (thetower.enemiesupdated)
        {
            if (thetower.enemiesinrange.Count > 0)
            {
                float mindistance = thetower.range + 1f;
                foreach (Enemy_Controller enemy in thetower.enemiesinrange)
                {
                    if (enemy != null)
                    {
                        float distance = Vector3.Distance(transform.position, enemy.transform.position);
                        if (distance < mindistance)
                        {
                            mindistance = distance;
                            target = enemy.transform;
                        }
                    }
                }
            }
            else
            {
                target = null;
            }
        }
    }
}
