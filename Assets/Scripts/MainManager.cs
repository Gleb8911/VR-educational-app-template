using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private static MainManager _Instance;
    public static MainManager Instance
    {
        get
        {
            return _Instance;
        }
        private set
        {
            _Instance = value;
        }
    }

    [SerializeField] SupportDocs _supportDocs;


    private void Awake()
    {
        Instance = this;
    }

    public SupportDocs.DocPair GetDoc(string name)
    {
        return _supportDocs.GetDocPair(name);
    }
}
