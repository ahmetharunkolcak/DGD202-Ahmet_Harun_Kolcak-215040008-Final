using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{

    public static MoneyManager instance;

    private void Awake()
    {
        instance = this;
    }

    public int currentmoney;
    // Start is called before the first frame update
    void Start()
    {
        UIcontroller.instance.goldtext.text = currentmoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void givemoney(int amounttogive)
    {
        currentmoney += amounttogive;

        UIcontroller.instance.goldtext.text = currentmoney.ToString();
    }
        public bool spendmoney(int amounttospend)
        {
            bool canspend = false;

        if (amounttospend <= currentmoney)
        {

            canspend = true;

            Debug.Log("spent" + amounttospend);
            currentmoney -= amounttospend;

        }
        UIcontroller.instance.goldtext.text = currentmoney.ToString();

        return canspend;
        }
    }

