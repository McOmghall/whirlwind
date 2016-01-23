using UnityEngine;
using System.Collections;

public class SpawnSpheresInSphere : MonoBehaviour {

    public int spheres = 10;
    public float gravity = 9.8f;
    public GameObject sphereToCopyFrom;
    private GameObject[] spheresCreated;

	// Use this for initialization
	void Start () {
        this.spheresCreated = new GameObject[spheres];

        for (int i = 0; i < spheres; i++) {
            Vector3 position = Vector3.Scale(Random.insideUnitSphere, this.transform.lossyScale * 2) + this.transform.position;
            this.spheresCreated[i] = Object.Instantiate(sphereToCopyFrom, position, Quaternion.identity) as GameObject;
            this.spheresCreated[i].GetComponent<ParticleSystem>().enableEmission = false;
        }
        Debug.Log("Allocated " + spheresCreated.Length);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate() {
        foreach(GameObject body in this.spheresCreated) {
            //body.AddForce((this.transform.position - body.position) * gravity * Time.smoothDeltaTime, ForceMode.Acceleration);

            if ((this.transform.position - body.transform.position).magnitude > 0.1 * this.transform.localScale.magnitude) {
                body.GetComponent<Rigidbody>().AddForce((Vector3.right * (body.transform.position.x > 0 ? -1 : 1) + Vector3.up * (body.transform.position.y > 0 ? -1 : 1) + Vector3.forward * (body.transform.position.z > 0 ? -1 : 1)) * gravity, ForceMode.Acceleration);
            } else {
                body.GetComponent<Rigidbody>().AddForce((this.transform.position - body.transform.position) * 10 * - gravity * Time.smoothDeltaTime, ForceMode.Impulse);
                body.GetComponent<ParticleSystem>().enableEmission = true;
                body.GetComponent<ParticleSystem>().Play();
                Invoke("KillParticles", body.GetComponent<ParticleSystem>().duration);
                Debug.Log("Bursting");
            }
        }
    }


}
