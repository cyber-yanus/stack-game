using System;
using UnityEngine;

public class MyCube : MonoBehaviour
{   
    public static MyCube currentCube { get; private set; }
    public static MyCube lastCube { get; private set; }

    public float moveSpeed;

    public ActionType startActionType;
    private IAction action;





    private void OnEnable()
    {
        if (lastCube == null)
            lastCube = GameObject.Find("Main Cube").GetComponent<MyCube>();

        currentCube = this;

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
                break;

            default: action = null;
                break;
        }

    
    }


}


public enum ActionType
{ 
    MOVE,
    STOP,
    NONE
}