using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Docs/DocPairs", fileName ="DocPairs")]
public class SupportDocs : ScriptableObject
{
    [System.Serializable]
    public class DocPair
    {
        public string Name;
        public Sprite ImgDoc;
        public string TextDoc;
    }

    [SerializeField] List<DocPair> _docPairs;

    public DocPair GetDocPair(string name)
    {
        return _docPairs.Find((x) => x.Name == name);
    }
}
