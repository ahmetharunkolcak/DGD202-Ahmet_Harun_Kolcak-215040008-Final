using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    public Tower towertoplace;
    
    public void selecttower()
    {
        TowerManager.instance.starttowerplacement(towertoplace);
    }
}
