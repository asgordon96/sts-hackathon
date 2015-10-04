using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CameraFeed : MonoBehaviour {
	public WebCamTexture back;
	public RawImage rawimage;
	public LocationInfo location;
	public GameObject text;
	public Text textobject;
	public GameObject tint;
	public double distance;
	public double[] latitudeTargets; 
	public double[] longitudeTargets; 
	public Text message;
	public int counts;

	// Use this for initialization
	void Start () {
		counts = 0;
		back = new WebCamTexture (1920, 1080);
		rawimage = GetComponent<RawImage>();
		rawimage.texture = back;
		back.Play ();

		latitudeTargets = new double[] {38.645422};
		longitudeTargets = new double[] {-90.312469};

		if (!Input.location.isEnabledByUser) {
			// user doesn't have location services enabled
			return;
		}
		Input.location.Start(desiredAccuracyInMeters:1.0f, updateDistanceInMeters:1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		counts++;
		var latitude = Input.location.lastData.latitude;
		var longitude = Input.location.lastData.longitude;

		// calculate distance based on latitude and longitude
		var lat_distance = (latitude - latitudeTargets [0]) * 364000; // 364,000 ft/1 degree latitude
		var cos_lat = Math.Cos(latitude * Math.PI / 180.0);
		var long_distance = (longitude - longitudeTargets [0]) * cos_lat * 365000;
		distance = Math.Sqrt (Math.Pow (lat_distance, 2.0f) + Math.Pow (long_distance, 2.0f));

		textobject.text = String.Format("Distance: {0} ft", Math.Round(distance));

		if (distance < 500) {
			float alpha = (float)((1 - distance / 500.0f) * 0.75f);
			var color = new Color (1.0f, 0.0f, 0.0f, alpha);
			tint.GetComponent<Image> ().color = color;
		}

		if (distance < 20) {
			message.text = "You are about to enter VR mode!";
			Invoke("changeScene", 1.0f);
		}

		if (counts > 120) {
			message.text = "You are about to enter VR mode!";
			Invoke ("changeScene", 2.0f);
		}
	}

	void changeScene() {
		Application.LoadLevel (2);
	}
}
