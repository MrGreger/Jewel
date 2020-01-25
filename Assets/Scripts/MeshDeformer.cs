using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeshDeformer : MonoBehaviour
{
    public Image Cutter;

    private ImageMover _imageMover;

    public float DeformationDistance;
    public float DeformationSpeed;

    private Vector3 _meshCenter;

    public Transform DeformationTo;

    private void Start()
    {
        _imageMover = GetComponent<ImageMover>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _imageMover.MoveImage(Cutter, Input.mousePosition);

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.PositiveInfinity))
            {
                var deformable = raycastHit.transform.GetComponent<DeformableMesh>();

                if (deformable != null)
                {
                    var verts = deformable.GetMeshVerts();

                    for (int i = 0; i < verts.Length; i++)
                    {
                        if (Vector3.Distance(deformable.transform.TransformPoint(verts[i]), raycastHit.point) <= DeformationDistance)
                        {
                            print(verts[i]);
                            verts[i] = deformable.transform.InverseTransformPoint(Vector3.MoveTowards(deformable.transform.TransformPoint(verts[i]), DeformationTo.position, Time.deltaTime * DeformationSpeed));
                        }
                    }

                    deformable.SetMeshVerts(verts);
                }
            }
        }
    }
}
