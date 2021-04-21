using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //do
        //{
        //    //if(MIS.InputManager.inst)
        //}
        //yield return new WaitForEndOfFrame();
        MIS.InputManager.Instance.OnClick.AddListener(new UnityEngine.Events.UnityAction<Vector3>(OnClick));
        MIS.InputManager.Instance.OnDrag.AddListener(OnDrag);
        MIS.InputManager.Instance.OnZoom.AddListener(OnZoom);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(Vector3 point)
    {
        Debug.Log($"On Click position : {point}");
    }

    public void OnDrag(Vector3 dragPoint)
    {
        Debug.Log($"On Drag vector");
        //Debug.Log($"On Drag vector : {dragPoint}");
    }

    public void OnZoom(float delta)
    {
        Debug.Log($"On Scroll vector : {delta}");
    }

    private void OnDestroy()
    {
        MIS.InputManager.Instance.OnClick.RemoveListener(OnClick);
        MIS.InputManager.Instance.OnDrag.RemoveListener(OnDrag);
        MIS.InputManager.Instance.OnZoom.RemoveListener(OnZoom);
    }
}
