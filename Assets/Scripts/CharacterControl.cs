
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl : MonoBehaviour
{
    private Map _playersControl = null;


    private float _walkSpeed = 5f;
    private float _sprintingSpeed = 8f;

    private bool _isGrounded = true;
    private bool _isSprinting = false;
    public int _jumpforce;
    private Vector3 _direction = Vector3.zero;
    private Rigidbody _rigibody = null;

    public Camera _mainCamera;
    float yaw;
    float pitch;
    private Vector2 _rotation;

    public float _speedH;
    public float _speedV;

    private Vector3 CamForward;
    private Vector3 CamRight;



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
        _rigibody = GetComponent<Rigidbody>();

        _playersControl = new Map();
        _playersControl.Exploracion.Movimiento.performed += ReadInput;
        _playersControl.Exploracion.Movimiento.canceled += ReadInput;

        _playersControl.Exploracion.Esprintar.performed += Sprint;
        _playersControl.Exploracion.Esprintar.canceled += Sprint;

        _playersControl.Exploracion.Saltar.performed += Jump;

        _playersControl.Exploracion.Camara.performed += ReadCameraInput;
        _playersControl.Exploracion.Camara.canceled += ReadCameraInput;

    }

    public void ReadInput(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        _direction = input.x * CamRight + input.y * CamForward;
    }

    public void ReadCameraInput(InputAction.CallbackContext context)
    {
       
        var input = context.ReadValue<Vector2>();
        _rotation.x = input.x;
        _rotation.y = input.y;
        
    }

    private void FixedUpdate()
    {
        
        transform.LookAt( transform.position + _direction );
        Move();
        CheckGround();
    }

    private void Update()
    {
        MoveCamera();
        
    }

    public void Move()
    {
        if (_isSprinting) { 
            transform.position += _direction * _sprintingSpeed * Time.deltaTime;
        }else
        {
            transform.position += _direction * _walkSpeed * Time.deltaTime;
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
        if(context.ReadValue<float>() == 1 && _rigibody != null && _isGrounded) {
            _rigibody.AddForce(Vector3.up * _jumpforce);
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if(context.ReadValue<float>() == 1)
        {
            _isSprinting = true;
        }else
        {
            _isSprinting = false;
        }
    }

    private void MoveCamera()
    {
        yaw += _rotation.x * _speedH;
        pitch -= _rotation.y * _speedV;

        _mainCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0);
        CamDirection();
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

    public void DesactivarMap()
    {
        _playersControl.Disable();
    }
    public void ActivarMap()
    {
        _playersControl.Enable();
    }
}
