using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController instance;

    public bool isEndGame;

    [SerializeField] private GameObject GameCanvas;
    [SerializeField] private GameObject MenuCanvas;
    [SerializeField] private GameObject ResultCanvas;

    [SerializeField] private CubeSpawner spawner;
    [SerializeField] private Camera camera;
    [SerializeField] private Text scoreText;


    private int score;

    GameController() { }

    private void Start()
    {
        instance = this;
        isEndGame = false;
    }

    public static GameController getInstance()
    {
        return instance;
    }

    public void startGame()
    {
        isEndGame = false;

        canvasSettings(true, false, false);
        spawner.startSpawn();
    }

    public void endGame()
    {
        canvasSettings(true, false, true);
        
        isEndGame = true;
    }

    private void canvasSettings(bool gameCanvas, bool menuCanvas, bool resultCanvas)
    {
        GameCanvas.SetActive(gameCanvas);
        MenuCanvas.SetActive(menuCanvas);
        ResultCanvas.SetActive(resultCanvas);
    }

    public void upScore()
    {
        score++;

        saveScore();

        scoreText.text = score.ToString();

        if (score > 3)
            camera.GetComponent<MoveCamera>().moveUp();
        
    }

    public void combo()
    {
        Handheld.Vibrate();
    }

    private void saveScore()
    {
        int lastScore = PlayerPrefs.GetInt("player score");

        if(lastScore < score)
            PlayerPrefs.SetInt("player score", score);
    }

}
