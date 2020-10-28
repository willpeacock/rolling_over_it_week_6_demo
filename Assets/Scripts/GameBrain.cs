using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBrain : MonoBehaviour {
	public PlayerController playerController;

    void Start() {
        
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
			OnGameComplete();
		}
    }

	public void OnGameComplete() {
		StartCoroutine(GameCompleteCo());
	}

	private IEnumerator GameCompleteCo() {
		playerController.enabled = false;
		Rigidbody2D playerRB = playerController.GetComponent<Rigidbody2D>();
		playerRB.velocity = Vector2.zero;
		playerRB.angularVelocity = 0.0f;
		playerRB.bodyType = RigidbodyType2D.Static;

		yield return new WaitForSeconds(1.0f);

		AsyncOperation ayncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

		while (!ayncLoad.isDone) {
			yield return null;
		}

	}
}
