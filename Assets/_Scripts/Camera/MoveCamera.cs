using UnityEngine;
using DG.Tweening;

public class MoveCamera : MonoBehaviour
{

    public void moveUp()
    {
        float step = MyCube.currentCube.transform.localScale.y;

        float endPositionY = transform.position.y + step;
        float duration = 1f;

        transform.DOMoveY(endPositionY, 1f, false);
    }

}
