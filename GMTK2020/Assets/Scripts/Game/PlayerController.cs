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
        playerObject.OnCharacterDeath += OnPlayerDied;

        gameControls = new GameControls();

        gameControls.Game.Select.performed += OnSelect;
        gameControls.Game.Escape.performed += OnEscape;
        gameControls.Game.Discard.performed += OnDiscard;
        gameControls.Game.North.performed += OnNorth;
        gameControls.Game.South.performed += OnSouth;
        gameControls.Game.East.performed += OnEast;
        gameControls.Game.West.performed += OnWest;
        gameControls.Game.EndTurn.performed += OnEndTurn;
        gameControls.Game.Reset.performed += OnResetLevel;

        gameControls.Enable();

        LevelManager.Get().OnLevelStateChange += OnLevelStateChange;
    }

    void OnSelect(InputAction.CallbackContext context)
    {
        LevelManager.Get().hand.OnClick();
    }

    void OnDiscard(InputAction.CallbackContext context)
    {
        LevelManager.Get().hand.OnDiscardPressed();
    }

    void OnEscape(InputAction.CallbackContext context)
    {
        LevelManager.Get().hand.OnEscapePressed();
    }

    void OnNorth(InputAction.CallbackContext context)
    {
        LevelManager.Get().hand.OnDirectionSelected(Direction.North);
    }

    void OnSouth(InputAction.CallbackContext context)
    {
        LevelManager.Get().hand.OnDirectionSelected(Direction.South);
    }
    void OnEast(InputAction.CallbackContext context)
    {
        LevelManager.Get().hand.OnDirectionSelected(Direction.East);
    }
    void OnWest(InputAction.CallbackContext context)
    {
        LevelManager.Get().hand.OnDirectionSelected(Direction.West);
    }
    void OnEndTurn(InputAction.CallbackContext context)
    {
        LevelManager.Get().EndPlayerTurn();
    }

    void OnResetLevel(InputAction.CallbackContext context)
    {
        LevelManager.Get().OnPlayerDeath();
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

    private void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();

        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0f));

        LevelManager.Get().hand.UpdateCardHover(mousePos);
    }

    void OnPlayerDied()
    {
        LevelManager.Get().OnPlayerDeath();
    }
}
