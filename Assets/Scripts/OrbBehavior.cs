using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrbBehavior : MonoBehaviour {
	private SpriteRenderer spriteRenderer;
	private PlayerController playerController;
	private bool collidedWithPlayer = false;
    void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		// Only one object in the scene should be of this type
		playerController = FindObjectOfType<PlayerController>();
	}

    void Update() {
        
    }

	private IEnumerator EndGameCo() {

		yield return new WaitForSeconds(2.0f);

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

		while (!asyncLoad.isDone) {
			yield return null;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (!collidedWithPlayer && collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
			collidedWithPlayer = true;
			playerController.FreezeAndDisablePlayer();
			playerController.transform.position = transform.position;
			spriteRenderer.enabled = false;
			StartCoroutine(EndGameCo());
		}
	}
}
