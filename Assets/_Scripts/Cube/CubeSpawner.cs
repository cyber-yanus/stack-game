using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    [SerializeField] private MyCube prefabCube;

    [SerializeField] private float distanceFromLastCube;
    [SerializeField] private float startPositionY;

    public static SpawnDirection startSpawnDirection;


    private void Start()
    {
        startSpawnDirection = SpawnDirection.LEFT;
    }


    public void startSpawn()
    {
        var cube = Instantiate(prefabCube);

        cube.GetComponent<Renderer>().material.color = getRandomColor();
        
        startPositionY += MyCube.currentCube.transform.localScale.y;

        switch (startSpawnDirection)
        {
            case SpawnDirection.LEFT:
                float newPositionX = MyCube.lastCube.transform.position.x;
                cube.transform.position = new Vector3(newPositionX, startPositionY, distanceFromLastCube);
                cube.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;

            case SpawnDirection.RIGHT:
                float newPositionZ = MyCube.lastCube.transform.position.z;
                cube.transform.position = new Vector3(distanceFromLastCube, startPositionY, newPositionZ);
                cube.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }


    }

    private Color getRandomColor()
    {
        float stepH = 0.05f;
        float H, S, V;

        Color startColor = MyCube.lastCube.GetComponent<Renderer>().material.color;

        Color.RGBToHSV(startColor, out H, out S, out V);


        if (H >= 1f)
            H = 0;

        return Color.HSVToRGB(H + stepH, S, V);
    }

    public static void changeStartSpawnDirection()
    {
        switch (startSpawnDirection)
        {
            case SpawnDirection.LEFT:
                startSpawnDirection = SpawnDirection.RIGHT;
                break;

            case SpawnDirection.RIGHT:
                startSpawnDirection = SpawnDirection.LEFT;
                break;

        }

    }


}

public enum SpawnDirection
{ 
    LEFT,
    RIGHT
}

