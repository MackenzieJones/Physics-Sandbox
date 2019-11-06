using System.Collections.Generic;
using UnityEngine;

public class MainDirector: MonoBehaviour {

	private List<GameObject> loadedObjects;
	public bool forceViewEnabled;
	public bool timePaused;

	void Start() {
		loadedObjects = new List<GameObject>();
		forceViewEnabled = true;
		timePaused = false;
	}

	void Update() {

	}

	public void addNewObject(GameObject newObject) {
		loadedObjects.Add(newObject);
	}
}
