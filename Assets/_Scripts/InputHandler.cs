using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{

    [SerializeField] private SwipeManager swipeManager;



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
        if (GameController.getInstance().isEndGame)
        {
            SceneManager.LoadScene(0);
        }


        if (MyCube.currentCube != null)
        {
            MyCube.currentCube.selectAction(ActionType.STOP);

            if (MyCube.currentCube.isDocking)
            {

                GameController.getInstance().startGame();
                GameController.getInstance().upScore();
            }
        }




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
