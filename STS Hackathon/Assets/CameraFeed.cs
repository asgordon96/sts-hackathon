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

	// Use this for initialization
	void Start () {
		back = new WebCamTexture (1920, 1080);
		rawimage = GetComponent<RawImage>();
		rawimage.texture = back;
		back.Play ();

		if (!Input.location.isEnabledByUser) {
			// user doesn't have location services enabled
			return;
		}
		Input.location.Start ();
		distance = 100;
	}
	
	// Update is called once per frame
	void Update () {
		double dt = Time.deltaTime;
		distance += dt;
		textobject.text = String.Format("DISTANCE: {0} ft.", Math.Round (distance));

		var color = new Color (1.0f, 0.0f, 0.0f, 0.5f);
		tint.GetComponent<Image> ().color = color;
		//print (Input.location.lastData.latitude);
		//print (Input.location.lastData.longitude);
	}
}
