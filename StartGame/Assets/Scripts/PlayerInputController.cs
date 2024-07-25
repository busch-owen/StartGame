using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInput _input;
    private MapRoller _mapRoller;

    private void OnEnable()
    {
        _mapRoller = GetComponent<MapRoller>();
        
        if (_input != null) return;

        _input = new PlayerInput();

        _input.BoardInput.MouseMovement.performed += i => _mapRoller.GetInput(i.ReadValue<Vector2>());
        
        EnableInput();
    }

    public void DisableInput()
    {
        _input.Disable();
    }

    public void EnableInput()
    {
        _input.Enable();
    }
    
    private void OnDestroy()
    {
        DisableInput();
    }
}
