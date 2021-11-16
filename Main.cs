using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public string FirstLevel;

    public GameObject optionsScreen;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartJourney()
    {
        SceneManager.LoadScene(FirstLevel);
    }

     public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }
     public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }
     public void quit()
    {
        Application.Quit();
        Debug.Log("Quitting");
       
    }

}

