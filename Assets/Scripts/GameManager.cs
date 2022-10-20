using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;

    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;

    public Slider gameProgressSlider;      
    public static int currentLevelIndex;
    public TextMeshProUGUI currentLevelTxt;
    public TextMeshProUGUI nextLevelTxt;

    public static int noOfPassedRings;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        noOfPassedRings = 0;

        Time.timeScale = 1;
        gameOver = false;
        levelCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Update Our UI
        currentLevelTxt.text = currentLevelIndex.ToString();
        nextLevelTxt.text = (currentLevelIndex + 1).ToString();

        // Update the progress of the slider
        int progress = noOfPassedRings * 100 / FindObjectOfType<HelixManager>().noOfRings;
        gameProgressSlider.value = progress;

        // Game Over Conditionals
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Level");
            }
        }

        // Level Completed Conditionals
        if (levelCompleted)
        {
            levelCompletedPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
                SceneManager.LoadScene("Level");
            }
        }
    }
}
