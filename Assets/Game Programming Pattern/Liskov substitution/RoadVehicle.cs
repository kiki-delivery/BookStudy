
using UnityEngine;

public class RoadVehicle : MonoBehaviour, ITurnable, IMovable
{
    public virtual void GoForward()
    {
        Debug.Log("나는 부모가 호출");
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
