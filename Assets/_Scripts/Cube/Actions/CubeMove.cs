using UnityEngine;

public class CubeMove : IAction
{
    [SerializeField] private float moveSpeed { get; set; }

    private MyCube target;


    public CubeMove(MyCube target, float moveSpeed)
    {
        this.target = target;

        this.moveSpeed = moveSpeed;            
    }

    public void execute()
    {
        target.transform.position += target.transform.forward * Time.deltaTime * moveSpeed;
    }

}
