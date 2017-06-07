# UnityLSLMarkers
Asset for sending markers in Unity using LSL with LSL4Unity.

This project includes a Unity asset for easily sending markers using LSL. It consists of two main scripts.

* LSLMarkerStream.cs is the implementation of the LSL stream that will send the markers. It has to be in the scene and it requires the name and type of the stream that you’re creating. You shouldn’t need to modify anything (maybe remove the "DontDestroyOnLoad (gameObject)” if you don’t need it).

* SendMarker.cs is an intermediary class that I created for simplicity of usage (you don’t really need it, but it makes things easier). It has to be in the scene and it requires a reference to an instance of LSLMarkerStream (the class that I described above). This file has some markers defined that I created and that you’ll need to modify for your experiment. In my case, I made sure that the same marker was not sent twice in a row, but you may want to change that.

For using this, you can create a GameObject in your scene that is called ‘LabStreamingLayer’. This object has one LSLMarkerStream and one SendMarker (the former has a reference to the latter).

For using this from your experiment script, you get a reference to SendMarker:

    private SendMarker sendMarker;
    ... 
    sendMarker = GameObject.Find ("LabStreamingLayer").GetComponent<SendMarker> ();  

And then you use it like this:

    sendMarker.Send (SendMarker.MARKER_MAIN);
