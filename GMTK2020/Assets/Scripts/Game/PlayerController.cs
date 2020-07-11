using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerObject playerObject;
    GameControls gameControls;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GetComponent<PlayerObject>();
        gameControls = new GameControls();
        gameControls.Debug.Move.performed += OnMove;
        gameControls.Debug.ProcessActions.performed += ProcessQueue;

        gameControls.Enable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        if(direction.y > .5f)
        {
            ActionManager.Get().AddActionToQueue(ActionType.MoveUp);
            Debug.Log("Up");
        }
        else if(direction.y < -.5f)
        {
            ActionManager.Get().AddActionToQueue(ActionType.MoveDown);
            Debug.Log("Down");
        }
        else if (direction.x > .5f)
        {
            ActionManager.Get().AddActionToQueue(ActionType.MoveRight);
            Debug.Log("Right");
        }
        else if (direction.x < -.5f)
        {
            Debug.Log("Left");
            ActionManager.Get().AddActionToQueue(ActionType.MoveLeft);
        }
    }

    private void ProcessQueue(InputAction.CallbackContext context)
    {
        ActionManager.Get().StartProcessingQueue(playerObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
