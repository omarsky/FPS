//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerControl"",
            ""id"": ""0e8ae381-ed4f-4486-bf2b-389b65233e6b"",
            ""actions"": [
                {
                    ""name"": ""WASD"",
                    ""type"": ""Value"",
                    ""id"": ""fd26366f-8f14-4a84-8cb0-14a5a6800ee5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""313cacb6-2f08-4c77-9925-c47818ec1904"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""a75b654d-2bb0-4936-a013-d6ea23f670a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Zieg"",
                    ""type"": ""Button"",
                    ""id"": ""431ebc52-477e-4040-9374-864bca659dc9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""83c62e8b-0363-404d-adfe-95ca419a0a04"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""efc3ae1b-3b8c-4450-9892-e1938da74d54"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""46d545fd-0450-456e-a555-11966df54f26"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4e9d6185-5471-4855-afe4-12d10ae3bdbc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""425338a7-f254-473f-8fcb-b3ca2b043105"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""17d1238f-807b-4bed-883b-5fcb216ba892"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1308ee7-d4ec-4ade-a945-8220d37aa649"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b3a6bbe-bea8-4296-b5bd-ba601abc21ce"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zieg"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControl
        m_PlayerControl = asset.FindActionMap("PlayerControl", throwIfNotFound: true);
        m_PlayerControl_WASD = m_PlayerControl.FindAction("WASD", throwIfNotFound: true);
        m_PlayerControl_Rotation = m_PlayerControl.FindAction("Rotation", throwIfNotFound: true);
        m_PlayerControl_Shoot = m_PlayerControl.FindAction("Shoot", throwIfNotFound: true);
        m_PlayerControl_Zieg = m_PlayerControl.FindAction("Zieg", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerControl
    private readonly InputActionMap m_PlayerControl;
    private IPlayerControlActions m_PlayerControlActionsCallbackInterface;
    private readonly InputAction m_PlayerControl_WASD;
    private readonly InputAction m_PlayerControl_Rotation;
    private readonly InputAction m_PlayerControl_Shoot;
    private readonly InputAction m_PlayerControl_Zieg;
    public struct PlayerControlActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerControlActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @WASD => m_Wrapper.m_PlayerControl_WASD;
        public InputAction @Rotation => m_Wrapper.m_PlayerControl_Rotation;
        public InputAction @Shoot => m_Wrapper.m_PlayerControl_Shoot;
        public InputAction @Zieg => m_Wrapper.m_PlayerControl_Zieg;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlActions instance)
        {
            if (m_Wrapper.m_PlayerControlActionsCallbackInterface != null)
            {
                @WASD.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnWASD;
                @WASD.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnWASD;
                @WASD.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnWASD;
                @Rotation.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnRotation;
                @Shoot.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnShoot;
                @Zieg.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnZieg;
                @Zieg.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnZieg;
                @Zieg.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnZieg;
            }
            m_Wrapper.m_PlayerControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @WASD.started += instance.OnWASD;
                @WASD.performed += instance.OnWASD;
                @WASD.canceled += instance.OnWASD;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Zieg.started += instance.OnZieg;
                @Zieg.performed += instance.OnZieg;
                @Zieg.canceled += instance.OnZieg;
            }
        }
    }
    public PlayerControlActions @PlayerControl => new PlayerControlActions(this);
    public interface IPlayerControlActions
    {
        void OnWASD(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnZieg(InputAction.CallbackContext context);
    }
}
