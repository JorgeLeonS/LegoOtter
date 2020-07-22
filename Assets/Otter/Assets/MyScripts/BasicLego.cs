/*
 * TC3022. Computer Graphics 
 * Sergio Ruiz-Loza, Ph.D.
 * 
 * Basic script for a cube.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Otter{
public class BasicLego : MonoBehaviour
{
    private Mesh cubeMesh;      // Unity's mesh: vertices and triangles.
    private Vector3[] points;   // Our own vertices.
    private int[] indices;      // Our own triangles.
    private MeshFilter mf;

    // Start is called before the first frame update
    void Start()
    {

        mf = gameObject.GetComponentInChildren<MeshFilter>();
        cubeMesh = mf.mesh;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Mesh getMesh()
    {
        mf = gameObject.GetComponentInChildren<MeshFilter>();
        return mf.mesh;
    }

    public Vector3[] getPoints()
    {
        return points;
    }

    public int[] getIndices()
    {
        return indices;
    }

    public void setPoints(Vector3[] ps)
    {
        if (ps.Length == points.Length)
        {
            mf.mesh.vertices = ps; // Change the points to 'ps'.
            mf.mesh.RecalculateNormals();
        }
    }

    public void resetPoints()
    {
        mf.mesh.vertices = points; // Back to the original points.
        mf.mesh.RecalculateNormals();
    }
}
}