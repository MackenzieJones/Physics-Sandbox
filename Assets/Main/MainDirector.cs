using System.Collections.Generic;
using UnityEngine;

public class MainDirector : MonoBehaviour {

	private List<GameObject> loadedObjects;
	private bool timePaused;
	private bool paused;

	private Touch t1, t2;

	void Start() {
		loadedObjects = new List<GameObject>();
		timePaused = false;
		paused = true;
	}

	void Update() {
		getTouched();
	}

	private void getTouched() {
		if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began && Globals.selectionMode) {
			t1 = Input.GetTouch(0);

			Ray ray = Camera.main.ScreenPointToRay(t1.position);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
			if (hit.transform != null) {
				ShapeObject so = hit.transform.gameObject.GetComponent<ShapeObject>();
				if (so != null) {
					so.selectToggle();
				}
			}
		}
	}

	public bool anySelected() {
		foreach (GameObject g in loadedObjects) {
			if (g.GetComponent<ShapeObject>().selected) {
				return true;
			}
		}

		return false;
	}

	public void addNewObject(GameObject newObject) {
		loadedObjects.Add(newObject);
	}

	public void SelectAll() {
		foreach (GameObject shape in loadedObjects) {
			shape.GetComponent<ShapeObject>().select(true);
		}
	}

	public void SelectNone() {
		foreach (GameObject shape in loadedObjects) {
			shape.GetComponent<ShapeObject>().select(false);
		}
	}

	public void DeleteSelected() {
		GameObject[] list = loadedObjects.ToArray();
		
		for (int i = 0; i < list.Length; i++) {
			if (list[i].GetComponent<ShapeObject>().selected) {
				loadedObjects.Remove(list[i]);
				Destroy(list[i]);
			}
		}
	}

	public void DeleteAll() {
		GameObject[] list = loadedObjects.ToArray();

		for (int i = 0; i < list.Length; i++) {
			Destroy(list[i]);
		}

		loadedObjects.Clear();
	}

	public bool isPaused() {
		return paused;
	}

	public void setPaused(bool state) {
		paused = state;
	}

	public bool isTimePaused() {
		return timePaused;
	}

	public void setTimePaused(bool state) {
		timePaused = state;
	}
}
