using UnityEngine;
using DG.Tweening;

public class CubeMove : IAction
{
    [SerializeField] private float moveSpeed { get; set; }

    private MyCube target;


    public CubeMove(MyCube target, float moveSpeed)
    {
        this.target = target;

        this.moveSpeed = moveSpeed;


        execute();
    }

    public void execute()
    {

        var seq = DOTween.Sequence();
        
        switch (CubeSpawner.startSpawnDirection)
        {
            case SpawnDirection.LEFT:
                seq.Append(target.transform.DOMoveZ(2f, moveSpeed, false));
                seq.Append(target.transform.DOMoveZ(-2f, moveSpeed, false));
                seq.OnComplete(execute);
                break;

            case SpawnDirection.RIGHT:
                seq.Append(target.transform.DOMoveX(2f, moveSpeed, false));
                seq.Append(target.transform.DOMoveX(-2f, moveSpeed, false));
                seq.OnComplete(execute);
                break;
        }


        
    }


}
