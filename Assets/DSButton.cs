using UnityEngine;
using System.Collections;

public class DSButton : MonoBehaviour {

	public Transform head;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(
			transform.eulerAngles.x,
			head.eulerAngles.y,
			transform.eulerAngles.z
		);
	}
}
