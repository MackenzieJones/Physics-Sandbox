using UnityEngine;

public class MenuManager : MonoBehaviour {

	public GameObject newObjectMenu; //Initialized in unity
	public GameObject editSessionMenu; //Initialized in unity

	private MainDirector director;
	private bool menuLoaded;

	void Start() {
		director = gameObject.GetComponent<MainDirector>();
		loadEditSessionMenu();
	}

	void Update() {

	}


	//TODO: do this the better way
	public void loadCreateNewMenu() {
		if (!menuLoaded) {
			menuLoaded = true;
			newObjectMenu.SetActive(true);
			director.setPaused(true);
		}
	}

	public void unloadCreateNewMenu() {
		menuLoaded = false;
		newObjectMenu.SetActive(false);
		director.setPaused(false);
	}

	public void loadEditSessionMenu() {
		if (!menuLoaded) {
			menuLoaded = true;
			editSessionMenu.SetActive(true);
			director.setPaused(true);
		}
	}

	public void unloadEditSessionMenu() {
		menuLoaded = false;
		editSessionMenu.SetActive(false);
		director.setPaused(false);
	}
}
