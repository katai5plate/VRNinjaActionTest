using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shaker : MonoBehaviour {

	float shakeRange = 0.8f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player.Velocity>0.4){
			transform.Rotate(new Vector3(Random.Range(-1,1)*shakeRange,Random.Range(-1,1)*shakeRange,Random.Range(-1,1)*shakeRange));
		}else{
			transform.rotation = Quaternion.EulerAngles(new Vector3(0,0,0));
		}
	}
}
