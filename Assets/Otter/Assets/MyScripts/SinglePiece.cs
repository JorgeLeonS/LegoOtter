using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePiece : MonoBehaviour
{

    public GameObject prefab;
    Otter.BasicLego bl;
    Vector3[] brickVertices;

    // public GameObject legoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TransformMesh(Mesh m, Matrix4x4 t)
    {
        Vector3[] points = m.vertices;
        int total = points.Length;
        for (int i = 0; i < total; i++)
        {
            Vector4 v = new Vector4(points[i].x,
                                    points[i].y,
                                    points[i].z, 1);
            v = t * v;
            points[i] = new Vector3(v.x, v.y, v.z);
        }
        m.vertices = points;
        m.RecalculateNormals();
    }

// Code based on the one provided by Alfredo Prado A01652169

    public void Create(){
        bl = Instantiate(prefab).GetComponentInChildren<Otter.BasicLego>();

        Mesh m = bl.getMesh();
        brickVertices = m.vertices;
    }

    public void ToOrigin(){
        Mesh m = bl.getMesh();
        m.vertices = brickVertices;
        m.RecalculateNormals();
    }

    public void UpdateMeshes(Matrix4x4 t)
    {
        TransformMesh(bl.getMesh(), t);
    }

    public void ChangeEnable(bool status)
    {
        bl.gameObject.SetActive(status);
    }

}
