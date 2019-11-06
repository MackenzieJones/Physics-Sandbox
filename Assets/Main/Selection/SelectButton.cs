using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour {

	MainDirector main;

	void Start() {
		Globals.selectionMode = false;
		main = GameObject.FindGameObjectWithTag("Director").GetComponent<MainDirector>();
	}

	void Update() {

	}

	public void toggleEnable() {
		Globals.selectionMode = !Globals.selectionMode;

		if (Globals.selectionMode) {
			GetComponent<Image>().color = new Color(1, 1, 1);
		} else {
			GetComponent<Image>().color = new Color(0, 0, 0);
			main.SelectNone();
			
		}
	}
}
