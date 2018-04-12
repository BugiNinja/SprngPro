using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorPath : MonoBehaviour {

    public Color RayColor = Color.white;
    public List<Transform> Nodes = new List<Transform>();
    private Transform[] childTransforms;

    private void OnDrawGizmos()
    {
        if (childTransforms.Length - 1 != transform.childCount || IsPathObjectSelected())
        {
            Gizmos.color = RayColor;
            childTransforms = GetComponentsInChildren<Transform>();
            Nodes.Clear();
            foreach (Transform path_obj in childTransforms)
            {
                if (path_obj != this.transform)
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
    }
    private bool IsPathObjectSelected()
    {
        if (UnityEditor.Selection.activeTransform != null)
        {
            Transform editorSelection = UnityEditor.Selection.activeTransform;
            if (editorSelection.Equals(this.transform))
            {
                return true;
            }
            if (editorSelection.parent != null)
            {
                if (editorSelection.parent.Equals(this.transform))
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
        return false;
    }
}
