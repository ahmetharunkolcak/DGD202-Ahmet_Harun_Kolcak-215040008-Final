using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public bool levelactive;
    private bool levelvictory;

    private Castle thecastle;

    public List <enemy_health_controller> activeenemies = new List <enemy_health_controller>();

    private EnemySpawningSystem enemyspawner;
    // Start is called before the first frame update
    void Start()
    {
        thecastle = FindObjectOfType<Castle>();

        enemyspawner = FindObjectOfType<EnemySpawningSystem>();

        levelactive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelactive)
        {
            if(thecastle.currenthealth <= 0)
            {
                levelactive = false;
                levelvictory = false;

                UIcontroller.instance.levelfailscreen.SetActive(true);
                UIcontroller.instance.towerbuttons.SetActive(false);
            }
            if(activeenemies.Count == 0 && enemyspawner.amounttospawn == 0)
            {
                levelactive = false;
                levelvictory = true;

                UIcontroller.instance.levelcompletescreen.SetActive(true);
                UIcontroller.instance.towerbuttons.SetActive(false);
            }
        }
    }
}
