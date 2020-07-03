using System;
using UnityEngine;

public class MyCube : MonoBehaviour
{   
    public static MyCube currentCube { get; private set; }
    public static MyCube lastCube { get; private set; }

    public ActionType currentActionType;
    private IAction action;



    private void OnEnable()
    {
        if (lastCube == null)
            lastCube = GameObject.Find("Main Cube").GetComponent<MyCube>();

        currentCube = this;
    }


    private void Update()
    {
        selectAction(currentActionType);

        if(action != null)
            action.execute(this);
    }

    public void selectAction(ActionType type)
    {
        
        switch (type)
        {
            case ActionType.MOVE:
                action = new CubeMove();
                break;

            case ActionType.STOP:
                action = new CubeStop();
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