// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""ScopeMode"",
            ""id"": ""44659ee7-9597-4a3f-90b6-7ff60fda0a42"",
            ""actions"": [
                {
                    ""name"": ""Look Around"",
                    ""type"": ""Value"",
                    ""id"": ""11354b6f-1923-430d-92b6-d0b08cb4e454"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""0b0eb263-fb75-4c80-8523-1bce78e23e5f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7236a476-a27d-491a-9ead-f4cb4529d667"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Gas"",
                    ""type"": ""Value"",
                    ""id"": ""304ea12f-c113-46b6-9311-fc7969a1c771"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Break"",
                    ""type"": ""Button"",
                    ""id"": ""4264afc5-0e64-4666-a752-c64b58d502c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""fd15e322-5de1-4311-902e-70c2480d22b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Gadget"",
                    ""type"": ""Button"",
                    ""id"": ""a531bf2b-f607-4c59-a3d5-079680170409"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0c942d97-dc51-4fd2-b6a3-c047d42ba1d6"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.15,max=0.9)"",
                    ""groups"": """",
                    ""action"": ""Look Around"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d19c27d9-2e12-47ab-83b7-840c63980c3a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""10f91d06-3755-48d3-9659-91fcd7838c70"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3f1a3243-4264-4709-9a9b-8d8a821fa3fe"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""741bc164-7018-4bfb-bc98-935a60a60628"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""28d56db4-32b0-48f6-a592-ddc19a23b257"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6766a53c-d9a4-423b-a094-775c6831727b"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8caa8a29-ee40-481f-acca-f4f43f042769"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3c751d81-6da1-4220-9897-5834e4d5a249"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdddecf1-bd29-458d-8dfe-7ad40e400123"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5134b0ab-1878-4247-8a14-9b64bcd118b7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""071380fc-1bd9-45ce-b5ad-dab980d4d590"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""af5117e6-cc6f-4757-bc1c-186bb884a82f"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""89119e39-498b-43f0-aad3-54be0872260e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""b13d2aec-3b53-44e5-ab2a-12dfb89aad7e"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""0adfe4da-75bd-46c2-8cba-c6bf1ceca4ba"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""995295e5-415f-4488-b15f-0e674ecee087"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""20ac4859-f30e-4c07-b839-1f673fbf8190"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""681510f3-e784-473f-b782-b1d3e4890196"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9a058ff9-5a70-4c66-8d2c-2fcaad0d1f09"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""288b601b-0775-4193-8a15-82127c5f2cf6"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""014dced6-df83-465c-9e99-ef0161b935a3"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gadget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08af872b-d70b-4e41-92a4-b7b66e502e6a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gadget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // ScopeMode
        m_ScopeMode = asset.FindActionMap("ScopeMode", throwIfNotFound: true);
        m_ScopeMode_LookAround = m_ScopeMode.FindAction("Look Around", throwIfNotFound: true);
        m_ScopeMode_Move = m_ScopeMode.FindAction("Move", throwIfNotFound: true);
        m_ScopeMode_Fire = m_ScopeMode.FindAction("Fire", throwIfNotFound: true);
        m_ScopeMode_Gas = m_ScopeMode.FindAction("Gas", throwIfNotFound: true);
        m_ScopeMode_Break = m_ScopeMode.FindAction("Break", throwIfNotFound: true);
        m_ScopeMode_Pause = m_ScopeMode.FindAction("Pause", throwIfNotFound: true);
        m_ScopeMode_Gadget = m_ScopeMode.FindAction("Gadget", throwIfNotFound: true);
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

    // ScopeMode
    private readonly InputActionMap m_ScopeMode;
    private IScopeModeActions m_ScopeModeActionsCallbackInterface;
    private readonly InputAction m_ScopeMode_LookAround;
    private readonly InputAction m_ScopeMode_Move;
    private readonly InputAction m_ScopeMode_Fire;
    private readonly InputAction m_ScopeMode_Gas;
    private readonly InputAction m_ScopeMode_Break;
    private readonly InputAction m_ScopeMode_Pause;
    private readonly InputAction m_ScopeMode_Gadget;
    public struct ScopeModeActions
    {
        private @PlayerControls m_Wrapper;
        public ScopeModeActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LookAround => m_Wrapper.m_ScopeMode_LookAround;
        public InputAction @Move => m_Wrapper.m_ScopeMode_Move;
        public InputAction @Fire => m_Wrapper.m_ScopeMode_Fire;
        public InputAction @Gas => m_Wrapper.m_ScopeMode_Gas;
        public InputAction @Break => m_Wrapper.m_ScopeMode_Break;
        public InputAction @Pause => m_Wrapper.m_ScopeMode_Pause;
        public InputAction @Gadget => m_Wrapper.m_ScopeMode_Gadget;
        public InputActionMap Get() { return m_Wrapper.m_ScopeMode; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ScopeModeActions set) { return set.Get(); }
        public void SetCallbacks(IScopeModeActions instance)
        {
            if (m_Wrapper.m_ScopeModeActionsCallbackInterface != null)
            {
                @LookAround.started -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnLookAround;
                @LookAround.performed -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnLookAround;
                @LookAround.canceled -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnLookAround;
                @Move.started -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnMove;
                @Fire.started -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnFire;
                @Gas.started -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnGas;
                @Gas.performed -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnGas;
                @Gas.canceled -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnGas;
                @Break.started -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnBreak;
                @Break.performed -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnBreak;
                @Break.canceled -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnBreak;
                @Pause.started -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnPause;
                @Gadget.started -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnGadget;
                @Gadget.performed -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnGadget;
                @Gadget.canceled -= m_Wrapper.m_ScopeModeActionsCallbackInterface.OnGadget;
            }
            m_Wrapper.m_ScopeModeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LookAround.started += instance.OnLookAround;
                @LookAround.performed += instance.OnLookAround;
                @LookAround.canceled += instance.OnLookAround;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Gas.started += instance.OnGas;
                @Gas.performed += instance.OnGas;
                @Gas.canceled += instance.OnGas;
                @Break.started += instance.OnBreak;
                @Break.performed += instance.OnBreak;
                @Break.canceled += instance.OnBreak;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Gadget.started += instance.OnGadget;
                @Gadget.performed += instance.OnGadget;
                @Gadget.canceled += instance.OnGadget;
            }
        }
    }
    public ScopeModeActions @ScopeMode => new ScopeModeActions(this);
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    public interface IScopeModeActions
    {
        void OnLookAround(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnGas(InputAction.CallbackContext context);
        void OnBreak(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnGadget(InputAction.CallbackContext context);
    }
}
