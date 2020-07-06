using UnityEngine;
using DG.Tweening;

public class MoveCamera : MonoBehaviour
{
    public float duration;


    public void moveUp()
    {
        float step = MyCube.currentCube.transform.localScale.y;

        float endPositionY = transform.position.y + step;

        transform.DOMoveY(endPositionY, duration, false);
    }

}
