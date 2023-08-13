using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour {

    public static int playerHealth;
    public static bool gameOver;
    public TextMeshProUGUI playerHealthText;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject redOverlay;

    [SerializeField] private TextMeshProUGUI loseCount;
    private int currentCount = 0;

    private void Start() {
        playerHealth = 100;
        gameOver = false;
        Time.timeScale = 1f;
        pauseButton.SetActive(true);

        if (PlayerPrefs.HasKey("loseCount")) {
            currentCount = PlayerPrefs.GetInt("loseCount");
        }
        loseCount.text = currentCount.ToString();
    }

    private void FixedUpdate() { 
        playerHealthText.text = "" + playerHealth;

        if (gameOver) {
            Time.timeScale = 0f;
            currentCount++;
            PlayerPrefs.SetInt("loseCount", currentCount);
            loseCount.text = currentCount.ToString();
            gameOverPanel.SetActive(true);
            pauseButton.SetActive(false);
        }
    }

    public IEnumerator Damage(int damageCount) { 
        playerHealth -= damageCount;
        redOverlay.SetActive(true);

        if (playerHealth <= 0)
            gameOver = true;

        yield return new WaitForSeconds(0.5f);
        redOverlay.SetActive(false);
    }

    public void Restart() {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void ToMenu() {
        SceneManager.LoadScene("_Menu");
        Time.timeScale = 1f;
    }
}
