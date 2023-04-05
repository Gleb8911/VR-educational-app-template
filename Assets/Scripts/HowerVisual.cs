using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HowerVisual : MonoBehaviour
{
    [SerializeField] XRDirectInteractor _interator;
    private static readonly int _emissionColorHash = Shader.PropertyToID("_EmissionColor");
    GameObject prev;
    private void Start()
    {
        _interator.hoverEntered.AddListener((x) => OnHoverEnter(x));
        _interator.hoverExited.AddListener((x) => OnHoverExit(x));
    }

    private void OnDestroy()
    {
        _interator.hoverEntered.RemoveListener((x) => OnHoverEnter(x));
        _interator.hoverExited.RemoveListener((x) => OnHoverExit(x));

    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        
        Color c = new Color(0, 0, 0.5f);
        GameObject g = args.interactableObject.transform.gameObject;
        if(prev != null)
        {
            OnHoverExit(g);
        }
        prev = g;
        Renderer[] rs = g.GetComponentsInChildren<Renderer>();
        foreach(Renderer r in rs)
        {
            r.material.SetColor(_emissionColorHash, c);
        }
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        Color c = new Color(0, 0, 0);
        GameObject g = args.interactableObject.transform.gameObject;
        Renderer[] rs = g.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            r.material.SetColor(_emissionColorHash, c);
        }
        prev = null;
    }
    private void OnHoverExit(GameObject g)
    {
        Color c = new Color(0, 0, 0);
        
        Renderer[] rs = g.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            r.material.SetColor(_emissionColorHash, c);
        }
        prev = null;
    }
}
