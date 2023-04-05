using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Element : MonoBehaviour
{
    [SerializeField] string _name;
    private XRGrabInteractable _grab;
    private GameObject _helper;
    // Start is called before the first frame update
    void Start()
    {
        _grab = GetComponent<XRGrabInteractable>();
        _grab.hoverEntered.AddListener((x) => OnHoverEnter(x));
        _grab.hoverExited.AddListener((x) => OnHoverExit(x));
        _grab.selectEntered.AddListener((x) => OnSelect(x));
        _grab.selectExited.AddListener((x) => OnSelectExit(x));
        
       
    }

    private void OnDestroy()
    {
        if (_grab)
        {
            _grab.hoverEntered.RemoveListener((x) => OnHoverEnter(x));
            _grab.hoverExited.RemoveListener((x) => OnHoverExit(x));
            _grab.selectEntered.RemoveListener((x) => OnSelect(x));
            _grab.selectExited.RemoveListener((x) => OnSelectExit(x));
        }
        
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        if(args.interactorObject is XRDirectInteractor)
        {
            ShowDoc();
        }
        
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            HideDoc();
        }
        
    }

  

    private void OnSelect(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            StartCoroutine(Waithelp());
        }
        
    }

    IEnumerator Waithelp()
    {
        yield return null;

        if (_helper)
        {
            Destroy(_helper);
        }
        _helper = DocManager.Instance.PlaceHelper(gameObject, _grab.interactionLayers);

    }

    private void OnSelectExit(SelectExitEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            if (_helper)
                Destroy(_helper);
        }
        
    }

    private void ShowDoc()
    {
        DocManager.Instance.ShowToolTip(_name, transform);
        
    }

    private void HideDoc()
    {
        DocManager.Instance.HideToolTip(transform);
    }



    
}
