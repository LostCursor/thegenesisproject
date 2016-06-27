using UnityEngine;
using System.Collections;

public class BillboardSprite : MonoBehaviour {
	public Camera m_CameraToFace;

	void Update() {
		if(m_CameraToFace.orthographic)
			transform.LookAt(transform.position - m_CameraToFace.transform.forward, m_CameraToFace.transform.up);
		else   
			transform.LookAt(m_CameraToFace.transform.position, m_CameraToFace.transform.up);
	}
}
