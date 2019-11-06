using System.Collections.Generic;
using UnityEngine;

public class MainDirector : MonoBehaviour {

	private List<GameObject> loadedObjects;
	private bool timePaused;
	private bool paused;

	void Start() {
		loadedObjects = new List<GameObject>();
		timePaused = false;
		paused = true;
	}

	void Update() {

	}

	public void addNewObject(GameObject newObject) {
		loadedObjects.Add(newObject);
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
