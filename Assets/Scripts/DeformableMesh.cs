using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class DeformableMesh : MonoBehaviour
{
    private Mesh _mesh;
    private MeshCollider _meshCollider;

    private Vector3 _meshCenter;
    private Vector3 _lastPosition;

    public Vector3[] GetMeshVerts()
    {
        return _mesh.vertices;
    }

    public Vector3 GetMeshCenter()
    {
        return _meshCenter;
    }

    public void SetMeshVerts(Vector3[] vertices)
    {
        _mesh.vertices = vertices;

        _mesh.RecalculateNormals();
        _mesh.RecalculateBounds();

        _meshCollider.sharedMesh = _mesh;
    }

    private void Start()
    {
        _mesh = GetComponent<MeshFilter>().mesh;
        _meshCollider = GetComponent<MeshCollider>();

        RecalculateProps();
    }

    private void Update()
    {
        if(_lastPosition != transform.position)
        {
            RecalculateProps();
        }
    }

    private void RecalculateProps()
    {
        _lastPosition = transform.position;
        UpdateMeshCenter();
    }

    private void UpdateMeshCenter()
    {
        _meshCenter = _mesh.bounds.center;
    }
}
