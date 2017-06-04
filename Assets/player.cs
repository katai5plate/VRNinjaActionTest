using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class player : MonoBehaviour {

	public GvrHead h;
	public Text t;
	public Vector3 Angle;
	public Transform Foward;
	Rigidbody r;
	player_audio a;
	static public bool Flowing = false;
	static public bool NextEndJump = false;
	static public float Velocity = 0;
	static public float VelocityOri = 0;
	int dashPp = 0;
	int dashPpPrev = 0;
	public Transform camT;
	public float FallenDown = -50;
	public Transform Respawnpoint;
	public float MoveSpeedMax = 1;
	public float MoveSpeedMul = 5;
	public float JumpPower = 300f;

	[Range(0,1f)]public float test01;
	[Range(0,10f)]public float test02;
	public AnimationCurve testc;

	bool DashTrig;

	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody>();
		a = GetComponent<player_audio>();
	}

	public Vector3 AccelAngle;
	Vector3 NowAngle;
	Vector3 PrevAngle;
	public int AccelFlame = 2;
	int AccelFlameCnt;

	// Update is called once per frame
	void Update () {

		test02 = Mathf.Lerp(0,10,testc.Evaluate(test01));

		Angle = angleFixVec3(h.transform.rotation.eulerAngles);

		if(AccelFlameCnt>=AccelFlame){
			NowAngle = Angle;
			AccelAngle = PrevAngle-NowAngle;
			PrevAngle=NowAngle;
			AccelFlameCnt=0;
		}else{
			AccelFlameCnt++;
		}

		if(AccelAngle.x>12.5f){
			Jump();
		}

		if(Mathf.Abs(AccelAngle.y)>12.5f){
			Brake(8);
		}



		Velocity = ClampDev01(
			(
				Mathf.Abs(r.velocity.x)+
				Mathf.Abs(r.velocity.y)+
				Mathf.Abs(r.velocity.z))/3
				,0f,30f,30f
			);
		VelocityOri = 
			(
				Mathf.Abs(r.velocity.x)+
				Mathf.Abs(r.velocity.y)+
				Mathf.Abs(r.velocity.z)
			)/3;

		RaycastHit hit;
		if(Physics.Raycast(h.Gaze,out hit)){
			//print(hit.collider.gameObject.name);
		}

		t.text = ""+Angle
			+"\n"+VelocityOri;

		Foward.position = new Vector3(
			Mathf.Sin(Mathf.PI/180*h.transform.eulerAngles.y),
			0,
			Mathf.Cos(Mathf.PI/180*h.transform.eulerAngles.y)
		);

		if(NextEndJump){
			a.PlaySound("Chaku");
			player.Flowing = false;
			NextEndJump = false;
		}

		if(Mathf.Abs(Angle.z)>40){
//			r.velocity = new Vector3(
//				r.velocity.x/4*3,
//				r.velocity.y,
//				r.velocity.z/4*3
//			);
		}

		if(Angle.x<-20){
			if(VelocityOri < MoveSpeedMax){
				r.AddForce(Foward.position*-MoveSpeedMul);
			}
		}else if(-20<Angle.x && Angle.x<=10){
			
		}else if(10<Angle.x && Angle.x<=55){
			if(VelocityOri < MoveSpeedMax){
				r.AddForce(Foward.position*MoveSpeedMul);
			}
		}else if(60<Angle.x){
			
		}

//		if(Angle.x<10){
//		}else if(10<Angle.x && Angle.x<=35){
//			//r.AddForce(Foward.position*(Mathf.Clamp(Angle.x-15,0f,10f)));
//			r.AddForce(Foward.position*10f);
//		}else if(35<Angle.x && Angle.x<=55){
//			//Jump();
//		}else if(55<Angle.x){
//			//Brake();
//		}

//		if(!Flowing && Mathf.Abs(Angle.z) > 20f){
//			dashPp = 
//				Angle.z<0?-1:
//				Angle.z>0?1:
//				0;
//			if(dashPp!=dashPpPrev){
//				r.AddForce(camT.transform.forward*300f);
//				dashPpPrev = dashPp;
//			}
//		}else{
//			
//		}

		if(transform.position.y < FallenDown){
			r.velocity = Vector3.zero;
			transform.position = Respawnpoint.position;
			transform.rotation = Respawnpoint.rotation;
			transform.localScale = Respawnpoint.localScale;
			transform.parent = null;
		}
	}

	void Jump(){
		if(!Flowing){
			r.AddForce(Vector3.up*JumpPower);
			a.PlaySound("Jump");
			Flowing = true;
		}
	}

	void Brake(int dev){
		r.velocity = new Vector3(
			r.velocity.x/dev*(dev-1),
			r.velocity.y,
			r.velocity.z/dev*(dev-1)
		);
	}


	float ClampDev01(float value, float min, float max, float dev){
		return Mathf.Clamp(value,min,max)/dev;
	}



	float angleFix(float x){
		return x>180f?-(360-x):x;
	}
	Vector3 angleFixVec3(Vector3 v){
		return new Vector3(
			angleFix(v.x),
			angleFix(v.y),
			angleFix(v.z)
		);
	}
}
