using System;
using UnityEngine;
using UnityEngine.UI;

public class CreateNew: MonoBehaviour {

	public float mass;
	public float bounciness;
	public float r, g, b, prevRGB;
	public float size, prevSize;
	private GameObject shape;
	private int shapeIndex;

	public GameObject[] uiShapes; //Initalized in unity
	public GameObject[] realShapes; //Initalized in unity
	public GameObject[] sliders; //Initalized in unity

	public GameObject previewObject; //Initialized in unity with dummy object for location
	private GameObject newObject;
	public Canvas canvas;
	private MainDirector main;

	private float minSize = 20;
	private float maxSize = 300;

	void Start() {
		previewObject = Instantiate(uiShapes[0], previewObject.transform.position, Quaternion.identity, canvas.transform);
		previewObject.transform.SetParent(gameObject.transform);
		prevSize = 0;
		main = gameObject.GetComponent<MainDirector>();
	}

	void Update() {
		updateColour();
		updateSize();
		//TODO: add animation for bounce selection
		//updateBounce(); 
		//TODO: add graphic for mass change
		//updateMass();
	}

	private void updateSize() {
		size = sliders[5].GetComponent<Slider>().value;
		if (prevSize != size) {
			previewObject.transform.localScale = new Vector3((size + minSize * 1 / maxSize) * (maxSize - minSize), (size + minSize * 1 / maxSize) * (maxSize - minSize), 1);
		}
		prevSize = size;

	}

	private void updateColour() {
		r = sliders[2].GetComponent<Slider>().value;
		g = sliders[3].GetComponent<Slider>().value;
		b = sliders[4].GetComponent<Slider>().value;

		if (r + b + g != prevRGB) {
			previewObject.GetComponent<SpriteRenderer>().color = new Color(r, g, b);
		}

		prevRGB = r + b + g;
	}


	private void updateBounce() {
		throw new NotImplementedException();
	}

	private void updateMass() {
		throw new NotImplementedException();
	}

	public void pickShape(int shapeChoice) {
		shapeIndex = shapeChoice;
		shape = uiShapes[shapeIndex];
		previewObject.GetComponent<SpriteRenderer>().sprite = shape.GetComponent<SpriteRenderer>().sprite;
		previewObject.GetComponent<SpriteRenderer>().color = new Color(r, g, b);
		previewObject.transform.localScale = new Vector3((size + minSize * 1 / maxSize) * (maxSize - minSize), (size + minSize * 1 / maxSize) * (maxSize - minSize), 1);
		previewObject.transform.SetParent(gameObject.transform);
	}

	public void spawnNewObject() {
		GameObject newObject = Instantiate(realShapes[shapeIndex], new Vector3(0, 0, 0), Quaternion.identity);

		newObject.transform.localScale = new Vector3(size * 2.7f, size * 2.7f, 1);

		newObject.GetComponent<SpriteRenderer>().color = new Color(r, g, b);

		newObject.GetComponent<Rigidbody2D>().mass = sliders[0].GetComponent<Slider>().value * 20;

		PhysicsMaterial2D mat2D = new PhysicsMaterial2D();
		mat2D.bounciness = sliders[1].GetComponent<Slider>().value * 2f;
		mat2D.friction = 2;
		newObject.GetComponent<Collider2D>().sharedMaterial = mat2D;

		main.addNewObject(newObject);
	}

}
