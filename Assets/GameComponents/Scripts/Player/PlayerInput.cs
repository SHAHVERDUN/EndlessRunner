using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _movement;

    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        ReadOfController();
    }

    private void ReadOfController()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _movement.MoveUp();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _movement.MoveDown();
        }
    }
}