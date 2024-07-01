using UnityEngine;

public class Door : ISwitchable
{
    bool _isActivate;

    public bool IsActivate => _isActivate;

    public void Activate()
    {
        _isActivate = true;
        Debug.Log("¿­·È´Ù!");
    }

    public void Deactivate()
    {
        _isActivate = false;
        Debug.Log("´ÝÇû´Ù! ");
    }
}
