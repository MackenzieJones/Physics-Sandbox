using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions: MonoBehaviour {

	void Start() {

	}

	void Update() {

	}

	public void loadMain() {
		SceneManager.LoadSceneAsync("Main");
	}

}
