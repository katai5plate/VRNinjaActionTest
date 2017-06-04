using UnityEngine;
using System.Collections;

public class player_foot : MonoBehaviour {

	string NowColName,PrevColName;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
//		Ray ray = new Ray(
//			transform.position,
//			transform.position+Vector3.down
//		);
//		RaycastHit hit;
//		if(Physics.Raycast(ray,out hit,0.1f)){
//			print(hit.collider.gameObject.name);
//			if(player.Flowing && hit.collider.gameObject.tag == "Ground"){
//				player.Flowing = false;
//			}
//		}
	}



	void OnTriggerStay(Collider col) {
		NowColName = col.gameObject.tag;
		if(NowColName!=PrevColName){
			if(col.gameObject.tag == "Ground" && transform.parent.parent == null){
				transform.parent.parent = col.gameObject.transform;
			}
			if(!player.NextEndJump && player.Flowing && col.gameObject.tag == "Ground"){
				player.NextEndJump = true;
			}
			PrevColName = NowColName;
		}
	}
	void OnTriggerExit(Collider col) {
		PrevColName = "";
		if(col.gameObject.tag == "Ground"){
			player.Flowing = true;
			if(transform.parent.parent != null){
				transform.parent.parent = null;
				transform.parent.eulerAngles = Vector3.zero;
				transform.parent.localScale = Vector3.one;
			}
		}
	}

}
