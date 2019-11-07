using UnityEngine;

public class ShapeObject : MonoBehaviour {

	private SpriteRenderer outlineRender;
	private GameObject outlineObject;
	public bool selected;

	void Start() {
		outlineObject = new GameObject("outline");
		outlineRender = outlineObject.AddComponent<SpriteRenderer>();
		outlineRender.sprite = GetComponent<SpriteRenderer>().sprite;
		outlineRender.color = new Color(240, 170, 0);

		float sizeAdder = 0.1f;

		if (name.Contains("Hex")) {
			sizeAdder += 0.025f;
		} else if (name.Contains("Tri")) {
			sizeAdder += 0.1f;
		}

		outlineObject.transform.localScale = new Vector3(transform.localScale.x + sizeAdder, transform.localScale.y + sizeAdder, outlineObject.transform.localScale.z);


		outlineObject.transform.position = transform.position + Vector3.forward;
		outlineObject.transform.rotation = transform.rotation;
		outlineObject.transform.parent = transform;

		selected = false;
		outlineObject.SetActive(false);
	}

	void Update() {
	}

	public void select(bool inp) {
		selected = inp;
		outlineObject.SetActive(selected);
	}

	public void selectToggle() {
		selected = !selected;
		outlineObject.SetActive(selected);
	}

	public void delete() {
		Destroy(outlineObject);
		Destroy(gameObject);
	}
}
