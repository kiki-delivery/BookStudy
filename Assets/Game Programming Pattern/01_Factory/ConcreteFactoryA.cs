using UnityEngine;

public class ConcreteFactoryA : Factory
{
    [SerializeField] ProductA _productPrefab;

    public override IProduct GetProduct(Vector3 position)
    {
        GameObject instance = Instantiate(_productPrefab.gameObject, position, Quaternion.identity);
        ProductA newProduct = instance.GetComponent<ProductA>();

        newProduct.Initalize();

        return newProduct;

    }
}
