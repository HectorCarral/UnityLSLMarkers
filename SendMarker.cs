using UnityEngine;
using System.Collections;
using Assets.LSL4Unity.Scripts.Custom;

public class SendMarker : MonoBehaviour {

	public LSLMarkerStream markerStream;

	// Markers
	public const int MARKER_TEST = 1;	// Test marker


	// For avoiding sending the same marker twice in a row
	private int lastMarker = -1;

	public void Awake () {
		DontDestroyOnLoad (gameObject);
		//markerStream = GameObject.Find ("LabStreamingLayer").GetComponent<LSLMarkerStreamMidas> ();
	}

	public void Send (int marker) {
		// Avoid sending the same marker twice in a row
		if (marker != lastMarker) {
			markerStream.Write(marker);
			lastMarker = marker;
			Debug.Log ("Sending marker: " + marker);
		}
	}
}
