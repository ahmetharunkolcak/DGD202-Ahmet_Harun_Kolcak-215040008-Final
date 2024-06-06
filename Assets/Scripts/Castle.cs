using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public float totalhealth = 100f;
    [HideInInspector]
    public float currenthealth;

    public Slider healthslider;

    public Transform[] attackpoints;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = totalhealth;

        healthslider.maxValue = totalhealth;
        healthslider.value = currenthealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(float damagetotake)
    {
        currenthealth -= damagetotake;

        if (currenthealth <= 0)
        {
            currenthealth = 0;

            gameObject.SetActive(false);
        }

        healthslider.value = currenthealth;
    }
}
