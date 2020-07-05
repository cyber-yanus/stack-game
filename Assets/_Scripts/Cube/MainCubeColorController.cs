using UnityEngine;

public class MainCubeColorController : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Renderer>().material.color = getRandomColor();
    }

    private Color getRandomColor()
    {
        return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
}
