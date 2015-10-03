using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraFeed : MonoBehaviour {
	public WebCamTexture back;
	public RawImage rawimage;
	public LocationInfo location;

	// Use this for initialization
	void Start () {
		back = new WebCamTexture (480, 325);
		rawimage = GetComponent<RawImage>();
		rawimage.texture = back;
		back.Play ();

		if (!Input.location.isEnabledByUser) {
			// user doesn't have location services enabled
			return;
		}
		Input.location.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		print (Input.location.status);
		//print (Input.location.lastData.latitude);
		//print (Input.location.lastData.longitude);
	}
}
