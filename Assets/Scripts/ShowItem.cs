using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShowItem : MonoBehaviour
{
    
    public GameObject Mask;
    [SerializeField]
    GameObject furfur;

    public void onUpdateMask(Vector3 pos)
    {
        Mask.transform.position = pos;
    }
    public void onShow()
    {
        onShow(true);
        Invoke("onHide", 2);
    }
    public void onShow(bool state=true)
    {
        furfur.SetActive(state);
        
    }
    private void onHide()
    {
        furfur.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
