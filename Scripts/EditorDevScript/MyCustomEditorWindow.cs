using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyCustomEditorWindow : EditorWindow
{
   // 声明变量来存储用户输入的内容
    private string inputText = "";
    private bool toggle = false;
    private float sliderValue = 0.5f;

    // 为窗口添加菜单项
    [MenuItem("Window/Editor Develop Test/My Custom Editor Window")]
    public static void ShowWindow()
    {
        // 打开自定义的编辑器窗口
        GetWindow<MyCustomEditorWindow>("My Custom Editor Window");
    }

    // 窗口的UI布局
    private void OnGUI()
    {
        // 设置窗口的标题和样式
        GUILayout.Label("This is a custom editor window!", EditorStyles.boldLabel);
        EditorGUILayout.BeginVertical();
        // 文本框输入
        inputText = EditorGUILayout.TextField("Enter text:", inputText);

        // 切换框
        toggle = EditorGUILayout.Toggle("Enable feature:", toggle);

        // 滑动条
        sliderValue = EditorGUILayout.Slider("Value:", sliderValue, 0, 1);

        // 创建一个按钮，点击时执行操作
        if (GUILayout.Button("Click Me"))
        {
            Debug.Log("Button clicked!");
            Debug.Log($"Input Text: {inputText}");
            Debug.Log($"Toggle Value: {toggle}");
            Debug.Log($"Slider Value: {sliderValue}");
        }
        EditorGUILayout.EndVertical();
    }
}
