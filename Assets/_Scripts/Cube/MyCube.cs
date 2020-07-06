using UnityEngine;

public class MyCube : MonoBehaviour
{   
    public static MyCube currentCube { get; private set; }
    public static MyCube lastCube { get; private set; }

    public ActionType startActionType;
    private IAction action;

    public float moveSpeed;
    
    public bool isDocking = false;




    private void OnEnable()
    {
        if (lastCube == null)
            lastCube = GameObject.Find("Main Cube").GetComponent<MyCube>();

        currentCube = this;

        transform.localScale = new Vector3(lastCube.transform.localScale.x, transform.localScale.y, lastCube.transform.localScale.z);
    }

    private void Start()
    {
        selectAction(startActionType);
    }


    private void Update()
    {
        if(action != null)
            action.execute();
    }

    public void selectAction(ActionType type)
    {
        
        switch (type)
        {
            case ActionType.MOVE:
                action = new CubeMove(this, moveSpeed);
                break;

            case ActionType.STOP:
                action = new CubeStop(this);

                lastCube = currentCube;

                break;

            default: action = null;
                break;
        }

    
    }


    private void OnDestroy()
    {
        currentCube = null;
        lastCube = null;
    }


}


public enum ActionType
{ 
    MOVE,
    STOP,
    NONE
}