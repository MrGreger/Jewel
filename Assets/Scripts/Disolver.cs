using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disolver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, float.PositiveInfinity))
            {
                Debug.Log(hit.collider.name);

                var propertyBlock = new MaterialPropertyBlock();
                propertyBlock.SetVector("Vector4_363325EF", new Vector4(hit.point.x, hit.point.y, hit.point.z));
                hit.collider.GetComponent<MeshRenderer>()?.SetPropertyBlock(propertyBlock);
            }
        }
    }

}
