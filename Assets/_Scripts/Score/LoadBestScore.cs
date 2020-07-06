using UnityEngine;
using UnityEngine.UI;

public class LoadBestScore : MonoBehaviour
{
    private void OnEnable()
    {
        loadScore();
    }


    private void startAnimation()
    {
        Animation strtAnim = GetComponent<Animation>();
        strtAnim.Play();
    }

    private void loadScore()
    {
        Text bestScoreText = GetComponent<Text>();

        int bestScore = PlayerPrefs.GetInt("player score");

        bestScoreText.text = bestScore.ToString();
    }
}
