using UnityEngine;

[SelectionBase]
[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class EntityMovement : MonoBehaviour
{
    [SerializeField] private float m_MovementSpeed;
    [SerializeField] private float m_AccelerationTime;

    private IEntityProvider m_Controller;
    private Rigidbody2D m_Rigidbody;

    private void Awake()
    {
        m_Controller = GetComponent<IEntityProvider>();

        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        Vector2 currentVelocity = m_Rigidbody.velocity;
        Vector2 targetVelocity = m_Controller.MovementDirection * m_MovementSpeed;
        Vector2 acceleration = Vector2.ClampMagnitude(targetVelocity - currentVelocity, m_MovementSpeed) / m_AccelerationTime;
        m_Rigidbody.velocity += acceleration * Time.deltaTime;
    }
}
