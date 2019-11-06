/*
 * Code provided by unity at
 * https://unity3d.com/fr/learn/tutorials/topics/mobile-touch/pinch-zoom
 */

using UnityEngine;

public class CameraControls : MonoBehaviour {
	public float perspectiveZoomSpeed = 0.5f;
	public float orthoZoomSpeed = 0.5f;
	public Camera cam;

	private Touch t1;
	private Touch t2;

	private Vector2 touchZeroPrevPos;
	private Vector2 touchOnePrevPos;

	private bool firstTouch;
	private Vector3 worldPin;
	private Vector3 worldTouch;


	private float prevTouchDeltaMag;
	private float touchDeltaMag;

	private float deltaMagnitudeDiff;

	private MainDirector director;

	public void Start() {
		cam = gameObject.GetComponent<Camera>();
		director = GameObject.FindGameObjectWithTag("Director").GetComponent<MainDirector>();
		firstTouch = true;
	}

	void Update() {

		if (!director.isPaused()) {
			if (Input.touchCount == 1) {
				t1 = Input.GetTouch(0);

				if (firstTouch) {
					worldPin = Camera.main.ScreenToWorldPoint(t1.position);
					firstTouch = false;
				}
				worldTouch = Camera.main.ScreenToWorldPoint(t1.position);

				Camera.main.transform.position += worldPin - worldTouch;

			} else {
				firstTouch = true;
			}

			if (Input.touchCount >= 2) {

				t1 = Input.GetTouch(0);
				t2 = Input.GetTouch(1);

				touchZeroPrevPos = t1.position - t1.deltaPosition;
				touchOnePrevPos = t2.position - t2.deltaPosition;

				prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
				touchDeltaMag = (t1.position - t2.position).magnitude;

				deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

				if (cam.orthographic) {
					cam.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
					cam.orthographicSize = Mathf.Max(cam.orthographicSize, 0.1f);
				} else {
					cam.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
					cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 0.1f, 179.9f);
				}

			}
		} else {
			firstTouch = true;
		}

	}

}
