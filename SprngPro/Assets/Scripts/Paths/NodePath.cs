using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePath : MonoBehaviour {
    public List<Transform> Nodes = new List<Transform>();
    private Transform[] childTransforms;

    private void Awake()
    {
        childTransforms = GetComponentsInChildren<Transform>();

        foreach (Transform path_obj in childTransforms)
        {
            if (path_obj != this.transform)
            {
                Nodes.Add(path_obj);
            }
        }

    }
    public void GetNodes(List<Transform> Nodes)
    {

    }
}
