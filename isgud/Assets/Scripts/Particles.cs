using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour {
    public GameObject player;
    public float lengthmodifier = 1.5f;
    public float lifeTime = 0.1f;

    private ParticleSystem ps;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position = player.transform.position;
        ps = gameObject.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
        transform.rotation = player.transform.rotation;
	}

    public void Upgrade()
    {
        lifeTime = lifeTime * lengthmodifier;
        ps.startLifetime = lifeTime;
    }
}
