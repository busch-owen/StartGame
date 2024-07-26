//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/PlayerInput.inputactions
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

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""BoardInput"",
            ""id"": ""2961b746-c471-4cb5-90e7-bee0773ee0a0"",
            ""actions"": [
                {
                    ""name"": ""MouseMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""edc8cd02-0bc4-44cc-8d4a-97efee49d5d6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""MouseInput"",
                    ""id"": ""eb245d12-e245-4c9e-8997-b71a25a08d4d"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0bac88bd-b086-458f-8d4f-61629da51464"",
                    ""path"": ""<Mouse>/delta/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cc73152c-a465-4699-bf28-73dba7182034"",
                    ""path"": ""<Mouse>/delta/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fbdbbd22-27e8-4cd4-b624-7ff05f5e5671"",
                    ""path"": ""<Mouse>/delta/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a8835e50-1229-43f8-bc67-52d6dab28805"",
                    ""path"": ""<Mouse>/delta/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // BoardInput
        m_BoardInput = asset.FindActionMap("BoardInput", throwIfNotFound: true);
        m_BoardInput_MouseMovement = m_BoardInput.FindAction("MouseMovement", throwIfNotFound: true);
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

    // BoardInput
    private readonly InputActionMap m_BoardInput;
    private List<IBoardInputActions> m_BoardInputActionsCallbackInterfaces = new List<IBoardInputActions>();
    private readonly InputAction m_BoardInput_MouseMovement;
    public struct BoardInputActions
    {
        private @PlayerInput m_Wrapper;
        public BoardInputActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseMovement => m_Wrapper.m_BoardInput_MouseMovement;
        public InputActionMap Get() { return m_Wrapper.m_BoardInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BoardInputActions set) { return set.Get(); }
        public void AddCallbacks(IBoardInputActions instance)
        {
            if (instance == null || m_Wrapper.m_BoardInputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BoardInputActionsCallbackInterfaces.Add(instance);
            @MouseMovement.started += instance.OnMouseMovement;
            @MouseMovement.performed += instance.OnMouseMovement;
            @MouseMovement.canceled += instance.OnMouseMovement;
        }

        private void UnregisterCallbacks(IBoardInputActions instance)
        {
            @MouseMovement.started -= instance.OnMouseMovement;
            @MouseMovement.performed -= instance.OnMouseMovement;
            @MouseMovement.canceled -= instance.OnMouseMovement;
        }

        public void RemoveCallbacks(IBoardInputActions instance)
        {
            if (m_Wrapper.m_BoardInputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBoardInputActions instance)
        {
            foreach (var item in m_Wrapper.m_BoardInputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BoardInputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BoardInputActions @BoardInput => new BoardInputActions(this);
    public interface IBoardInputActions
    {
        void OnMouseMovement(InputAction.CallbackContext context);
    }
}