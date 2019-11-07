using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour {

	MainDirector main;
	MenuManager menuManager;

	void Start() {
		Globals.selectionMode = false;
		main = GameObject.FindGameObjectWithTag("Director").GetComponent<MainDirector>();
		menuManager = GameObject.FindGameObjectWithTag("Director").GetComponent<MenuManager>();
	}

	void Update() {

	}

	public void toggleEnable() {
		if (Globals.selectionMode) {
			menuManager.loadSelectionMenu();
		} else {
			GetComponent<Image>().color = new Color(1, 1, 1);
			Globals.selectionMode = true;
		}
	}

	public void disable() {
		Globals.selectionMode = false;
		GetComponent<Image>().color = new Color(0, 0, 0);
		main.SelectNone();
		menuManager.unloadSelectionMenu();
	}
}
