using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;
    public static bool isGameStarted;
    public static bool mute = false;

    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;

    public Slider gameProgressSlider;      
    public static int currentLevelIndex;
    public TextMeshProUGUI currentLevelTxt;
    public TextMeshProUGUI nextLevelTxt;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI highScoreTxt;

    public static int noOfPassedRings;
    public static int score = 0;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        noOfPassedRings = 0;
        Time.timeScale = 1;
        highScoreTxt.text = "High Score\n" + PlayerPrefs.GetInt("HighScore", 0);
        isGameStarted = gameOver = levelCompleted = false;
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

        scoreTxt.text = score.ToString();

        // Start Level
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;

            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);

        }

        // Game Over Conditionals
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                if (score > PlayerPrefs.GetInt("HighScore", 0))
                    PlayerPrefs.SetInt("HighScore", score);
                score = 0;
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
