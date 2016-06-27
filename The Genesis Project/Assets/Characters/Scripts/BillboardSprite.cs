using UnityEngine;
using System.Collections;

public class BillboardSprite : MonoBehaviour {
	public Camera m_CameraToFace;

	void Update() {
		transform.LookAt(transform.position + m_CameraToFace.transform.rotation * Vector3.forward,
			m_CameraToFace.transform.rotation * Vector3.up);
	}
}
