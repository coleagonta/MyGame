using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    private PlayerInputActions _playerInputActions;
    private void Awake()
    {
        _playerInputActions  = new PlayerInputActions();
        _playerInputActions.Player.Enable();
    }

    public Vector2 GetMovmentVectorNormalized()
    {
        Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        
        Debug.LogError(inputVector);

        return inputVector;
    }
}