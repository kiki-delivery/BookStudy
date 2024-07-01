using UnityEngine;

public class Navigator : MonoBehaviour
{
    [SerializeField] RoadVehicle _test;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Move(_test);
        }
    }

    public void Move(RoadVehicle vehicle)
    {
        vehicle.GoForward();
        vehicle.TurnLeft();
        vehicle.GoForward();
        vehicle.TurnRight();
        vehicle.Reverse();
    }
}
