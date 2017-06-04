using UnityEngine;
using System.Collections;

public class player_audio : MonoBehaviour {

	public GvrAudioSource Wind;
	public GvrAudioSource Jump;
	public GvrAudioSource Chaku;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Wind.volume = player.Velocity*3;
		Wind.pitch = (player.Velocity)*5;
	}

	public void PlaySound(string Name){
		switch(Name){
		case "Jump":
			Jump.Play();
			break;
		case "Chaku":
			Chaku.Play();
			break;
		}
	}
}
