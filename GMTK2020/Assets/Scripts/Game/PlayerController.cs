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

        LevelManager.Get().OnLevelStateChange += OnLevelStateChange;
    }


    private void OnDestroy()
    {
        if(gameControls != null)
        {
            gameControls.Disable();
            gameControls.Dispose();
        }
    }



    void OnLevelStateChange(LevelState levelState)
    {

    }

    private void OnMove(InputAction.CallbackContext context)
    {
        if(LevelManager.Get().levelState != LevelState.PlayerTurn)
        {
            return;
        }

        ActionData newAction;
        newAction.type = ActionType.Move;

        Vector2 direction = context.ReadValue<Vector2>();
        if(direction.y > .5f)
        {
            newAction.direction = Direction.North;
            Debug.Log("Up");
        }
        else if(direction.y < -.5f)
        {
            newAction.direction = Direction.South;
            Debug.Log("Down");
        }
        else if (direction.x > .5f)
        {
            newAction.direction = Direction.East;
            Debug.Log("Right");
        }
        else if (direction.x < -.5f)
        {
            newAction.direction = Direction.West;
            Debug.Log("Left");
        }
        else return;

        ActionManager.Get().AddActionToQueue(newAction);
    }

    private void ProcessQueue(InputAction.CallbackContext context)
    {
        if (LevelManager.Get().levelState != LevelState.PlayerTurn)
        {
            return;
        }

        ActionManager.Get().StartProcessingQueue(playerObject);
    }

    private void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();

        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0f));

        LevelManager.Get().hand.UpdateCardHover(mousePos);
    }
}
