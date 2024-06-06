using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public string newgamescene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newgame()
    {
        SceneManager.LoadScene(newgamescene);
    }
    public void quitgame()
    {
        Application.Quit();
        Debug.Log("quit game");
    }
}
