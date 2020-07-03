using UnityEngine;

public class CubeMove : IAction
{
    [SerializeField] private float moveSpeed { get; set; }



    public CubeMove()
    {
        moveSpeed = 1.5f;            
    }

    public void execute(MyCube target)
    {
        target.transform.position += target.transform.forward * Time.deltaTime * moveSpeed;
    }

}
