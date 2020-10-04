using EzySlice;
using System.Collections;
using UnityEngine;

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
                camShaker.shakeCamera();
            }
        }
    }

    private void slice(GameObject gameObject, Material mat, Vector3 colPoint)
    {
        GameObject child = gameObject.transform.GetChild(0).gameObject;

        SlicedHull slicedObject = EzySlice(gameObject, colPoint, mat);
        SlicedHull slicedChild = EzySlice(child, colPoint,mat);

        GameObject upper;
        GameObject lower;
        GameObject upperChild;
        GameObject lowerChild;
        try
        {
            upper = slicedObject.CreateUpperHull(gameObject, mat);
            lower = slicedObject.CreateLowerHull(gameObject, mat);

            upperChild = slicedChild.CreateUpperHull(child, mat);
            lowerChild = slicedChild.CreateLowerHull(child, mat);
        }
        catch (System.Exception)
        {
            Destroy(slicedObject.upperHull);
            Destroy(slicedObject.lowerHull);
            return;
        }
        


        transformSetup(gameObject, child, upper, lower, upperChild, lowerChild);

        Destroy(gameObject);
    }

    private SlicedHull EzySlice(GameObject gameObject, Vector3 colPoint, Material mat = null)
    {
        return gameObject.Slice(colPoint, Vector3.right, mat);
    }

    private void componentSetup(GameObject gameObject, float velocity)
    {

        gameObject.AddComponent<MeshCollider>().convex = true;
        gameObject.layer = 12;

        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.AddExplosionForce(40f, gameObject.transform.position, 20f);
        rb.velocity += new Vector3(0,0,-velocity);

        StartCoroutine(WaitAndAddTorque(rb));

    }

    private void transformSetup(GameObject parent, GameObject child, GameObject upper, GameObject lower, GameObject upperChild, GameObject lowerChild)
    {

        Vector3 upperWorldScale = child.transform.localScale;
        float parentScale = parent.transform.lossyScale.y;

        upperChild.transform.position = upper.transform.position - new Vector3(child.transform.localPosition.y * parentScale, 0f, 0f);
        lowerChild.transform.position = lower.transform.position - new Vector3(child.transform.localPosition.y * parentScale, 0f, 0f);

        upperChild.transform.rotation = upper.transform.rotation;
        lowerChild.transform.rotation = lower.transform.rotation;


        upperChild.transform.parent = upper.transform;
        lowerChild.transform.parent = lower.transform;

        upperChild.transform.localScale = new Vector3(upperWorldScale.x, upperWorldScale.y, upperWorldScale.z);
        lowerChild.transform.localScale = new Vector3(upperWorldScale.x, upperWorldScale.y, upperWorldScale.z);


        componentSetup(upper, 2f);
        componentSetup(lower, 2f);
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
