using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 7f; // скорость поворота
    [SerializeField] private float jumpHeight = 5f; 
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private Animator animator;

    private bool isWalking;
    private bool isGrounded;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
        if (animator == null) 
        {
            animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        Vector2 inputVector = _gameInput.GetMovmentVectorNormalized();
        Vector3 moveDir = new Vector3(-inputVector.y, 0f, inputVector.x);

        transform.position += moveDir * moveSpeed * Time.deltaTime;
        
        isWalking = moveDir.magnitude > 0.1f; 

        if (animator != null)
        {
            animator.SetBool("walk", isWalking);
        }

        if (isWalking)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
        }

        if (_gameInput.IsJumpPressed() && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        isGrounded = false;
        
        if (animator != null)
        {
            animator.SetBool("jump", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; 
            
            if (animator != null)
            {
                animator.SetBool("jump", false); // Выключаем анимацию прыжка при приземлении
            }
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
