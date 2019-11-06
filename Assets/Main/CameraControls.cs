/*
 * Code provided by unity at
 * https://unity3d.com/fr/learn/tutorials/topics/mobile-touch/pinch-zoom
 */

using UnityEngine;

public class CameraControls: MonoBehaviour {
	public float perspectiveZoomSpeed = 0.5f;
	public float orthoZoomSpeed = 0.5f;
	public Camera cam;

	private Touch touchZero;
	private Touch touchOne;

	private Vector2 touchZeroPrevPos;
	private Vector2 touchOnePrevPos;

	private float prevTouchDeltaMag;
	private float touchDeltaMag;

	private float deltaMagnitudeDiff;

	public void Start() {
		cam = gameObject.GetComponent<Camera>();
	}

	void Update() {

		if (Input.touchCount == 2) {

			touchZero = Input.GetTouch(0);
			touchOne = Input.GetTouch(1);

			touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			if (cam.orthographic) {
				cam.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
				cam.orthographicSize = Mathf.Max(cam.orthographicSize, 0.1f);
			} else {
				cam.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
				cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 0.1f, 179.9f);
			}
		}
	}
}
