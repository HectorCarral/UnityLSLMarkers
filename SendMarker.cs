using UnityEngine;
using System.Collections;
using Assets.LSL4Unity.Scripts.Custom;

public class SendMarker : MonoBehaviour {

	public LSLMarkerStream markerStream;

	// MARKERS
	// Define as many as needed here
	public const int MARKER_START =	1;      // Experimental protocol starts
    public const int MARKER_END =	9;      // Experimental protocol ends


	// For avoiding sending the same marker twice in a row
	private bool preventConsecutiveIdenticalMarkers = false;
	private int lastMarker = -1;

    // Variables to avoid sending two markers in the same frame, which sometimes causes a marker to be lost
    bool markerSentThisFrame = false;
    ArrayList markerQueue;

    public void Awake () {
		DontDestroyOnLoad (gameObject);
        markerQueue = new ArrayList();
	}

	public void Send (int marker) {
		if (!(preventConsecutiveIdenticalMarkers && marker == lastMarker)) {
	        if (markerSentThisFrame) {
	            // A marker was already sent this frame, queue it for the next frame
	            markerQueue.Add(marker);
	        } else {
	            // No marker has been sent this frame, so just send it now
	            markerStream.Write(marker);
	            Debug.Log("Sending marker " + marker);
	            markerSentThisFrame = true;
	        }
			lastMarker = marker;
		}
	}

    
    void Update()
    {
        markerSentThisFrame = false;
        if (markerQueue.Count > 0) {
            // Marker in queue to be sent
            Send((int)markerQueue[0]);
            markerQueue.RemoveAt(0);
        }
    }
}
