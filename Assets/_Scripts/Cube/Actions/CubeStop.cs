﻿using UnityEngine;

public class CubeStop : IAction
{
    private MyCube target;



    public CubeStop(MyCube target)
    {
        this.target = target;

        float remainder = calculateRemainder();


        float min = 0.04f;
        float max = CubeSpawner.startSpawnDirection == SpawnDirection.LEFT ? 
            MyCube.lastCube.transform.localScale.z : MyCube.lastCube.transform.localScale.x;

        float direction = remainder > 0 ? 1f : -1f;

        if (Mathf.Abs(remainder) < max && Mathf.Abs(remainder) > min)
        {
            target.isDocking = true;
           
            if (CubeSpawner.startSpawnDirection == SpawnDirection.LEFT)
                spliteZoneZ(remainder, direction);
            else if (CubeSpawner.startSpawnDirection == SpawnDirection.RIGHT)
                spliteZoneX(remainder, direction);
        }
        else if (Mathf.Abs(remainder) <= min)
        {
            target.isDocking = true;

            connectionZones();

            GameController.getInstance().combo();
        }
        else
        {
            target.isDocking = false;

            this.target.gameObject.AddComponent<Rigidbody>();
            this.target.gameObject.AddComponent<RemoveCube>();

            GameController.getInstance().endGame();

            Debug.Log("END GAME");
        }
    }

    private float calculateRemainder()
    {
        switch (CubeSpawner.startSpawnDirection)
        {
            case SpawnDirection.LEFT:
                return target.transform.position.z - MyCube.lastCube.transform.position.z;
                

            case SpawnDirection.RIGHT:
                return target.transform.position.x - MyCube.lastCube.transform.position.x;
        }

        return 0;
    }

    public void execute()
    {
        
    }


    private void connectionZones()
    {
        MyCube.currentCube.transform.position = new Vector3(MyCube.lastCube.transform.position.x, 
            MyCube.currentCube.transform.position.y, 
            MyCube.lastCube.transform.position.z);
        
        MyCube.currentCube.transform.localScale = MyCube.lastCube.transform.localScale;
    }


    private void spliteZoneZ(float remainder, float direction)
    {
        float newSizeZ = MyCube.lastCube.transform.localScale.z - Mathf.Abs(remainder);
        float dropCubeSize = target.transform.localScale.z - newSizeZ;
        
        
        float newPositionZ = MyCube.lastCube.transform.position.z + (remainder / 2f);
        target.transform.localScale = new Vector3(target.transform.localScale.x, target.transform.localScale.y, newSizeZ);
        target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, newPositionZ);

        float cubeEdge = target.transform.position.z + (newSizeZ / 2f * direction);
        float dropCubePositionZ = cubeEdge + (dropCubeSize / 2f * direction);

        spawnDropCube(dropCubePositionZ, dropCubeSize);
    }

    private void spliteZoneX(float remainder, float direction)
    {
        float newSizeX = MyCube.lastCube.transform.localScale.x - Mathf.Abs(remainder);
        float dropCubeSize = target.transform.localScale.x - newSizeX;


        float newPositionX = MyCube.lastCube.transform.position.x + (remainder / 2f);
        target.transform.localScale = new Vector3(newSizeX, target.transform.localScale.y, target.transform.localScale.z);
        target.transform.position = new Vector3(newPositionX, target.transform.position.y, target.transform.position.z);

        float cubeEdge = target.transform.position.x + (newSizeX / 2f * direction);
        float dropCubePositionX = cubeEdge + (dropCubeSize / 2f * direction);

        spawnDropCube(dropCubePositionX, dropCubeSize);
    }


    private void spawnDropCube(float dropCubePosition, float dropCubeSize)
    {
        var dropCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        dropCube.GetComponent<Renderer>().material.color = MyCube.currentCube.GetComponent<Renderer>().material.color;

        if (CubeSpawner.startSpawnDirection == SpawnDirection.LEFT)
        {
            dropCube.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, dropCubePosition);
            dropCube.transform.localScale = new Vector3(target.transform.localScale.x, target.transform.localScale.y, dropCubeSize);
        }
        else if (CubeSpawner.startSpawnDirection == SpawnDirection.RIGHT)
        {
            dropCube.transform.position = new Vector3(dropCubePosition, target.transform.position.y, target.transform.position.z);
            dropCube.transform.localScale = new Vector3(dropCubeSize, target.transform.localScale.y, target.transform.localScale.z);
        }

        CubeSpawner.changeStartSpawnDirection();
    
        dropCube.AddComponent<Rigidbody>();
        dropCube.AddComponent<RemoveCube>();
    }
}
