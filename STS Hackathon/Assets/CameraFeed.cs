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

	// Use this for initialization
	void Start () {
		back = new WebCamTexture (1920, 1080);
		rawimage = GetComponent<RawImage>();
		rawimage.texture = back;
		back.Play ();

		latitudeTargets = new double[] {38.6272};
		longitudeTargets = new double[] {90.1978};

		if (!Input.location.isEnabledByUser) {
			// user doesn't have location services enabled
			return;
		}
		Input.location.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		var latitude = Input.location.lastData.latitude;
		var longitude = Input.location.lastData.longitude;

		var lat_distance = (latitude - latitudeTargets [0]) * 364000; // 364,000 ft/1 degree latitude
		var cos_lat = Math.Cos(latitude * Math.PI / 180.0);
		var long_distance = (longitude - longitudeTargets [0]) * cos_lat * 365000;
		distance = Math.Sqrt (Math.Pow (lat_distance, 2.0f) + Math.Pow (long_distance, 2.0f));

		textobject.text = String.Format("Distance: {0} ft", distance);

		var color = new Color (1.0f, 0.0f, 0.0f, 0.5f);
		tint.GetComponent<Image> ().color = color;
	}
}
