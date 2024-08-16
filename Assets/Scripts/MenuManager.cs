using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string sceneName)
    {
        SceneManager.LoadScene ("Scenes/SampleScene");
    }
    
    public void HowToPlay(string sceneName)
    {
        SceneManager.LoadScene ("HowToPlay");
    }
    
    public void Exit()
    {
        Application.Quit ();
    }
}
