using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{

    [SerializeField] private SwipeManager swipeManager;

    public UnityEvent spawnEvent;


    #region Unity methods
    private void OnEnable()
    {
        SwipeEvents.OnSwipeUp += OnSwipeUp;
        SwipeEvents.OnSwipeDown += OnSwipeDown;
        SwipeManager.OnSingleTap += OnSingletap;
        SwipeManager.OnDoubleTap += OnDoubleTap;
    }
   
    private void OnDisable()
    {
        SwipeEvents.OnSwipeUp -= OnSwipeUp;
        SwipeEvents.OnSwipeDown -= OnSwipeDown;
        SwipeManager.OnSingleTap -= OnSingletap;
        SwipeManager.OnDoubleTap -= OnDoubleTap;
    }
    #endregion

    //Delegate event callbacks
    #region Event Callback Functions
    private void OnSingletap()
    {
        MyCube.currentCube.selectAction(ActionType.STOP);
        spawnEvent.Invoke();
    }

    private void OnDoubleTap()
    {
                   
    }
    private void OnSwipeDown()
    {
        
    }

    private void OnSwipeUp()
    {
        
    }
    #endregion

}
