using UnityEngine;
using UnityEngine.UI;

public class CreateNew: MonoBehaviour {

	public float mass;
	public float bounciness;
	public float r, g, b;
	public float size, prevSize;
	private GameObject shape;

	public GameObject[] shapes; //Initalized in unity
	public GameObject[] sliders; //Initalized in unity

	public GameObject previewObject; //Initialized in unity with dummy object for location
	private GameObject newObject;
	public Canvas canvas;

	private float minSize = 20;
	private float maxSize = 300;

	void Start() {
		previewObject = Instantiate(shapes[0], previewObject.transform.position, Quaternion.identity, canvas.transform);
		
		prevSize = 0;
	}

	void Update() {
		updateSize();
	}

	private void updateSize() {
		size = sliders[5].GetComponent<Slider>().value;
		if (prevSize != size) {
			previewObject.transform.localScale = new Vector3((size + minSize * 1 / maxSize) * (maxSize - minSize), (size + minSize * 1 / maxSize) * (maxSize - minSize), 1);
		}
		prevSize = size;
		
	}

	public void pickCircle() { shape = shapes[0]; }
	public void pickHex() { shape = shapes[1]; }
	public void pickSquare() { shape = shapes[2]; }
	public void pickTriangle() { shape = shapes[3]; }
}
