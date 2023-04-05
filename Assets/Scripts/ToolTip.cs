using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI _desc;
    [SerializeField] UnityEngine.UI.Image _img;
    [SerializeField] TMPro.TextMeshProUGUI _name;
    [SerializeField] Vector3 _offset = new Vector3(0, 0.4f, 0);
    public void SetUp(SupportDocs.DocPair pair, Transform pivot)
    {
        gameObject.SetActive(true);
        _desc.text = pair.TextDoc;
        _img.sprite = pair.ImgDoc;
        _name.text = pair.Name;
        StartCoroutine(TransformSetUp(pivot));
    }

    public void Hide()
    {
        
        StopAllCoroutines();
        gameObject.SetActive(false);
    }

    IEnumerator TransformSetUp(Transform pivot)
    {
        Transform t = transform;
        Transform cam = Camera.main.transform;
        while (true)
        {
            t.position = pivot.position + _offset;
            t.LookAt(cam.position);
            yield return null;
        }
    }

}
