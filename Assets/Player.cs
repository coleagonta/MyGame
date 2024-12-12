using System;
using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 7f;
   [SerializeField] private GameInput _gameInput;

   private bool isWalking;

   private void Update()
   {
       Vector2 inputVector = _gameInput.GetMovmentVectorNormalized();

       Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
       transform.position += moveDir * moveSpeed * Time.deltaTime;

       isWalking = moveDir != Vector3.zero;

       float rotateSpeed = 10f;
       transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
   }

   public bool IsWalking()
   {
       return isWalking;

   }

}
