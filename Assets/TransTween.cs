using UnityEngine;
using System.Collections;

public class TransTween : MonoBehaviour {
	public float Flame = 0;
	public float CurveLength = 1;
	public float CurveDeltaMul = 1;
	float f;
	public AnimationCurve Curve;
	public WrapMode Wrap;
	Vector3 aPos,aRot,aSca;
	public Vector3 bPos = new Vector3(-9999999, -9999999, -9999999);
	public Vector3 bRot = new Vector3(-9999999, -9999999, -9999999);
	public Vector3 bSca = new Vector3(-9999999, -9999999, -9999999);

	void Start(){
		Curve.postWrapMode = Wrap;
		Curve.preWrapMode = Wrap;
		aPos = transform.position;
		bPos = new Vector3(
			bPos.x == -9999999 ? aPos.x : bPos.x,
			bPos.y == -9999999 ? aPos.y : bPos.y,
			bPos.z == -9999999 ? aPos.z : bPos.z
		);
		aRot = transform.eulerAngles;
		bRot = new Vector3(
			bRot.x == -9999999 ? aRot.x : bRot.x,
			bRot.y == -9999999 ? aRot.y : bRot.y,
			bRot.z == -9999999 ? aRot.z : bRot.z
		);
		aSca = transform.localScale;
		bSca = new Vector3(
			bSca.x == -9999999 ? aSca.x : bSca.x,
			bSca.y == -9999999 ? aSca.y : bSca.y,
			bSca.z == -9999999 ? aSca.z : bSca.z
		);
	}

	void Update(){
		Flame += Time.deltaTime * CurveDeltaMul;
		f = Flame*CurveLength;
		transform.position = 
			Vector3.Lerp(aPos,bPos,Curve.Evaluate(f));
		transform.eulerAngles = 
			Vector3.Lerp(aRot,bRot,Curve.Evaluate(f));
		transform.localScale = 
			Vector3.Lerp(aSca,bSca,Curve.Evaluate(f));
	}
}