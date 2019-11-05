using UnityEngine;

public class MenuManager : MonoBehaviour {

	public GameObject toolsMenu; 
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
	public void toggleToolsMenu() {
		if (!menuLoaded) {
			loadToolsMenu();
		} else {
			unloadToolsMenu();
		}
	}

	public void loadToolsMenu() {
		if (!menuLoaded) {
			menuLoaded = true;
			toolsMenu.SetActive(true);
			director.setPaused(true);
		}
	}

	public void unloadToolsMenu() {
		menuLoaded = false;
		toolsMenu.SetActive(false);
		director.setPaused(false);
	}

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
