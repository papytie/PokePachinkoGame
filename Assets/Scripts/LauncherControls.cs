//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/LauncherControls.inputactions
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

public partial class @LauncherControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @LauncherControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""LauncherControls"",
    ""maps"": [
        {
            ""name"": ""Launcher"",
            ""id"": ""3e332907-df76-4cab-ab71-be00ccc083a3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""8dab1068-f9d4-4613-b233-d30dcdf1d51a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Launch"",
                    ""type"": ""Button"",
                    ""id"": ""c2bffb11-fd9c-4533-876d-a53a9dc10e05"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Power"",
                    ""type"": ""Value"",
                    ""id"": ""fa0d67fe-7ae5-4944-9ed4-2bd218ad7c15"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""QD"",
                    ""id"": ""3abdd716-dea7-45a0-a81f-9fef0bcf6027"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""86f64a51-fe16-4bd6-8cc3-9f8d2e81c77c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0698c3dd-3317-4b53-b78e-fd14138020b7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows_Left/Right"",
                    ""id"": ""f2e17f56-d908-49db-8a25-936cfdc08de1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3dd8257b-ebd7-4fca-ae00-1ed6bf792b5c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7d5cdf08-6d2b-4a2f-a869-df5b7f0bfdad"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e564228c-8b75-46cb-9f0d-6db3beba0194"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Launch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f261a62f-ba39-45e6-b1be-7c176f3503f3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Launch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""SZ"",
                    ""id"": ""4d2d70fa-3a81-42da-90c1-36f41eceb495"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Power"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""21e80a07-2c55-4644-9da0-ba76190a0fdb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Power"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4c8886ec-853a-47d8-bc85-a7692904fc29"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Power"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows_UP/Down"",
                    ""id"": ""549e9e86-693a-43d6-ab4e-06a3948b10f4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Power"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6081013e-4f18-49e7-85a5-edb621cdfeac"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Power"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9b4ef350-8649-4d1d-883d-4d85255b78a0"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Power"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Launcher
        m_Launcher = asset.FindActionMap("Launcher", throwIfNotFound: true);
        m_Launcher_Move = m_Launcher.FindAction("Move", throwIfNotFound: true);
        m_Launcher_Launch = m_Launcher.FindAction("Launch", throwIfNotFound: true);
        m_Launcher_Power = m_Launcher.FindAction("Power", throwIfNotFound: true);
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

    // Launcher
    private readonly InputActionMap m_Launcher;
    private List<ILauncherActions> m_LauncherActionsCallbackInterfaces = new List<ILauncherActions>();
    private readonly InputAction m_Launcher_Move;
    private readonly InputAction m_Launcher_Launch;
    private readonly InputAction m_Launcher_Power;
    public struct LauncherActions
    {
        private @LauncherControls m_Wrapper;
        public LauncherActions(@LauncherControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Launcher_Move;
        public InputAction @Launch => m_Wrapper.m_Launcher_Launch;
        public InputAction @Power => m_Wrapper.m_Launcher_Power;
        public InputActionMap Get() { return m_Wrapper.m_Launcher; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LauncherActions set) { return set.Get(); }
        public void AddCallbacks(ILauncherActions instance)
        {
            if (instance == null || m_Wrapper.m_LauncherActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_LauncherActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Launch.started += instance.OnLaunch;
            @Launch.performed += instance.OnLaunch;
            @Launch.canceled += instance.OnLaunch;
            @Power.started += instance.OnPower;
            @Power.performed += instance.OnPower;
            @Power.canceled += instance.OnPower;
        }

        private void UnregisterCallbacks(ILauncherActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Launch.started -= instance.OnLaunch;
            @Launch.performed -= instance.OnLaunch;
            @Launch.canceled -= instance.OnLaunch;
            @Power.started -= instance.OnPower;
            @Power.performed -= instance.OnPower;
            @Power.canceled -= instance.OnPower;
        }

        public void RemoveCallbacks(ILauncherActions instance)
        {
            if (m_Wrapper.m_LauncherActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ILauncherActions instance)
        {
            foreach (var item in m_Wrapper.m_LauncherActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_LauncherActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public LauncherActions @Launcher => new LauncherActions(this);
    public interface ILauncherActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLaunch(InputAction.CallbackContext context);
        void OnPower(InputAction.CallbackContext context);
    }
}
