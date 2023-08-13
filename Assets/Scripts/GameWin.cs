using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameWin : MonoBehaviour {

    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject winPanel;

    [SerializeField] private TextMeshProUGUI winCount;
    public int currentCount = 0;

    private void Start() {
        if (PlayerPrefs.HasKey("winCount")) {
            currentCount = PlayerPrefs.GetInt("winCount");
        }
        winCount.text = currentCount.ToString();
    }

    private void FixedUpdate() {
        CheckWinCount();
    }

    public void toMenu() {
        SceneManager.LoadScene("_Menu");
    }
    public void NextLevel(int sceneNumbers) {
        SceneManager.LoadScene(sceneNumbers);
    }

    private void CheckWinCount() {
        if (enemy1 == false && enemy2 == false) {
            winPanel.SetActive(true);
            currentCount++;
            PlayerPrefs.SetInt("winCount", currentCount);
            winCount.text = currentCount.ToString();
            Time.timeScale = 0f;
        }
    }
}
