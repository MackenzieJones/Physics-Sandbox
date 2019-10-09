using UnityEngine;

public class CreateNewButton: MonoBehaviour {

	public GameObject menu; //Initialized in unity

	void Start() {

	}

	void Update() {

	}

	public void loadCreateNewMenu() {
		menu.SetActive(true);
	}

	public void unloadCreateNewMenu() {
		menu.SetActive(false);
	}
}
