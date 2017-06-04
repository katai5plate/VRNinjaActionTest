using UnityEngine;
using System.Collections;

public class objmover : MonoBehaviour {

	[Range(0,1f)] public float Flame = 0;
	public AnimationCurve Curve;
	Transform Before;
	public Vector3 AfterPos = new Vector3(-9999999,-9999999,-9999999);
	public Vector3 AfterRot = new Vector3(-9999999,-9999999,-9999999);
	public Vector3 AfterSca = new Vector3(-9999999,-9999999,-9999999);

	// Use this for initialization
	void Start () {
		Before = transform;
		AfterPos.x = AfterPos.x == -9999999 ? Before.position.x : AfterPos.x;
		AfterPos.y = AfterPos.y == -9999999 ? Before.position.y : AfterPos.y;
		AfterPos.z = AfterPos.z == -9999999 ? Before.position.z : AfterPos.z;
		AfterRot.x = AfterRot.x == -9999999 ? Before.position.x : AfterRot.x;
		AfterRot.y = AfterRot.y == -9999999 ? Before.position.y : AfterRot.y;
		AfterRot.z = AfterRot.z == -9999999 ? Before.position.z : AfterRot.z;
		AfterSca.x = AfterSca.x == -9999999 ? Before.position.x : AfterSca.x;
		AfterSca.y = AfterSca.y == -9999999 ? Before.position.y : AfterSca.y;
		AfterSca.z = AfterSca.z == -9999999 ? Before.position.z : AfterSca.z;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(
			Before.position,
			AfterPos,
			Flame
		);
	}
}
