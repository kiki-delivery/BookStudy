using UnityEngine;

public class Hunt : MonoBehaviour
{
    bool _Ishunt;

    void OnDisable()
    {
        _Ishunt = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // ��ǥ�ϰ� �ε����� ��
        //if()
        //{
        //    return;
        //}

        if(_Ishunt)
        {
            return;
        }

        _Ishunt = true;
    }
}
