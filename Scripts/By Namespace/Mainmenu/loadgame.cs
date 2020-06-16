using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class loadgame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void togame()
    {
        SceneManager.LoadScene("Forest");
    }

    public void toloadingscene()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void exit()
    {
        Application.Quit();
    }
}
