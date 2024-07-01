using UnityEngine;

public class Switch : MonoBehaviour
{
    public ISwitchable client;    

    public void Toggle()
    {
        if(client.IsActivate)
        {
            client.Deactivate();
        }
        else
        {
            client.Activate();
        }
    }
}
