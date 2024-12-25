using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class DynamicInputExample : EditorWindow
{
    private List<int> inputValues = new List<int>();  // 存储所有输入框的整数值
    private List<int> itemsToRemove = new List<int>();  // 延迟删除的输入框索引
    private const int defaultInputValue = 1;  // 默认输入值

    [MenuItem("Window/Editor Develop Test/Dynamic Input Example")]
    public static void ShowWindow()
    {
        GetWindow<DynamicInputExample>("Dynamic Input Example");
    }

    private void OnEnable()
    {
        // 初始时，添加一个默认的输入框
        if (inputValues.Count == 0)
        {
            inputValues.Add(defaultInputValue);
        }
    }

    private void OnGUI()
    {
        // 显示所有输入框及其删除按钮
        for (int i = 0; i < inputValues.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            // 显示整数输入框
            inputValues[i] = EditorGUILayout.IntField($"输入框 {i + 1}:", inputValues[i]);

            // 显示删除按钮
            if (GUILayout.Button("删除", GUILayout.Width(60)))
            {
                // 标记该输入框为待删除
                itemsToRemove.Add(i);
            }

            EditorGUILayout.EndHorizontal();
        }

        // 延迟删除输入框
        foreach (var index in itemsToRemove)
        {
            if (index >= 0 && index < inputValues.Count)
            {
                inputValues.RemoveAt(index);
            }
        }

        // 清空删除标记
        itemsToRemove.Clear();

        // 显示增加输入框按钮
        if (GUILayout.Button("增加输入"))
        {
            // 当点击按钮时，添加新的输入框，默认值为 "1"
            inputValues.Add(defaultInputValue);
        }

        // 显示保存按钮
        if (GUILayout.Button("保存"))
        {
            // 在点击保存时，检查所有输入框的值是否在0到9之间
            if (ValidateInputValues(inputValues))
            {
                // 如果所有输入值都有效，打印确认消息
                Debug.Log("保存成功！");
            }
            else
            {
                // 如果有无效输入，显示错误消息
                EditorUtility.DisplayDialog("错误", "所有输入值必须在0到9之间！", "确定");
            }
        }

        // 显示所有输入框的值
        GUILayout.Label("当前输入的值:");
        foreach (var value in inputValues)
        {
            GUILayout.Label(value.ToString());
        }
    }

    // 检测输入框中的所有整数值是否在0到9之间
    private bool ValidateInputValues(List<int> values)
    {
        foreach (var value in values)
        {
            if (value < 1 || value > 9)
            {
                return false; // 如果有任何一个值不在范围内，返回 false
            }
        }
        return true; // 所有值都在有效范围内，返回 true
    }
}
