using UnityEditor;
using UnityEngine;
//这个脚本必须放在Editor文件夹下

[CustomEditor(typeof(MyCustomScript))]
public class MyCustomScriptEditor : Editor
{
    // 声明一个引用，指向我们要编辑的对象
    private MyCustomScript myCustomScript;

    private void OnEnable()
    {
        // 在编辑器加载时，获取目标对象的引用
        myCustomScript = (MyCustomScript)target;
    }

    public override void OnInspectorGUI()
    {
        // 画出自定义的标题
        GUILayout.Label("Custom Inspector for MyCustomScript", EditorStyles.boldLabel);

        // 画出一个文本字段，显示并编辑 playerName
        myCustomScript.playerName = EditorGUILayout.TextField("Player Name", myCustomScript.playerName);

        // 画出一个整数字段，显示并编辑 playerScore
        myCustomScript.playerScore = EditorGUILayout.IntField("Player Score", myCustomScript.playerScore);

        // 画出一个切换框，显示并编辑 isPlayerActive
        myCustomScript.isPlayerActive = EditorGUILayout.Toggle("Is Player Active", myCustomScript.isPlayerActive);

        // 添加一个按钮，点击后输出日志
        if (GUILayout.Button("Reset Score"))
        {
            myCustomScript.playerScore = 0;
            Debug.Log("Player score reset!");
        }

        // 让Editor重新绘制，并保存数据
        EditorUtility.SetDirty(myCustomScript);
    }
}
