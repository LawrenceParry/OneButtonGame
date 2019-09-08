using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPitch : MonoBehaviour {
	AudioSource[] audio;
	[SerializeField] Vector2 range;

	void Start () {
		audio = GetComponents<AudioSource> ();
		for (int i = audio.Length-1; i >= 0; i--) {
			audio [i].pitch = Random.Range (range.x, range.y);
		}
	}
}
