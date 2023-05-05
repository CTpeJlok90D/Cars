//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Input/InputMap.inputactions
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

public partial class @InputMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMap"",
    ""maps"": [
        {
            ""name"": ""Car"",
            ""id"": ""0d270ed9-3fcb-4a97-95c9-1cfd3ce70082"",
            ""actions"": [
                {
                    ""name"": ""Gas"",
                    ""type"": ""Value"",
                    ""id"": ""07ffc9dd-b4f6-47df-b720-bc98b9b7dcd1"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""78adfb7a-51b0-4250-96c9-f5b2ad675e6f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Boost"",
                    ""type"": ""Button"",
                    ""id"": ""9a16f027-c62d-4e51-9491-4e55235e2595"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CameraTargetChange"",
                    ""type"": ""Button"",
                    ""id"": ""eed17cc0-ed14-4580-ba42-4b8992939f94"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WS"",
                    ""id"": ""8520d1ab-6a40-465b-a9c5-68a6b27acd3d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7fe055a3-40df-4eba-bfa2-0c7bc86033e7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d8a8c02c-2be7-4131-9df0-466f31c286cd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""4bf98a78-4587-4854-8f70-4bca0e4f8a5a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9f7b4002-2c58-45a4-9add-53837e632bd0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""74dcee63-a6c4-4673-b63c-f930658d0475"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5772cad7-4788-4a14-a29f-6530a6990518"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97bdb782-f795-4cf5-b94b-bb71dbe6661c"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraTargetChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Car
        m_Car = asset.FindActionMap("Car", throwIfNotFound: true);
        m_Car_Gas = m_Car.FindAction("Gas", throwIfNotFound: true);
        m_Car_Rotate = m_Car.FindAction("Rotate", throwIfNotFound: true);
        m_Car_Boost = m_Car.FindAction("Boost", throwIfNotFound: true);
        m_Car_CameraTargetChange = m_Car.FindAction("CameraTargetChange", throwIfNotFound: true);
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

    // Car
    private readonly InputActionMap m_Car;
    private List<ICarActions> m_CarActionsCallbackInterfaces = new List<ICarActions>();
    private readonly InputAction m_Car_Gas;
    private readonly InputAction m_Car_Rotate;
    private readonly InputAction m_Car_Boost;
    private readonly InputAction m_Car_CameraTargetChange;
    public struct CarActions
    {
        private @InputMap m_Wrapper;
        public CarActions(@InputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Gas => m_Wrapper.m_Car_Gas;
        public InputAction @Rotate => m_Wrapper.m_Car_Rotate;
        public InputAction @Boost => m_Wrapper.m_Car_Boost;
        public InputAction @CameraTargetChange => m_Wrapper.m_Car_CameraTargetChange;
        public InputActionMap Get() { return m_Wrapper.m_Car; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarActions set) { return set.Get(); }
        public void AddCallbacks(ICarActions instance)
        {
            if (instance == null || m_Wrapper.m_CarActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CarActionsCallbackInterfaces.Add(instance);
            @Gas.started += instance.OnGas;
            @Gas.performed += instance.OnGas;
            @Gas.canceled += instance.OnGas;
            @Rotate.started += instance.OnRotate;
            @Rotate.performed += instance.OnRotate;
            @Rotate.canceled += instance.OnRotate;
            @Boost.started += instance.OnBoost;
            @Boost.performed += instance.OnBoost;
            @Boost.canceled += instance.OnBoost;
            @CameraTargetChange.started += instance.OnCameraTargetChange;
            @CameraTargetChange.performed += instance.OnCameraTargetChange;
            @CameraTargetChange.canceled += instance.OnCameraTargetChange;
        }

        private void UnregisterCallbacks(ICarActions instance)
        {
            @Gas.started -= instance.OnGas;
            @Gas.performed -= instance.OnGas;
            @Gas.canceled -= instance.OnGas;
            @Rotate.started -= instance.OnRotate;
            @Rotate.performed -= instance.OnRotate;
            @Rotate.canceled -= instance.OnRotate;
            @Boost.started -= instance.OnBoost;
            @Boost.performed -= instance.OnBoost;
            @Boost.canceled -= instance.OnBoost;
            @CameraTargetChange.started -= instance.OnCameraTargetChange;
            @CameraTargetChange.performed -= instance.OnCameraTargetChange;
            @CameraTargetChange.canceled -= instance.OnCameraTargetChange;
        }

        public void RemoveCallbacks(ICarActions instance)
        {
            if (m_Wrapper.m_CarActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICarActions instance)
        {
            foreach (var item in m_Wrapper.m_CarActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CarActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CarActions @Car => new CarActions(this);
    public interface ICarActions
    {
        void OnGas(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnBoost(InputAction.CallbackContext context);
        void OnCameraTargetChange(InputAction.CallbackContext context);
    }
}