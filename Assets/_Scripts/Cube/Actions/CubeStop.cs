using System.ComponentModel;
using UnityEngine;
using UnityEngine.VFX;

public class CubeStop : IAction
{
    private MyCube target;
    bool check;


    public CubeStop(MyCube target)
    {
        this.target = target;

        float remainder = target.transform.position.z - MyCube.lastCube.transform.position.z;


        float directionZ = remainder > 0 ? 1f : -1f;
        spliteZone(remainder,directionZ);
    }

    public void execute()
    {
        Debug.Log("the cube stopped");
    }



    private void spliteZone(float remainder, float directionZ)
    {
        float newSizeZ = MyCube.lastCube.transform.localScale.z - Mathf.Abs(remainder);
        float dropCubeSize = target.transform.localScale.z - newSizeZ;
        
        
        float newPositionZ = MyCube.lastCube.transform.position.z + (remainder / 2f);
        target.transform.localScale = new Vector3(target.transform.localScale.x, target.transform.localScale.y, newSizeZ);
        target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, newPositionZ);

        float cubeEdge = target.transform.position.z + (newSizeZ / 2f * directionZ);
        float dropCubePositionZ = cubeEdge + (dropCubeSize / 2f * directionZ);

        spawnDropCube(dropCubePositionZ, dropCubeSize);
    }

    private void spawnDropCube(float dropCubePositionZ, float dropCubeSize)
    {
        var dropCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        dropCube.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, dropCubePositionZ);
        dropCube.transform.localScale = new Vector3(target.transform.localScale.x, target.transform.localScale.y, dropCubeSize);

        dropCube.AddComponent<Rigidbody>();
        dropCube.AddComponent<RemoveCube>();
    }
}
