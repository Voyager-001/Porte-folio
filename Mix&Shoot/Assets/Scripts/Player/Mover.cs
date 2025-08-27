using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float dashSpeed = 2;
    [SerializeField] private float dashTime = 0.2f;
    [SerializeField] private float gravity = 1f;
    [SerializeField] private float verticalVelocity;
    
    [SerializeField] private int playerIndex;

    [SerializeField] private Speed playerSpeed;
    
    private CharacterController _controller;
    
    private Vector3 _moveDirection = Vector3.zero;
    private Vector3 _lookDirection = Vector3.zero;
    
    private Vector2 _inputVector = Vector2.zero;
    private Vector2 _inputRotation = Vector2.zero;
    
    private bool _isDashing;
    
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        playerSpeed = GetComponent<Speed>();
    }

    private void Start()
    {
        _controller.enabled = false;
        transform.position = PlayerManager.Instance.SpawnPoint.position;
        _controller.enabled = true;
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }
    
    public void SetInputVector(Vector2 direction)
    {
        _inputVector = direction;
    }
    
    public void SetInputRotation(Vector2 direction)
    {
        _inputRotation = direction;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isDashing)
        {
            _moveDirection = new Vector3(_inputVector.x, 0, _inputVector.y);
        }

        if (_controller.isGrounded)
            verticalVelocity = 0;
        else
            verticalVelocity -= gravity * Time.deltaTime;
        
        _moveDirection.y = verticalVelocity;

        _controller.Move(_moveDirection * (moveSpeed * Time.deltaTime * playerSpeed.CurrentSpeed));

        if (_inputRotation.sqrMagnitude > 0.0f)
        {
            _lookDirection = new Vector3(_inputRotation.x, 0, _inputRotation.y);
            Quaternion rotationQuaternion = Quaternion.LookRotation(_lookDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationQuaternion, Time.deltaTime * 10f);
        }
    }
    
    public void Dash()
    {
        if (!_isDashing)
        {
            StartCoroutine(DashDelayed());
        }
    }
    
    private IEnumerator DashDelayed()
    {
        _isDashing = true;

        float elapsedTime = 0f;
        
        while(elapsedTime < dashTime)
        {
            _controller.Move(new Vector3(_moveDirection.x, 0, _moveDirection.z) * (dashSpeed * Time.deltaTime * playerSpeed.CurrentSpeed));
            
            elapsedTime += Time.deltaTime;
            
            yield return null;
        }
        
        _isDashing = false;
    }
}