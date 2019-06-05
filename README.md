# UnityLSLMarkers
Asset for sending markers in Unity using LSL with [LSL4Unity](https://github.com/xfleckx/LSL4Unity).

This project includes a Unity asset for easily sending markers using LSL. It consists of two main scripts.

* LSLMarkerStream.cs is the implementation of the LSL stream that will send the markers. It has to be in the scene and it requires the name and type of the stream that you’re creating. You shouldn’t need to modify anything (maybe remove the "DontDestroyOnLoad (gameObject)” if you don’t need it).

* SendMarker.cs is an intermediary class that I created for simplicity of usage (you don’t really need it, but it makes things easier). It has to be in the scene and it requires a reference to an instance of LSLMarkerStream (the class that I described above). This file has some markers defined that I created and that you’ll need to modify for your experiment. It automatically avoids sending two markers on the same frame, because this sometimes could cause a marker to be lost. Now, if you send multiple markers on the same frame, only the first will be sent on that frame; the rest will be sent in the following frames, in order. If you change the variable preventConsecutiveIdenticalMarkers to true, it will never send the same marker two times in a row (this is disabled by default).

For using this, a prefab GameObject called ‘LabStreamingLayer’ is provided. This object has one LSLMarkerStream and one SendMarker (the former has a reference to the latter).

For using this from your experiment script, you get a reference to SendMarker:

    private SendMarker sendMarker;
    ... 
    sendMarker = GameObject.Find ("LabStreamingLayer").GetComponent<SendMarker> ();  

And then you use it like this:

    sendMarker.Send (SendMarker.MARKER_TEST);
