using UnityEngine;
using System.Collections;

public class SpawnSpheresInSphere : MonoBehaviour {

    public int spheres = 10;
    public float gravity = 9.8f;
    public GameObject sphereToCopyFrom;
    private Rigidbody[] spheresCreated;

	// Use this for initialization
	void Start () {
        this.spheresCreated = new Rigidbody[spheres];

        for (int i = 0; i < spheres; i++) {
            Vector3 position = Vector3.Scale(Random.insideUnitSphere, this.transform.lossyScale) + this.transform.position;
            this.spheresCreated[i] = (Object.Instantiate(sphereToCopyFrom, position, Quaternion.identity) as GameObject).GetComponent<Rigidbody>();
        }
        Debug.Log("Allocated " + spheresCreated.Length);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate() {
        foreach(Rigidbody body in this.spheresCreated) {
            //body.AddForce((this.transform.position - body.position) * gravity * Time.smoothDeltaTime, ForceMode.Acceleration);
            body.AddForce(Vector3.right * (body.position.x > 0 ? -1 : 1) * gravity, ForceMode.Acceleration);
            body.AddForce(Vector3.forward * (body.position.z > 0 ? -1 : 1) * gravity, ForceMode.Acceleration);
            body.AddForce(Vector3.up * (body.position.y > 0 ? -1 : 1) * gravity, ForceMode.Acceleration);
        }
    }
}
