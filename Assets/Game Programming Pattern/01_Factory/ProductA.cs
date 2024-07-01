using UnityEngine;

public class ProductA : MonoBehaviour, IProduct
{
    [SerializeField] string _productName ="A";

    public string ProductName
    {
        get => _productName;
        set => _productName = value;    
    }

    public void Initalize()
    {
        gameObject.name = _productName;
    }

    
}
