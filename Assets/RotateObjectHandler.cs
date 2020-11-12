using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectHandler : MonoBehaviour {
	void Update() {
		transform.Rotate(Vector3.forward * 50.0f * Time.deltaTime);
    }
}
