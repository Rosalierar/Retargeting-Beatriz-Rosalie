using UnityEngine;
using System.Collections;

public class TrocaCor : MonoBehaviour {

	private Vector4 originalColor;
	bool tf = false;

	void Start (){
		originalColor = gameObject.GetComponent<ParticleSystem>().startColor;
	}

	public void originalEAzul(){
        if (tf)
        {
            gameObject.GetComponent<ParticleSystem>().startColor = new Color(0.259f, 0.887f, 0.957f, 1.0f);
            tf = false;
        }
        else if (!tf)
        {
            gameObject.GetComponent<ParticleSystem>().startColor = originalColor;
            tf = true;
        }
	}

	public void Roxo() {
		gameObject.GetComponent<ParticleSystem>().startColor = new Color(0.55f, 0, 1.0f, 1.0f);
	}

	public void vermelhoAlaranjado(){
		if (tf)
		{
            gameObject.GetComponent<ParticleSystem>().startColor = new Color(0.937f, 0.572f, 0.063f, 1.0f);
			tf = false;
		}
		else if (!tf)
		{
            gameObject.GetComponent<ParticleSystem>().startColor = new Color(0.95f, 0, 0, 1.0f);
            tf = true;
        }
    }

	public void verdeEAmarelo(){
        if (tf)
        {
            gameObject.GetComponent<ParticleSystem>().startColor = new Color(0, 0.95f, 0, 1.0f);
            tf = false;
        }
        else if (!tf)
        {
            gameObject.GetComponent<ParticleSystem>().startColor = new Color(0.957f, 0.667f, 0.259f, 1.0f);
            tf = true;
        }
	}

	public void azulEsverdeado (){
		gameObject.GetComponent<ParticleSystem>().startColor = new Color(0.259f, 0.887f, 0.957f, 1.0f);
	}

	public void amareloAlaranjado(){
        if (tf)
        {
            gameObject.GetComponent<ParticleSystem>().startColor = new Color(0.957f, 0.667f, 0.259f, 1.0f);
            tf = false;
        }
        else if (!tf)
        {
            gameObject.GetComponent<ParticleSystem>().startColor = new Color(0.937f, 0.572f, 0.063f, 1.0f);
            tf = true;
        }
	}

	public void laranja(){
		gameObject.GetComponent<ParticleSystem>().startColor = new Color(0.937f, 0.572f, 0.063f, 1.0f);
	}
}

//66 = 0.259f
//244 = 0.957f
//225 = 0.887f