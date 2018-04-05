using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorPath : MonoBehaviour {

    public Color rayColor = Color.white;
    public List<Transform> nodes = new List<Transform>();
    Transform[] childTransforms;

    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        childTransforms = GetComponentsInChildren<Transform>();
        nodes.Clear();

        foreach (Transform path_obj in childTransforms)
        {
            if (path_obj != this.transform)
            {
                nodes.Add(path_obj);
            }
        }
        for (int i = 0; i < nodes.Count; i++)
        {
            nodes[i].name = "Node" + i;
            Vector3 pos = nodes[i].position;
            if (i > 0)
            {
                Vector3 previous = nodes[i - 1].position;
                Gizmos.DrawLine(previous, pos);
                Gizmos.DrawWireSphere(pos, 1);
            }
        }
    }
}
