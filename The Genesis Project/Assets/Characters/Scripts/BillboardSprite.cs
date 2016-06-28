using UnityEngine;
using System.Collections;

public class BillboardSprite : MonoBehaviour {
	public Camera CameraToFace;

	void Update() {
		transform.LookAt(transform.position + CameraToFace.transform.rotation * Vector3.forward,
			CameraToFace.transform.rotation * Vector3.up);
	}
}
