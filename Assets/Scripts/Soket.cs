using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Soket : MonoBehaviour
{
    private XRSocketInteractor _si;
    private void Awake()
    {
        _si = GetComponentInChildren<XRSocketInteractor>();
        SocketManager.Instance.AddSocket(_si);
    }

    

    
}
