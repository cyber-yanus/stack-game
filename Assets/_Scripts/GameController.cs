using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    [SerializeField] private CubeSpawner cubeSpawner;
    [SerializeField] private Camera camera;
    [SerializeField] private Text scoreText;

    private int score;

    private void Start()
    {
        
    }


    public static void startGame()
    {
       // cubeSpawner.gameObject.SetActive(true);
    }

    public static void endGame()
    {
        //cubeSpawner.gameObject.SetActive(false);
    }

    public void upScore()
    {
        score++;

        saveScore();

        scoreText.text = score.ToString();

        if (score > 3)
        {
            camera.GetComponent<MoveCamera>().moveUp();
        }

    }

    private void saveScore()
    {
        int lastScore = PlayerPrefs.GetInt("player score");

        if(lastScore < score)
            PlayerPrefs.SetInt("player score", score);
    }

}
