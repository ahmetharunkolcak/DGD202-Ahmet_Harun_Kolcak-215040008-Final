using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;

    private void Awake()
    {
        instance = this;
    }

    public Tower activetower;

    public Transform indicator;
    public bool isplacing;

    public LayerMask whatisplacement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isplacing)
        {
            indicator.position = getgridposition();

            if (Input.GetMouseButtonDown(0))
            {

                if (MoneyManager.instance.spendmoney(activetower.cost))
                {


                    isplacing = false;

                    Instantiate(activetower, indicator.position, activetower.transform.rotation);

                    indicator.gameObject.SetActive(false);
                }
            }

        }
    }
        public void starttowerplacement(Tower towertoplace)
        {
            activetower = towertoplace;

            isplacing = true;

            Destroy(indicator.gameObject);
        Tower placetower = Instantiate(activetower);
        placetower.enabled = false;
        indicator = placetower.transform;
        }

       public Vector3 getgridposition()
        {

            Vector3 location = Vector3.zero;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 200f, Color.red);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 200f, whatisplacement))
            {
                location = hit.point;
            }

            location.y = 0f;

            return location;
        }
     
}
