using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIEventDrag : MonoBehaviour, IDragHandler, IInitializePotentialDragHandler, IBeginDragHandler, IEndDragHandler
{
    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        Debug.Log("初始化可能的拖动事件");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("开始拖动");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("正在拖动");
        RectTransform rec = GetComponent<RectTransform>();
        Vector3 UIpos;
        //rec 是UI的RectTransform组件（UI移动全靠它为基础），eventData.position 鼠标移动的位置（屏幕坐标），eventData.enterEventCamera 哪个照相机照射的
        // out pos 输出UI游戏物体对象 转换后的世界坐标
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rec, eventData.position, eventData.pressEventCamera, out UIpos);
        rec.position = UIpos;
        TextMeshProUGUI textUI = GetComponent<TextMeshProUGUI>();
        if (textUI == null)
        {
            Debug.LogError("TextMeshPro组件未找到！");
            return;
        }
        textUI.text = $"UIpos: {UIpos}";
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("结束拖动");
    }
}
