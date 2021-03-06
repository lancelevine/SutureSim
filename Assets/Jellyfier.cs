using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfier : MonoBehaviour
{
    public float bounceSpeed;
    public float fallForce;
    public float stiffness;

    private MeshFilter meshFilter;
    private Mesh mesh;

    JellyVertex[] jellyVertices;
    Vector3[] currentMeshVertices;

    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;

        GetVertices();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVertices();
    }

    private void GetVertices()
    {
        jellyVertices = new JellyVertex[mesh.vertices.Length];
        currentMeshVertices = new Vector3[mesh.vertices.Length];
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            jellyVertices[i] = new JellyVertex(i, mesh.vertices[i], mesh.vertices[i], Vector3.zero);
            currentMeshVertices[i] = mesh.vertices[i];
        }
        Debug.Log(jellyVertices.Length);
    }

    private void UpdateVertices()
    {
        for (int i = 0; i < jellyVertices.Length; i++)
        {
            jellyVertices[i].UpdateVelocity(bounceSpeed);
            jellyVertices[i].Settle(stiffness);

            jellyVertices[i].currentVertexPosition += jellyVertices[i].currentVelocity * Time.deltaTime;
            currentMeshVertices[i] = jellyVertices[i].currentVertexPosition;
        }

        mesh.vertices = currentMeshVertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }

    public void ApplyPressureToPoint(Vector3 _point, float _pressure)
    {
        //for (int i = 0; i < jellyVertices.Length; i++)
        for (int i = 100; i < jellyVertices.Length - 100; i++)
        {
            //jellyVertices[i].ApplyPressureToVertex(transform, _point, _pressure);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        //Debug.Log("patient collision: " + other.gameObject.name);
        ContactPoint[] collisionPoints = other.contacts;
        Debug.Log(collisionPoints[0].point);
        Debug.Log(collisionPoints.Length);
        for (int i = 0; i < collisionPoints.Length; i++)
        {
            Vector3 inputPoint = collisionPoints[i].point + (collisionPoints[i].point * .1f);
            ApplyPressureToPoint(inputPoint, fallForce);
        }
    }
}
