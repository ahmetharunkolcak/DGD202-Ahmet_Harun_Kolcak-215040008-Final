using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningSystem : MonoBehaviour
{
    public Enemy_Controller enemytospawn;

    public Transform spawnpoint;

    public float timebetweenspawns;
    private float spawncounter;

    public int amounttospawn = 15;

    public Castle thecastle;
    public Path thepath;


    // Start is called before the first frame update
    void Start()
    {
        spawncounter = timebetweenspawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (amounttospawn > 0 && LevelManager.Instance.levelactive)
        {
            spawncounter -= Time.deltaTime;
            if (spawncounter <= 0)
            {
                spawncounter = timebetweenspawns;

                Instantiate(enemytospawn, spawnpoint.position, spawnpoint.rotation).Setup(thecastle, thepath);

                amounttospawn--;
            }
        }
        }
    }

