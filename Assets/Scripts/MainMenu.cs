using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void Scenes(int numbersScenes) {
        SceneManager.LoadScene(numbersScenes);
    }

    public void Exit() { 
        Application.Quit();
    }
}
