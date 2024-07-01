using UnityEngine;

public class Circle : Shape
{
    float radius = 3;

    public override float CalculateArea()
    {
        return radius * radius * Mathf.PI;
    }    
}
