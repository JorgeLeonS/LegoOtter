using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flat3x1 : MonoBehaviour
{
    public GameObject prefab;
    Otter.BasicLego[] bl = new Otter.BasicLego[3];
    Vector3[] brickVertices1;
    Vector3[] brickVertices2;
    Vector3[] brickVertices3;

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
        bl[0] = Instantiate(prefab).GetComponentInChildren<Otter.BasicLego>();
        bl[1] = Instantiate(prefab).GetComponentInChildren<Otter.BasicLego>();
        bl[2] = Instantiate(prefab).GetComponentInChildren<Otter.BasicLego>();

        TransformMesh(bl[1].getMesh(), Otter.MatrixOperations.opTranslate(-2,0,0));
        TransformMesh(bl[2].getMesh(), Otter.MatrixOperations.opTranslate(-4,0,0));

        Mesh m = bl[0].getMesh();
        brickVertices1 = m.vertices;

        m = bl[1].getMesh();
        brickVertices2 = m.vertices;

        m = bl[2].getMesh();
        brickVertices3 = m.vertices;
    }

    public void ToOrigin(){
        Mesh m = bl[0].getMesh();
        m.vertices = brickVertices1;
        m.RecalculateNormals();

        m = bl[1].getMesh();
        m.vertices = brickVertices2;
        m.RecalculateNormals();

        m = bl[2].getMesh();
        m.vertices = brickVertices3;
        m.RecalculateNormals();
    }

    public void UpdateMeshes(Matrix4x4 t)
    {
        for (int i = 0; i < bl.Length; i++)
        {
            TransformMesh(bl[i].getMesh(), t);
        }
    }

    public void ChangeEnable(bool status)
    {
       for (int i = 0; i < bl.Length; i++)
        {
            bl[i].gameObject.SetActive(status);
        }
    }

}
