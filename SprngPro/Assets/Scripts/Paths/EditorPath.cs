using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorPath : MonoBehaviour {

    public Color RayColor = Color.white;
    public List<Transform> Nodes = new List<Transform>();
    private Transform[] childTransforms;

    private void OnDrawGizmos()
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
