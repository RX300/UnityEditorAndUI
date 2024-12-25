using UnityEditor;
using UnityEngine;
using UnityEditorInternal;

public class DefaultInputExample : EditorWindow
{
    private string inputValue = "Default Value";  // 初始值
    private const string userSettingKey = "UserInputValue";  // 用于存储的键

    [MenuItem("Window/Editor Develop Test/Default Input Example")]
    public static void ShowWindow()
    {
        GetWindow<DefaultInputExample>("Default Input Example");
    }

    private void OnEnable()
    {
        // 在启用时恢复之前保存的值
        if (string.IsNullOrEmpty(EditorUserSettings.GetConfigValue(userSettingKey)))
        {
            inputValue = EditorUserSettings.GetConfigValue(userSettingKey);
        }
        else
        {
            inputValue = "Default Value";  // 如果没有保存的值，则使用默认值
        }
    }

    private void OnGUI()
    {
        // 显示输入框
        inputValue = EditorGUILayout.TextField("Enter text:", inputValue);

        // 显示按钮，点击时保存输入框内容
        if (GUILayout.Button("Save Value"))
        {
            // 保存输入的值
            EditorUserSettings.SetConfigValue(userSettingKey, inputValue);
            Debug.Log("Saved value: " + inputValue);
        }

        GUILayout.Label("Current value: " + inputValue);
    }
}
