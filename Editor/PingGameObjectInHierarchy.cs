#if UNITY_EDITOR
using UnityEditor;

/// <summary>
/// Класс используется для выделения объекта на сцене с помощью горячей клавиши
/// </summary>
public class PingGameObjectInHierarchy
{
    [MenuItem("Tools/Ping GameObject in Hierarchy")]
    static void Ping()
    {
        if(!Selection.activeObject)
            return;

        EditorGUIUtility.PingObject(Selection.activeObject);
    }
}
#endif