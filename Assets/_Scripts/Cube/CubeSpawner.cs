using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    [SerializeField] private MyCube prefabCube;

    [SerializeField] private float distanceFromLastCube;
    [SerializeField] private float startPositionY;
   
    [SerializeField] private SpawnDirection startSpawnDirection;




    void Start()
    {
        startSpawn();
    }

    public void startSpawn()
    {
        var cube = Instantiate(prefabCube);
        
        
        startPositionY += MyCube.currentCube.transform.localScale.y;

        switch (startSpawnDirection)
        {
            case SpawnDirection.LEFT:
                cube.transform.position = new Vector3(0, startPositionY, distanceFromLastCube);
                cube.transform.rotation = Quaternion.Euler(0, 0, 0);

                //startSpawnDirection = SpawnDirection.RIGHT;
                break;

            case SpawnDirection.RIGHT:
                cube.transform.position = new Vector3(distanceFromLastCube, startPositionY, 0);
                cube.transform.rotation = Quaternion.Euler(0, 90, 0);

                startSpawnDirection = SpawnDirection.LEFT;
                break;
        }

    }

   
}

enum SpawnDirection
{ 
    LEFT,
    RIGHT
}

