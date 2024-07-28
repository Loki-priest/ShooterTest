using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolOnDisable : MonoBehaviour
{


    public Transform container;

    private void OnDisable()
    {
        Invoke("Reparent",0.0f);
    }

    void Reparent()
    {
        transform.SetParent(container);
    }

    private void OnEnable()
    {
        transform.SetParent(null);
    }


}
