using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public enum OBJECTS
{
    CUBE,
    SPHERE,
    CAPSULE,
}


public class TestEditorWindow : EditorWindow
{
    private bool isLeftControlDown;
    private const string testString = "선택할 오브젝트";

    private OBJECTS eObject = OBJECTS.CUBE;
    public OBJECTS EObject
    {
        get
        {
            return eObject;
        }
        set
        {
            eObject = value;
        }
    }

    [MenuItem("EditorTest/에디터 창 생성기")]
    static void ShowWindow()
    {
        GetWindow<TestEditorWindow>();
    }

    private void OnEnable()
    {
        SceneView.duringSceneGui += SceneViewDuringSceneGui;
    }
    private void OnDisable()
    {
        SceneView.duringSceneGui -= SceneViewDuringSceneGui;
    }

    private void SceneViewDuringSceneGui(SceneView obj)
    {
        PlaceOrDestroyObject();
    }

    

    private void OnGUI()
    {
        EObject = (OBJECTS)EditorGUILayout.EnumPopup(testString, EObject);
    }


    private void InstantiateObj(Prefabs prefabs, Transform parent, Vector3 pos)
    {
        GameObject gameObj;
        Vector3 targetPos;

        switch (EObject)
        {
            case OBJECTS.CUBE:
                targetPos = new Vector3(pos.x, pos.y + prefabs.cubePrefab.GetComponent<MeshRenderer>().localBounds.size.y / 2f, pos.z);
                gameObj = Instantiate(prefabs.cubePrefab, targetPos, Quaternion.identity);
                gameObj.transform.parent = parent;
                break;
            case OBJECTS.SPHERE:
                targetPos = new Vector3(pos.x, pos.y + prefabs.spherePrefab.GetComponent<MeshRenderer>().localBounds.size.y / 2f, pos.z);
                gameObj = Instantiate(prefabs.spherePrefab, targetPos, Quaternion.identity);
                gameObj.transform.parent = parent;
                break;
            case OBJECTS.CAPSULE:
                targetPos = new Vector3(pos.x, pos.y + prefabs.capsulePrefab.GetComponent<MeshRenderer>().localBounds.size.y / 2f, pos.z);
                gameObj = Instantiate(prefabs.capsulePrefab, targetPos, Quaternion.identity);
                gameObj.transform.parent = parent;
                break;
        }
    }

    private void PlaceOrDestroyObject()
    {
        Event currentEvent = Event.current;
        
        // Check Key LeftContorl
        if(currentEvent.type == EventType.KeyDown)
        {
            if(currentEvent.keyCode == KeyCode.LeftControl)
            {
                isLeftControlDown = true;
            }
        }
        else if(currentEvent.type == EventType.KeyUp)
        {
            if(currentEvent.keyCode == KeyCode.LeftControl)
            {
                isLeftControlDown = false;
            }
        }


        if (currentEvent.type == EventType.MouseDown)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.collider.tag == "Ground")
                {
                    var gameObjects = EditorSceneManager.GetActiveScene().GetRootGameObjects();
                    foreach (var find in gameObjects)
                    {
                        if (find.name == "Root")
                        {
                            Prefabs prefabs = find.GetComponent<Prefabs>();

                            Vector3 targetPos = new Vector3(hit.point.x, hit.collider.bounds.center.y, hit.point.z);

                            InstantiateObj(prefabs, find.transform, targetPos);
                        }
                    }
                }
                else if (hit.collider.tag == "Object" && isLeftControlDown)
                {
                    DestroyImmediate(hit.collider.gameObject);
                }
            }
        }
    }
}
