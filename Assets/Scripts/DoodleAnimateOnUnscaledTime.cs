using UnityEngine;
using DoodleStudio95;

namespace DoodleStudio95Examples {
///
///		Workaround to have a DoodleAnimator use unscaled time, so you can
///		play animations in a pause menu
///
[RequireComponent(typeof(DoodleAnimator))]
public class DoodleAnimateOnUnscaledTime : MonoBehaviour {

	DoodleAnimator animator;

	void Start () {
		animator = GetComponent<DoodleAnimator>();
		// Pause the animator so its playback script doesn't override this
		animator.GoToAndPause(0);
	}
	
	void Update () {
		int frame = 0;
		// Get the frame number we need to be at, passing unscaled time
		animator.File.GetFrameAt(out frame, Time.unscaledTime, animator.speed, 
			animator.PlaybackMode, animator.FramesPerSecond);
		// Set the animator to the right frame
		animator.SetFrame(frame);
	}
}
}
