using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehavior : MonoBehaviour
{
	public GameBrain gameBrain;

	private bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision) {
		if (!hasCollided && collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
			gameBrain.OnGameComplete();

			hasCollided = true;
		}
	}
}
