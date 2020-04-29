using UnityEngine;
using System.Collections;

public class CleanMusicLoop : MonoBehaviour {

	private AudioSource audioComponent;
	private AudioClip music;
	public float loopStart;		// The time in the song to be sent back to for a clean loop
	public float loopEnd;		// The time in the song at which the song should rewind back to the loopStart
	[SerializeField] private bool debuggingLoop;	// Used to skip ahead to the looping point, making it faster to iterate

    public void toggleMute() {

        audioComponent.mute = !audioComponent.mute;

    }



	// Use this for initialization
	void Start () {
		// This assumes that there is only a single audio source, or that the one you're looping is the first one visible in the editor.
		// I could also just use GetComponent, but this is more explicit, and can be changed in the future.
		audioComponent = gameObject.GetComponents<AudioSource>()[0];
		if(loopEnd == 0.0f)
			loopEnd = audioComponent.clip.length;

		if(debuggingLoop)
			audioComponent.time = loopEnd - 5;
	}
	
	// Update is called once per frame
	void Update () {
		// Once the audio clip reaches the end of the loop, return to the beginning.
		// Making this sound good depends on choosing good loop points in the original music track.
		// For example, for Bel Nix Battle Music V1, 23.482 and 31.522 both work as loopStarts for the loopEnd 95.508.
		if(audioComponent.time >= loopEnd)
			audioComponent.time = loopStart;
		//Debug.Log(audioComponent.time);
	}
}
