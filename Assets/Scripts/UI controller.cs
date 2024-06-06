using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIcontroller : MonoBehaviour
{

    public static UIcontroller instance;

    private void Awake()
    {
        instance = this;
    }

    public TMP_Text goldtext;
    public GameObject levelcompletescreen, levelfailscreen;

    public GameObject towerbuttons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
