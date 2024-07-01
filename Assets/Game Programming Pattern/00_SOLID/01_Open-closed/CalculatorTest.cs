using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorTest : MonoBehaviour
{
    [SerializeField] Shape _shape;
    [SerializeField] Rectangle _rectangle;

    AreaCalculator _areaCalculator;

    void Awake()
    {
        _areaCalculator = GetComponent<AreaCalculator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(_areaCalculator.GetArea(_shape));
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log(_areaCalculator.GetArea(_rectangle));
        }

    }
}
