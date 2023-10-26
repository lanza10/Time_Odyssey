using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class CharacterController : MonoBehaviour
{
    private Map _playersControl = null;

    private float _speed = 5f;
    private Vector3 _direction = Vector3.zero;
    private Rigidbody _rigibody = null;


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

        _playersControl = new Map();
        _playersControl.Exploracion.Movimiento.performed += ReadInput;
    }

    public void ReadInput(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        _direction.x = input.x;
        _direction.z = input.y;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
