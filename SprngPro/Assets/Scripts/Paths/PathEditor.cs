using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEditor : MonoBehaviour {

    public Color RayColor = Color.white;
    public List<Transform> Nodes = new List<Transform>();
    private Transform[] childTransforms;
    public Transform path;

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        path = FindObjectOfType<NodePath>().transform;
        childTransforms = path.GetComponentsInChildren<Transform>();
        if (childTransforms.Length - 1 != path.childCount || IsPathObjectSelected())
        {
            Gizmos.color = RayColor;

            Nodes.Clear();
            foreach (Transform path_obj in childTransforms)
            {
                if (path_obj != path)
                {
                    Nodes.Add(path_obj);
                }
            }

            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].name = "Node" + i;
                Vector3 pos = Nodes[i].position;
                if (i > 0)
                {
                    Vector3 previous = Nodes[i - 1].position;
                    Gizmos.DrawLine(previous, pos);
                    Gizmos.DrawWireSphere(pos, 1);
                }
            }
        }
#endif
    }
    private bool IsPathObjectSelected()
    {
#if UNITY_EDITOR
        if (UnityEditor.Selection.activeTransform != null)
        {
            Transform editorSelection = UnityEditor.Selection.activeTransform;
            if (editorSelection.Equals(path))
            {
                return true;
            }
            if (editorSelection.parent != null)
            {
                if (editorSelection.parent.Equals(path))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
#endif
        return false;

    }

}
