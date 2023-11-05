//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/Map.inputactions
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

public partial class @Map: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Map()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Map"",
    ""maps"": [
        {
            ""name"": ""Exploracion"",
            ""id"": ""31ebedd1-bb19-4a61-8b4c-22c634bfe2b9"",
            ""actions"": [
                {
                    ""name"": ""Movimiento"",
                    ""type"": ""Value"",
                    ""id"": ""f2875970-2d33-40d4-b499-fcfd5569c599"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Camara"",
                    ""type"": ""Value"",
                    ""id"": ""60272ed1-98d6-4ac5-a287-ad795e3283fb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Saltar"",
                    ""type"": ""Button"",
                    ""id"": ""c412f1e4-b6e4-40f9-b1cb-32c3eebe5e2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Esprintar"",
                    ""type"": ""Button"",
                    ""id"": ""1101c8a4-324a-439e-9cfe-3abee281a812"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Agacharse"",
                    ""type"": ""Button"",
                    ""id"": ""532d5d86-f618-46c0-bca4-bbf32aa57847"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Conversar"",
                    ""type"": ""Button"",
                    ""id"": ""7870e660-b3d7-4297-9c56-08a7dcd494a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Coger"",
                    ""type"": ""Button"",
                    ""id"": ""dd919cce-5b78-440e-9865-351478fa25d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""30cd25c0-0cfe-4bee-8fe2-b41d23c4261b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimiento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6c912d0-179b-448f-9866-41c1a2a1452b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camara"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""737a26c0-7737-4b87-a3fc-7f2b076aceb4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Saltar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd972f15-2985-4d82-9bce-ca4de5c9da3d"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Esprintar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a82bf8a5-5238-4a9e-b4a3-c523c26cef4b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Agacharse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0cac5e86-1daa-45de-9f5c-6f06059df24e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Coger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1455e6da-fd09-471c-b0f2-62478e36a56a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Conversar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Conversacion"",
            ""id"": ""09a11dae-16c8-429c-a286-92883f0276e0"",
            ""actions"": [
                {
                    ""name"": ""Siguiente"",
                    ""type"": ""Button"",
                    ""id"": ""c1bfe0ac-f817-4ad4-9d56-11cfdd45df74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Anterior"",
                    ""type"": ""Button"",
                    ""id"": ""73e6624f-0547-4d36-906d-620e7c0f2347"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Confirmar"",
                    ""type"": ""Button"",
                    ""id"": ""1e2abf13-ed59-4e5f-bfdc-93cd1ac9862c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Opcion"",
                    ""type"": ""Button"",
                    ""id"": ""b10d01f9-e472-46f4-a3f0-1fd38dd58d5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""906a8401-7be6-4f72-ac96-ca3083aa58a7"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Siguiente"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c00ae13-e89e-41fa-a5c6-fe7f08d5e691"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Anterior"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1f1ffd9-4e11-4b1e-b035-8dd12046bf16"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirmar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3d42cc7-9f2e-4b18-ae95-4fdcdcbce286"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Opcion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Exploracion
        m_Exploracion = asset.FindActionMap("Exploracion", throwIfNotFound: true);
        m_Exploracion_Movimiento = m_Exploracion.FindAction("Movimiento", throwIfNotFound: true);
        m_Exploracion_Camara = m_Exploracion.FindAction("Camara", throwIfNotFound: true);
        m_Exploracion_Saltar = m_Exploracion.FindAction("Saltar", throwIfNotFound: true);
        m_Exploracion_Esprintar = m_Exploracion.FindAction("Esprintar", throwIfNotFound: true);
        m_Exploracion_Agacharse = m_Exploracion.FindAction("Agacharse", throwIfNotFound: true);
        m_Exploracion_Conversar = m_Exploracion.FindAction("Conversar", throwIfNotFound: true);
        m_Exploracion_Coger = m_Exploracion.FindAction("Coger", throwIfNotFound: true);
        // Conversacion
        m_Conversacion = asset.FindActionMap("Conversacion", throwIfNotFound: true);
        m_Conversacion_Siguiente = m_Conversacion.FindAction("Siguiente", throwIfNotFound: true);
        m_Conversacion_Anterior = m_Conversacion.FindAction("Anterior", throwIfNotFound: true);
        m_Conversacion_Confirmar = m_Conversacion.FindAction("Confirmar", throwIfNotFound: true);
        m_Conversacion_Opcion = m_Conversacion.FindAction("Opcion", throwIfNotFound: true);
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

    // Exploracion
    private readonly InputActionMap m_Exploracion;
    private List<IExploracionActions> m_ExploracionActionsCallbackInterfaces = new List<IExploracionActions>();
    private readonly InputAction m_Exploracion_Movimiento;
    private readonly InputAction m_Exploracion_Camara;
    private readonly InputAction m_Exploracion_Saltar;
    private readonly InputAction m_Exploracion_Esprintar;
    private readonly InputAction m_Exploracion_Agacharse;
    private readonly InputAction m_Exploracion_Conversar;
    private readonly InputAction m_Exploracion_Coger;
    public struct ExploracionActions
    {
        private @Map m_Wrapper;
        public ExploracionActions(@Map wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movimiento => m_Wrapper.m_Exploracion_Movimiento;
        public InputAction @Camara => m_Wrapper.m_Exploracion_Camara;
        public InputAction @Saltar => m_Wrapper.m_Exploracion_Saltar;
        public InputAction @Esprintar => m_Wrapper.m_Exploracion_Esprintar;
        public InputAction @Agacharse => m_Wrapper.m_Exploracion_Agacharse;
        public InputAction @Conversar => m_Wrapper.m_Exploracion_Conversar;
        public InputAction @Coger => m_Wrapper.m_Exploracion_Coger;
        public InputActionMap Get() { return m_Wrapper.m_Exploracion; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ExploracionActions set) { return set.Get(); }
        public void AddCallbacks(IExploracionActions instance)
        {
            if (instance == null || m_Wrapper.m_ExploracionActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ExploracionActionsCallbackInterfaces.Add(instance);
            @Movimiento.started += instance.OnMovimiento;
            @Movimiento.performed += instance.OnMovimiento;
            @Movimiento.canceled += instance.OnMovimiento;
            @Camara.started += instance.OnCamara;
            @Camara.performed += instance.OnCamara;
            @Camara.canceled += instance.OnCamara;
            @Saltar.started += instance.OnSaltar;
            @Saltar.performed += instance.OnSaltar;
            @Saltar.canceled += instance.OnSaltar;
            @Esprintar.started += instance.OnEsprintar;
            @Esprintar.performed += instance.OnEsprintar;
            @Esprintar.canceled += instance.OnEsprintar;
            @Agacharse.started += instance.OnAgacharse;
            @Agacharse.performed += instance.OnAgacharse;
            @Agacharse.canceled += instance.OnAgacharse;
            @Conversar.started += instance.OnConversar;
            @Conversar.performed += instance.OnConversar;
            @Conversar.canceled += instance.OnConversar;
            @Coger.started += instance.OnCoger;
            @Coger.performed += instance.OnCoger;
            @Coger.canceled += instance.OnCoger;
        }

        private void UnregisterCallbacks(IExploracionActions instance)
        {
            @Movimiento.started -= instance.OnMovimiento;
            @Movimiento.performed -= instance.OnMovimiento;
            @Movimiento.canceled -= instance.OnMovimiento;
            @Camara.started -= instance.OnCamara;
            @Camara.performed -= instance.OnCamara;
            @Camara.canceled -= instance.OnCamara;
            @Saltar.started -= instance.OnSaltar;
            @Saltar.performed -= instance.OnSaltar;
            @Saltar.canceled -= instance.OnSaltar;
            @Esprintar.started -= instance.OnEsprintar;
            @Esprintar.performed -= instance.OnEsprintar;
            @Esprintar.canceled -= instance.OnEsprintar;
            @Agacharse.started -= instance.OnAgacharse;
            @Agacharse.performed -= instance.OnAgacharse;
            @Agacharse.canceled -= instance.OnAgacharse;
            @Conversar.started -= instance.OnConversar;
            @Conversar.performed -= instance.OnConversar;
            @Conversar.canceled -= instance.OnConversar;
            @Coger.started -= instance.OnCoger;
            @Coger.performed -= instance.OnCoger;
            @Coger.canceled -= instance.OnCoger;
        }

        public void RemoveCallbacks(IExploracionActions instance)
        {
            if (m_Wrapper.m_ExploracionActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IExploracionActions instance)
        {
            foreach (var item in m_Wrapper.m_ExploracionActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ExploracionActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ExploracionActions @Exploracion => new ExploracionActions(this);

    // Conversacion
    private readonly InputActionMap m_Conversacion;
    private List<IConversacionActions> m_ConversacionActionsCallbackInterfaces = new List<IConversacionActions>();
    private readonly InputAction m_Conversacion_Siguiente;
    private readonly InputAction m_Conversacion_Anterior;
    private readonly InputAction m_Conversacion_Confirmar;
    private readonly InputAction m_Conversacion_Opcion;
    public struct ConversacionActions
    {
        private @Map m_Wrapper;
        public ConversacionActions(@Map wrapper) { m_Wrapper = wrapper; }
        public InputAction @Siguiente => m_Wrapper.m_Conversacion_Siguiente;
        public InputAction @Anterior => m_Wrapper.m_Conversacion_Anterior;
        public InputAction @Confirmar => m_Wrapper.m_Conversacion_Confirmar;
        public InputAction @Opcion => m_Wrapper.m_Conversacion_Opcion;
        public InputActionMap Get() { return m_Wrapper.m_Conversacion; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ConversacionActions set) { return set.Get(); }
        public void AddCallbacks(IConversacionActions instance)
        {
            if (instance == null || m_Wrapper.m_ConversacionActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ConversacionActionsCallbackInterfaces.Add(instance);
            @Siguiente.started += instance.OnSiguiente;
            @Siguiente.performed += instance.OnSiguiente;
            @Siguiente.canceled += instance.OnSiguiente;
            @Anterior.started += instance.OnAnterior;
            @Anterior.performed += instance.OnAnterior;
            @Anterior.canceled += instance.OnAnterior;
            @Confirmar.started += instance.OnConfirmar;
            @Confirmar.performed += instance.OnConfirmar;
            @Confirmar.canceled += instance.OnConfirmar;
            @Opcion.started += instance.OnOpcion;
            @Opcion.performed += instance.OnOpcion;
            @Opcion.canceled += instance.OnOpcion;
        }

        private void UnregisterCallbacks(IConversacionActions instance)
        {
            @Siguiente.started -= instance.OnSiguiente;
            @Siguiente.performed -= instance.OnSiguiente;
            @Siguiente.canceled -= instance.OnSiguiente;
            @Anterior.started -= instance.OnAnterior;
            @Anterior.performed -= instance.OnAnterior;
            @Anterior.canceled -= instance.OnAnterior;
            @Confirmar.started -= instance.OnConfirmar;
            @Confirmar.performed -= instance.OnConfirmar;
            @Confirmar.canceled -= instance.OnConfirmar;
            @Opcion.started -= instance.OnOpcion;
            @Opcion.performed -= instance.OnOpcion;
            @Opcion.canceled -= instance.OnOpcion;
        }

        public void RemoveCallbacks(IConversacionActions instance)
        {
            if (m_Wrapper.m_ConversacionActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IConversacionActions instance)
        {
            foreach (var item in m_Wrapper.m_ConversacionActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ConversacionActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ConversacionActions @Conversacion => new ConversacionActions(this);
    public interface IExploracionActions
    {
        void OnMovimiento(InputAction.CallbackContext context);
        void OnCamara(InputAction.CallbackContext context);
        void OnSaltar(InputAction.CallbackContext context);
        void OnEsprintar(InputAction.CallbackContext context);
        void OnAgacharse(InputAction.CallbackContext context);
        void OnConversar(InputAction.CallbackContext context);
        void OnCoger(InputAction.CallbackContext context);
    }
    public interface IConversacionActions
    {
        void OnSiguiente(InputAction.CallbackContext context);
        void OnAnterior(InputAction.CallbackContext context);
        void OnConfirmar(InputAction.CallbackContext context);
        void OnOpcion(InputAction.CallbackContext context);
    }
}
