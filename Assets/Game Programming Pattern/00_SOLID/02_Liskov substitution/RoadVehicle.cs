
using UnityEngine;

public class RoadVehicle : MonoBehaviour, ITurnable, IMovable
{
    public virtual void GoForward()
    {
        Debug.Log("���� �θ� ȣ��");
    }

    public virtual void Reverse()
    {
        
    }

    public virtual void TurnLeft()
    {
        
    }

    public virtual void TurnRight()
    {
        
    }
}
