using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIEventSysKey : MonoBehaviour, IScrollHandler, ISubmitHandler, ICancelHandler, IMoveHandler
{
    public void OnScroll(PointerEventData eventData)
    {
        Debug.Log("滑动了鼠标滚轮");
    }

    public void OnSubmit(BaseEventData eventData)
    {
        Debug.Log("按下了Enter/空格键");
    }

    public void OnCancel(BaseEventData eventData)
    {
        Debug.Log("按下了ECS键");
    }

    public void OnMove(AxisEventData eventData)
    {
        Debug.Log("按下了方向键（WSAD、上下左右键）");
    }
}
