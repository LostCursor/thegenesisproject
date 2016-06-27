using UnityEngine;
using System.Collections;

public class BillboardSprite : MonoBehaviour {
	void Update() {
		if(m_CameraToFace.orthographic)
			transform.LookAt(transform.position - m_CameraToFace.transform.forward, m_CameraToFace.transform.up);
		else   
			transform.LookAt(m_CameraToFace.transform.position, m_CameraToFace.transform.up);
	}
}
