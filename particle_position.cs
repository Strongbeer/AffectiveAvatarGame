using UnityEngine;
using System.Collections;

public class particle_position : MonoBehaviour {

	void Start (){
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Particles";
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = 2;
	}
}
