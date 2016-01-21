using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

    public GameObject target;

    void Start () {
        this.transform.LookAt(target.transform);
    }
 
	void FixedUpdate() {
        this.transform.RotateAround(target.transform.position, Vector3.forward + Vector3.right, Time.deltaTime * 15);
    }
}
