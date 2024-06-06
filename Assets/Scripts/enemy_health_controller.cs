using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_health_controller : MonoBehaviour
{
    public float totalhealth;

    public Slider healthbar;

    public int moneyondeath = 50;

    // Start is called before the first frame update
    void Start()
    {
        healthbar.maxValue = totalhealth;
        healthbar.value = totalhealth;

        LevelManager.Instance.activeenemies.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.transform.rotation = Camera.main.transform.rotation;
    }

    public void takedamage(float damageamount)
    {
        totalhealth -= damageamount;
        if (totalhealth <= 0)
        {
            totalhealth = 0;

            Destroy(gameObject);

            MoneyManager.instance.givemoney(moneyondeath);

            LevelManager.Instance.activeenemies.Remove(this);
        }
        healthbar.value = totalhealth;
        healthbar.gameObject.SetActive(true);
    }
}
