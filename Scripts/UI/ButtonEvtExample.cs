using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvtExample : MonoBehaviour
{
    public void clickUITarget()
    {
        Debug.Log("点击了UI目标(Button)");
    }

    public void dragUITarget()
    {
        Debug.Log("将要对UITarget拖动");
        //获得鼠标当前位置
        Vector3 mousePos = Input.mousePosition;
        //将ui的位置设置为鼠标的位置
        RectTransform rec = GetComponent<RectTransform>();
        Vector3 UIpos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rec, mousePos, null, out UIpos);
        rec.position = UIpos;
    }
}
