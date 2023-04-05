using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocManager : MonoBehaviour
{
    [SerializeField] GameObject _toolTipPrefab;
    private List<ToolTip> _toolTipPool = new List<ToolTip>();
    private Dictionary<Transform, ToolTip> _active = new Dictionary<Transform, ToolTip>();
    [SerializeField] Material _tipMat;
    [SerializeField] Transform _computer;
    public static DocManager Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        Instance = this;
    }

    public void ShowToolTip(string name, Transform pivot)
    {
        ToolTip t = null;
        if (_toolTipPool.Count > 0)
        {
            t = _toolTipPool[0];
            _toolTipPool.RemoveAt(0);

        }
        else
        {
            GameObject g = Instantiate(_toolTipPrefab);
            t = g.GetComponent<ToolTip>();

        }
        SupportDocs.DocPair pair = MainManager.Instance.GetDoc(name);
        _active.Add(pivot, t);
        t.SetUp(pair, pivot);
    }

    public void HideToolTip(Transform pivot)
    {
        if (_active.ContainsKey(pivot))
        {
            ToolTip t = _active[pivot];
            t.Hide();
            _toolTipPool.Add(t);
            _active.Remove(pivot);
            
        }
        

    }

    public GameObject PlaceHelper(GameObject g, UnityEngine.XR.Interaction.Toolkit.InteractionLayerMask mask)
    {
        Transform pivotPos = SocketManager.Instance.GetSocket(mask);
        GameObject t = Instantiate(g);
        UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable gr;
        if (t.TryGetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>(out gr))
        {
            Destroy(gr);
        }
        Element e;
        if(t.TryGetComponent<Element>(out e))
        {
            Destroy(e);
        }
        Rigidbody rb;
        if (t.TryGetComponent<Rigidbody>(out rb))
        {
            Destroy(rb);
        }

        t.transform.parent = _computer;
        t.transform.position = pivotPos.position;
        t.transform.rotation = pivotPos.rotation;
        //t.transform.localScale = g.transform.localScale;
        t.layer = 3;
        Renderer[] rs = t.GetComponentsInChildren<Renderer>();
        for(int i =0; i < rs.Length; i++)
        {
            rs[i].material = _tipMat;
        }
        return t;
    }

}
