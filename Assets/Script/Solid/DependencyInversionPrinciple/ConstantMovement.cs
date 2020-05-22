using UnityEngine;

public class ConstantMovement : MonoBehaviour, IMovementImputGetter
{
    public float Horizontal => 1;

    public float Vertical => 1.5f;

    
}
