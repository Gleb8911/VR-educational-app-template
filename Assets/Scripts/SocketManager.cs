using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketManager
{
    private static SocketManager _Instance;
    public static SocketManager Instance
    {
        get
        {
            if(_Instance == null)
            {
                _Instance = new SocketManager();
            }
            return _Instance;
        }

        private set
        {
            _Instance = value;
        }
    }

    List<UnityEngine.XR.Interaction.Toolkit.XRSocketInteractor> _sockets = new List<UnityEngine.XR.Interaction.Toolkit.XRSocketInteractor>();

    public void AddSocket(UnityEngine.XR.Interaction.Toolkit.XRSocketInteractor socket)
    {
        _sockets.Add(socket);
    }

    public Transform GetSocket(UnityEngine.XR.Interaction.Toolkit.InteractionLayerMask mask)
    {
        return _sockets.Find((x) => x.interactionLayers == mask).transform;
    }
}
