using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Animator animacao;
	public Rigidbody2D playerRigidbody;
	public int forceJump;

	public Transform chao;
	public LayerMask oQueSerChao;

	public AnimationClip animacaoSlide;

	public Transform colisor;

	float slideTempo;
	float atualTempo;

	bool noChao = false;
	bool slide = false;

	void Start () {
		// tempo da animacao
		slideTempo = animacaoSlide.averageDuration;
	}

	void Update () {

		if(Input.GetButtonDown("Jump") && noChao){
			playerRigidbody.AddForce(new Vector2(0, forceJump));
			if(slide){
				slide = false;
				colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.2f);
			}
		
		}else if(Input.GetButtonDown("Slide") && noChao && !slide){
			colisor.position = new Vector3(colisor.position.x, colisor.position.y - 0.2f);
			slide = true;
		}

		/**
		 * Verifica se a animação slide chegou ao fim,
		 * se sim, seta a variável slide p/ falso.
		 */
		if(slide){
			atualTempo = atualTempo + Time.deltaTime;
			if(atualTempo >= slideTempo){
				slide = false;
				atualTempo = 0;
				colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.2f);
			}
		}

		/*
		 * Cria uma colisão circular de 0.2 de radius,
		 * que verifica os pés do personagem e a layer chão.
		 */
		noChao = Physics2D.OverlapCircle(chao.position, 0.2f, oQueSerChao);

		/*
		 * Muda os parâmetros definidos no Animator.
		 */
		animacao.SetBool("jump", !noChao);
		animacao.SetBool("slide", slide);
	}

	void OnTriggerEnter2D(){
		Debug.Log("bateu");
	}

}
