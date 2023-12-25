using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterControlMando : MonoBehaviour
{
    private Map _playersControl = null;
    private MapSoloCamara _onlyCamControl = null;
    public Inventario inventario;
    private float _walkSpeed = 3f;
    private float _sprintingSpeed = 6f;

    private bool _isGrounded = true;
    private bool _isSprinting = false;
    public int _jumpforce;
    private Vector3 _direction = Vector3.zero;

    public Camera _mainCamera;
    float yaw;
    float pitch;
    private Vector2 _rotation;

    public float _speedH;
    public float _speedV;

    private Vector3 CamForward;
    private Vector3 CamRight;
    public CharacterController characterController;




    private void OnEnable()
    {
        _playersControl.Enable();
    }

    private void OnDisable()
    {
        _playersControl.Disable();
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

        _playersControl = new Map();
        _onlyCamControl = new MapSoloCamara();
        _playersControl.Exploracion.Movimiento.performed += ReadInput;
        _playersControl.Exploracion.Movimiento.canceled += ReadInput;

        _playersControl.Exploracion.Esprintar.performed += Sprint;
        _playersControl.Exploracion.Esprintar.canceled += Sprint;

        _playersControl.Exploracion.Saltar.performed += Jump;

        _playersControl.Exploracion.Salir.performed += Exit;
        _playersControl.Exploracion.Salir.canceled += Exit;

        _playersControl.Exploracion.Camara.performed += ReadCameraInput;
        _playersControl.Exploracion.Camara.canceled += ReadCameraInput;

        _onlyCamControl.Camara.Camara.performed += ReadCameraInput;
        _onlyCamControl.Camara.Camara.canceled += ReadCameraInput;
    }

    public void ReadInput(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        CamDirection();
        _direction = input.x * CamRight + input.y * CamForward;
        //_direction = new  Vector3(input.x, 0, input.y);
    }

    public void ReadCameraInput(InputAction.CallbackContext context)
    {

        var input = context.ReadValue<Vector2>();

        _rotation.x = input.x;
        _rotation.y = input.y;
        CamDirection();

    }

    private void FixedUpdate()
    {
        //CamDirection();
        //_direction =  CamRight + CamForward;
        OrientarPersonajeHaciaCamara();
        Move();
        CheckGround();
    }

    private void Update()
    {

        //float camRotationX = _mainCamera.transform.rotation.eulerAngles.x;
        //transform.rotation = Quaternion.Euler(camRotationX, 0f, 0f);
        MoveCamera();
    }
    public void addObjeto(GameObject o)
    {
        inventario.objetos.Add(o);
    }
    public void removeObjeto(GameObject o)
    {
        inventario.objetos.Remove(o);
    }

    public void Move()
    {
        if (_isSprinting)
        {
            characterController.Move(_direction * _sprintingSpeed * Time.deltaTime);

            // rbEvan.MovePosition(transform.position += _direction * _sprintingSpeed * Time.deltaTime);
            //transform.position += _direction * _sprintingSpeed * Time.deltaTime;

        }
        else
        {
            characterController.Move(_direction * _walkSpeed * Time.deltaTime);
            //rbEvan.MovePosition(transform.position += _direction * _walkSpeed * Time.deltaTime);
            //transform.position += _direction * _walkSpeed * Time.deltaTime;


        }


    }
    private void CheckGround()
    {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distance = .75f;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, distance))
        {
            Debug.DrawRay(origin, direction * distance, Color.red);
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1 && characterController != null && _isGrounded)
        {
            characterController.Move(Vector3.up * _jumpforce);
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            _isSprinting = true;
        }
        else
        {
            _isSprinting = false;
        }
    }

    private void MoveCamera()
    {
        yaw += _rotation.x * _speedH;
        pitch -= _rotation.y * _speedV;

        _mainCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0);
        //CamDirection();
    }

    private void CamDirection()
    {
        CamForward = _mainCamera.transform.forward;
        CamRight = _mainCamera.transform.right;

        CamForward.y = 0;
        CamRight.y = 0;

        CamForward = CamForward.normalized;
        CamRight = CamRight.normalized;
    }
    private void OrientarPersonajeHaciaCamara()
    {
        // Obtén la rotación actual de la cámara del personaje.
        Quaternion camRotation = _mainCamera.transform.rotation;
        CamDirection();

        // Orienta el personaje hacia la dirección de la cámara.
        transform.rotation = Quaternion.Euler(0, camRotation.eulerAngles.y, 0);
    }

    private void Exit(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void DesactivarMap()
    {
        _playersControl.Disable();
    }
    public void ActivarMap()
    {
        _playersControl.Enable();
    }
    public void DesactivarMapSoloCamara()
    {
        _onlyCamControl.Disable();
    }
    public void ActivarMapSoloCamara()
    {
        _onlyCamControl.Enable();
    }


}

