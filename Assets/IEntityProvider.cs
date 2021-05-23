using UnityEngine;

public interface IEntityProvider
{
    Vector2 MovementDirection { get; }
    Vector2 FacingDirection { get; }
}
