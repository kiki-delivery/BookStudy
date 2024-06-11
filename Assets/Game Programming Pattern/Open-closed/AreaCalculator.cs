using UnityEngine;

public class AreaCalculator : MonoBehaviour
{
    public float GetArea(Shape shape)
    {
        return shape.CalculateArea();
    }
}
