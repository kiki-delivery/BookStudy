using UnityEngine;

public struct Poketmon
{
    public Poketmon(string name, int power)
    {
        Name = name;
        Power = power;
    }    

    public string Name
    {
        get;
    }
    public int Power
    {
        get;
    }
}

public class StructTest : MonoBehaviour
{
    void Awake()
    {
        Poketmon poketmon = new Poketmon("Pikachu", 100);
        int value = poketmon.Power;
        
    }
}
