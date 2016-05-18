using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {
	
	public float offset = 12.0f;
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Line"){
			other.transform.position = new Vector3 (other.transform.position.x, other.transform.position.y + offset, other.transform.position.z);
		}
	}
}
