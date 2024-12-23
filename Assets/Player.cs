using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    // [SerializeField] private float rotateSpeed = 7f; 
    [SerializeField] private float jumpHeight = 5f; 
    [SerializeField] private GameInput _gameInput;

    private bool isWalking;
    private bool isGrounded;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 inputVector = _gameInput.GetMovmentVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.y, 0f, -inputVector.x);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;
        // transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        
        if (_gameInput.IsJumpPressed() && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; 
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}