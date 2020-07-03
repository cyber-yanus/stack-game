using UnityEngine;

public class CubeStop : IAction
{


    public void execute(MyCube target)
    {
        float remainder = target.transform.position.z - MyCube.lastCube.transform.position.z;

        Debug.Log(remainder);

    }
}
