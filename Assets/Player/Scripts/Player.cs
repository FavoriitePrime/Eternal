using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour
{
    [Header("PlayerState")]
    [ReadOnly][SerializeField] private bool isRunning;
    [ReadOnly][SerializeField] private bool isGrounded;
    [ReadOnly][SerializeField] private bool isWallRunning;

    [Header("Movement")]
    [SerializeField] private Transform _orientation;
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;

    [Header("WallRun")]
    [SerializeField] private float _wallRunSpeed;
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _whatIsWall;
    private RaycastHit leftWall;
    private RaycastHit rightWall;
    private bool onRightWall;
    private bool onLeftWall;
    private Vector3 _wallNormal;

    [Header("Gravity")]
    [SerializeField] private float _gravityForce;
    [SerializeField] private float _gravityMultiplyer;
    [SerializeField] private float _wallRunGravityForce;
    [SerializeField] private float _wallRunGravityMultiplyer;

    private PlayerInputs _inputs;
    private PlayerMovementController _movement;
    private CharacterController _characterController;

    [Header("Rotation")]
    [SerializeField] private Vector2 _mouseClamp;
    [SerializeField] private float _sensivity;
    private PlayerCameraController _camera;

    [Header("Weapon")]
    [SerializeField] private GameObject _weaponHolder;
    private IWeapon _weapon;


    private void Awake()
    {
        _weapon = _weaponHolder.GetComponentInChildren<IWeapon>();
        _characterController = GetComponent<CharacterController>();
        _inputs = new PlayerInputs();
        _movement = new PlayerMovementController(ref _characterController, ref _orientation);
        _camera = new PlayerCameraController(ref _orientation, ref _cameraTarget);
        _inputs.GamePlay.Jump.started += context => _movement.Jump(ref _jumpForce, ref isWallRunning);
        _inputs.GamePlay.Shoot.performed += context => _weapon.Shoot();
    }
    private void FixedUpdate()
    {
        PlayerState();
        _camera.Rotate(_inputs.GamePlay.Mouse.ReadValue<Vector2>(), ref _sensivity, ref _mouseClamp);
        if (isWallRunning)
        {

            _movement.WallRun(_inputs.GamePlay.Move.ReadValue<Vector2>(), ref _runSpeed, ref _wallNormal);
            _movement.Gravity(ref _wallRunGravityForce, ref _wallRunGravityMultiplyer);
            return;
        }
        else if (isRunning)
        {
            _movement.Move(_inputs.GamePlay.Move.ReadValue<Vector2>(), ref _runSpeed);
        }
        else
        {
            _movement.Move(_inputs.GamePlay.Move.ReadValue<Vector2>(), ref _walkSpeed);
        }
        _movement.Gravity(ref _gravityForce, ref _gravityMultiplyer);
    }
    private void PlayerState()
    {
        onRightWall = Physics.Raycast(_orientation.position, _orientation.right, out rightWall, _distance, _whatIsWall);
        onLeftWall = Physics.Raycast(_orientation.position, -_orientation.right, out leftWall, _distance, _whatIsWall);
        _wallNormal = onRightWall ? rightWall.normal : leftWall.normal;
        if ((onLeftWall || onRightWall) & !isWallRunning){
            Debug.Log("wall run start");
            _movement.EnterWallRun();
            isWallRunning = true;
        }
        else if((!onLeftWall && !onRightWall) & isWallRunning)
        {
            isWallRunning = false;
        }
        Debug.Log((!onLeftWall && !onRightWall));
        isRunning = _inputs.GamePlay.Shift.IsPressed();
        isGrounded = _characterController.isGrounded;
    }

    private void OnEnable()
    {
        _inputs.Enable();
    }
    private void OnDisable()
    {
        _inputs.Disable();
    }
}
