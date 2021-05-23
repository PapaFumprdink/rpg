using UnityEngine;
using UnityEngine.InputSystem;

[SelectionBase]
[DisallowMultipleComponent]
public class PlayerController : MonoBehaviour, IEntityProvider
{
    [SerializeField] private bool m_UseGamepad;

    private Controls m_Controls;
    private Camera m_MainCamera;

    public Vector2 MovementDirection => m_Controls.General.Movement.ReadValue<Vector2>();
    public Vector2 FacingDirection
    {
        get
        {
            if (m_UseGamepad)
            {
                return m_Controls.General.FaceDirection.ReadValue<Vector2>();
            }
            else
            {
                Vector2 mousePosition = m_MainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                return mousePosition - (Vector2)transform.position;
            }
        }
    }

    private void Awake()
    {
        m_MainCamera = Camera.main;
        m_Controls = new Controls();
    }

    private void OnEnable()
    {
        m_Controls.Enable();
    }

    private void OnDisable()
    {
        m_Controls.Disable();
    }
}
