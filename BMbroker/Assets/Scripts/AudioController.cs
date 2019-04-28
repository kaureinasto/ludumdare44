using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
	private AudioSource source;
	public AudioClip buttonSound;
	public AudioClip mainLoop;
	// Use this for initialization
	void Awake () {
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void playButtonClick(){
		source.PlayOneShot(buttonSound,1f);
	}

}
