using UnityEngine;
using System.Collections;

public class DeviceCamera : MonoBehaviour {
	public WebCamTexture back;
	public Renderer renderer;
	public Skybox skybox;
	public WebCamDevice[] devices;
	// Use this for initialization
	void Start () {
		devices = WebCamTexture.devices;
		print (devices[0].name);
		back = new WebCamTexture (640, 320, 30);
		renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = back;
		back.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
