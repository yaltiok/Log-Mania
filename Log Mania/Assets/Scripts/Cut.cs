using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Cut : MonoBehaviour
{
    public CameraShaker camShaker;
    public GameObject sawdustParticles;
    public GameObject particleHolder;
    public GameObject cutPlane;

    



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CuttingZone"))
        {
            if (other.gameObject != null && other.transform.parent != null && other.transform.parent.transform.position.z > -1.5f)
            {


                other.isTrigger = true;

                Material mat = other.transform.parent.GetComponent<Renderer>().material;




                slice(other.transform.parent.gameObject, mat, cutPlane.transform.position);




                Instantiate(sawdustParticles, other.transform.position, Quaternion.identity, particleHolder.transform);
                StartCoroutine(camShaker.Shake(.5f, .2f));
            }
        }
    }

    private void slice(GameObject gameObject, Material mat, Vector3 colPoint)
    {

        Vector3 upperWorldScale;

        float parentScale = gameObject.transform.lossyScale.x;

        GameObject child = gameObject.transform.GetChild(0).gameObject;

        upperWorldScale = child.transform.localScale;


        SlicedHull slicedObject = EzySlice(gameObject, colPoint, mat);

        SlicedHull slicedChild = EzySlice(child, colPoint,mat);



        GameObject upper = slicedObject.CreateUpperHull(gameObject, mat);
        GameObject lower = slicedObject.CreateLowerHull(gameObject, mat);


        GameObject upperChild = slicedChild.CreateUpperHull(child, mat);
        GameObject lowerChild = slicedChild.CreateLowerHull(child, mat);


        upperChild.transform.position = upper.transform.position - new Vector3(child.transform.localPosition.y * parentScale, 0f, 0f);
        lowerChild.transform.position = lower.transform.position - new Vector3(child.transform.localPosition.y * parentScale, 0f, 0f);

        upperChild.transform.rotation = upper.transform.rotation;
        lowerChild.transform.rotation = lower.transform.rotation;


        upperChild.transform.parent = upper.transform;
        lowerChild.transform.parent = lower.transform;

        upperChild.transform.localScale = new Vector3(upperWorldScale.x,upperWorldScale.y,upperWorldScale.z);
        lowerChild.transform.localScale = new Vector3(upperWorldScale.x, upperWorldScale.y, upperWorldScale.z);


        componentSetup(upper, 2f);
        componentSetup(lower, 2f);


        //setPositions(gameObject, upper,lower, colPoint);

        Destroy(gameObject);
    }

    private SlicedHull EzySlice(GameObject gameObject, Vector3 colPoint, Material mat = null)
    {
        return gameObject.Slice(colPoint, Vector3.right, mat);
        //return gameObject.SliceInstantiate(transform.position , Vector3.right);
    }

    private void componentSetup(GameObject gameObject, float velocity)
    {


        gameObject.AddComponent<MeshCollider>().convex = true;
        gameObject.layer = 12;
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.AddExplosionForce(40f, gameObject.transform.position /*+ new Vector3(-0.5f, 0,  -0.5f)*/, 20f);
        rb.velocity += new Vector3(0,0,-velocity);

        StartCoroutine(WaitAndAddTorque(rb));



    }


    IEnumerator WaitAndAddTorque(Rigidbody rb)
    {
        yield return new WaitForSeconds(0.25f);
        float a = Random.Range(-75f, 75f);
        float b = Random.Range(-75f, 75f);
        float c = Random.Range(-75f, 75f);
        rb.AddTorque(new Vector3(a, b, 0));
    }

}
