using UnityEngine;
using UnityEngine.UI;

public class SessionEdit : MonoBehaviour {

	public Dropdown bgChoice;
	public GameObject background;
	public Sprite[] bgs;

	private float width;
	private float height;

	private float initialWidth;
	private float initialHeight;

	private float maxBoundrySize;

	private Vector3 boundryInitialSize;

	public Toggle boundryToggle;
	public Toggle roofToggle;

	public Slider[] sizes;
	public Text[] displayValues;

	public GameObject boundry;
	public GameObject roof;
	private MenuManager manager;

	void Start() {
		manager = GameObject.FindGameObjectWithTag("Director").GetComponent<MenuManager>();
		initialWidth = sizes[0].value;
		initialHeight = sizes[1].value;
		boundryInitialSize = boundry.transform.localScale;
		maxBoundrySize = 3;
	}

	void FixedUpdate() {
		boundry.transform.localScale = new Vector3(boundryInitialSize.x * (1 + (sizes[0].value - initialWidth) * maxBoundrySize), boundryInitialSize.y * (1 + (sizes[1].value - initialHeight) * maxBoundrySize), 1);
	}

	public void backgroundChange() {
		background.GetComponent<SpriteRenderer>().sprite = bgs[bgChoice.value];
	}

	public void boundryChange() {
		if (boundryToggle.isOn) {
			//TODO: grey out everything under "boundry"
			boundry.SetActive(true);
		} else {
			//TODO: restore colour to everything under "boundry"
			boundry.SetActive(false);
		}
	}

	public void roofChange() {
		if (roofToggle.isOn) {
			roof.SetActive(true);
		} else {
			roof.SetActive(false);
		}
	}

	public void undoChanges() {

	}

	public void closePane() {
		manager.unloadEditSessionMenu();
	}
}
