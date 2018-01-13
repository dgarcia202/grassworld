using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	float bottomLimit = 4.0f;

	float topLimit = 105.0f;

	float speed = 25.0f;

	float verticalSpeed = 10.0f;

	float verticalSpeedFactor = 300.0f;

	int boundary = 3;

	int width, height;

	void Start () {
		width = Screen.width;
		height = Screen.height;
	}
	
	void Update () {
		ManagePanning ();
		ManageZoom ();
	}

	void ManageZoom() {
		// Zoom in
		if (Input.GetAxisRaw ("Mouse ScrollWheel") > 0) {
			var newPositionY = transform.position.y - Input.GetAxisRaw ("Mouse ScrollWheel") * Time.deltaTime * verticalSpeed * verticalSpeedFactor;
			if (newPositionY < bottomLimit) {
				newPositionY = bottomLimit;
			}

			transform.position = new Vector3(transform.position.x,  newPositionY, transform.position.z);
		}	


		// Zoom out
		if (Input.GetAxisRaw ("Mouse ScrollWheel") < 0) {
			var newPositionY = transform.position.y - Input.GetAxisRaw ("Mouse ScrollWheel") * Time.deltaTime * verticalSpeed * verticalSpeedFactor;
			if (newPositionY > topLimit) 
			{
				newPositionY = topLimit;
			}

			transform.position = new Vector3(transform.position.x,  newPositionY, transform.position.z);
		}		
	}

	void ManagePanning() {
		if (Input.mousePosition.x > width - boundary)
		{
			transform.position += new Vector3 (Time.deltaTime * speed, 0.0f, 0.0f);
		}

		if (Input.mousePosition.x < boundary)
		{
			transform.position += new Vector3 (Time.deltaTime * -speed, 0.0f, 0.0f);
		}

		if (Input.mousePosition.y > height - boundary)
		{
			transform.position += new Vector3 (0.0f, 0.0f, Time.deltaTime * speed);		
		}

		if (Input.mousePosition.y < boundary)
		{
			transform.position += new Vector3 (0.0f, 0.0f, Time.deltaTime * -speed);		
		}
	}
}
