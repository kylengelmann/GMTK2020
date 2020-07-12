// GENERATED AUTOMATICALLY FROM 'Assets/DataAssets/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""e06b4a2f-2787-4bed-8b30-30f6d89382ee"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""b4b4701b-c61a-4cf3-ab89-bf1e992d52a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Discard"",
                    ""type"": ""Button"",
                    ""id"": ""a2ae77b8-798a-463c-8994-5541e34adbdb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""eddcd62a-f49d-44de-a068-1733b586232f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""North"",
                    ""type"": ""Button"",
                    ""id"": ""3b5da7ac-a4b4-4939-a252-6b84c75e591a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""South"",
                    ""type"": ""Button"",
                    ""id"": ""20acc952-4eee-4cd3-acf3-dc1cfba64adc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""East"",
                    ""type"": ""Button"",
                    ""id"": ""a8578904-3ae6-4dd4-88df-f3533b70585c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""West"",
                    ""type"": ""Button"",
                    ""id"": ""e8fed4e6-7792-4096-8145-4c615f9ee304"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EndTurn"",
                    ""type"": ""Button"",
                    ""id"": ""e88ea77c-4c76-4414-bdc9-34e4fd4a82d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""9e65667b-02aa-44be-92ae-815dddcd4b4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""77766785-dbbe-4a9a-99c0-afe8be687b8c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""878bbaa0-93c2-4e6a-a9d1-71c6020c6dc0"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Discard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4648fb32-de76-403d-9e7f-75bc254f5822"",
                    ""path"": ""<Keyboard>/delete"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Discard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b20b9de-ca11-4be3-9026-61c6df5f6a32"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57e25c30-cec6-4cf6-b77c-38b0b830eafa"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""North"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e4af8b2-575e-43f3-9a5d-24eddda530a4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""South"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73239406-e2a0-4138-87af-50c6dd9b03fa"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""East"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e14515bc-b094-47b9-806e-9b398e551467"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""West"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e23d5b1-6ac6-416f-bb0b-70c7b9f78416"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EndTurn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35d46940-5335-4227-9d17-45b573a87a0b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Select = m_Game.FindAction("Select", throwIfNotFound: true);
        m_Game_Discard = m_Game.FindAction("Discard", throwIfNotFound: true);
        m_Game_Escape = m_Game.FindAction("Escape", throwIfNotFound: true);
        m_Game_North = m_Game.FindAction("North", throwIfNotFound: true);
        m_Game_South = m_Game.FindAction("South", throwIfNotFound: true);
        m_Game_East = m_Game.FindAction("East", throwIfNotFound: true);
        m_Game_West = m_Game.FindAction("West", throwIfNotFound: true);
        m_Game_EndTurn = m_Game.FindAction("EndTurn", throwIfNotFound: true);
        m_Game_Reset = m_Game.FindAction("Reset", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Select;
    private readonly InputAction m_Game_Discard;
    private readonly InputAction m_Game_Escape;
    private readonly InputAction m_Game_North;
    private readonly InputAction m_Game_South;
    private readonly InputAction m_Game_East;
    private readonly InputAction m_Game_West;
    private readonly InputAction m_Game_EndTurn;
    private readonly InputAction m_Game_Reset;
    public struct GameActions
    {
        private @GameControls m_Wrapper;
        public GameActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_Game_Select;
        public InputAction @Discard => m_Wrapper.m_Game_Discard;
        public InputAction @Escape => m_Wrapper.m_Game_Escape;
        public InputAction @North => m_Wrapper.m_Game_North;
        public InputAction @South => m_Wrapper.m_Game_South;
        public InputAction @East => m_Wrapper.m_Game_East;
        public InputAction @West => m_Wrapper.m_Game_West;
        public InputAction @EndTurn => m_Wrapper.m_Game_EndTurn;
        public InputAction @Reset => m_Wrapper.m_Game_Reset;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_GameActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnSelect;
                @Discard.started -= m_Wrapper.m_GameActionsCallbackInterface.OnDiscard;
                @Discard.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnDiscard;
                @Discard.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnDiscard;
                @Escape.started -= m_Wrapper.m_GameActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnEscape;
                @North.started -= m_Wrapper.m_GameActionsCallbackInterface.OnNorth;
                @North.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnNorth;
                @North.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnNorth;
                @South.started -= m_Wrapper.m_GameActionsCallbackInterface.OnSouth;
                @South.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnSouth;
                @South.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnSouth;
                @East.started -= m_Wrapper.m_GameActionsCallbackInterface.OnEast;
                @East.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnEast;
                @East.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnEast;
                @West.started -= m_Wrapper.m_GameActionsCallbackInterface.OnWest;
                @West.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnWest;
                @West.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnWest;
                @EndTurn.started -= m_Wrapper.m_GameActionsCallbackInterface.OnEndTurn;
                @EndTurn.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnEndTurn;
                @EndTurn.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnEndTurn;
                @Reset.started -= m_Wrapper.m_GameActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnReset;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Discard.started += instance.OnDiscard;
                @Discard.performed += instance.OnDiscard;
                @Discard.canceled += instance.OnDiscard;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
                @North.started += instance.OnNorth;
                @North.performed += instance.OnNorth;
                @North.canceled += instance.OnNorth;
                @South.started += instance.OnSouth;
                @South.performed += instance.OnSouth;
                @South.canceled += instance.OnSouth;
                @East.started += instance.OnEast;
                @East.performed += instance.OnEast;
                @East.canceled += instance.OnEast;
                @West.started += instance.OnWest;
                @West.performed += instance.OnWest;
                @West.canceled += instance.OnWest;
                @EndTurn.started += instance.OnEndTurn;
                @EndTurn.performed += instance.OnEndTurn;
                @EndTurn.canceled += instance.OnEndTurn;
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    public interface IGameActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnDiscard(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
        void OnNorth(InputAction.CallbackContext context);
        void OnSouth(InputAction.CallbackContext context);
        void OnEast(InputAction.CallbackContext context);
        void OnWest(InputAction.CallbackContext context);
        void OnEndTurn(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
    }
}
