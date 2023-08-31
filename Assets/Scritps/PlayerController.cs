using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******Estados del personaje******/
public enum CharacterState
{
    Idle,
    Walk,
    JUMP
}
/**********************************/

public class PlayerController : MonoBehaviour
{
    [Tooltip("Velocidad de desplazamiento del personaje")]
    [SerializeField] private float speed = 2f;
    private float speedLR;
    private float speedFR;
    [Tooltip("Velocidad de rotación del personaje")]
    [SerializeField] private float rot = 30f;
    private float rotDir;
    

    private GameManager manager;
    private Rigidbody rb;

    private CharacterState estado;    // Mantiene el estado actual del personaje
    private bool onTheGround;
    
    void Start()
    {
        manager = GameManager.getInstance();
        rb = GetComponent<Rigidbody>();
        estado = CharacterState.Idle;
        speedLR = 0;
        speedFR = 0;
        rotDir = 0;
        onTheGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        getHumanInput();

        switch (estado){
            case CharacterState.Idle:
            break;
            case CharacterState.Walk:
                Debug.Log("Walk");
                transform.Translate(speedLR*Time.deltaTime,0,speedFR*Time.deltaTime);
                transform.Rotate(0,rotDir*Time.deltaTime,0);
                break;
            case CharacterState.JUMP:
                Debug.Log("JUMP");
                rb.AddForce(new Vector3(0,5,0), ForceMode.Impulse);
                break;
        }
    }

    private void getHumanInput(){
        bool _interaction = false;

        // Se verifica que el personaje se deba mover a la izquierda o a la derecha
        if(Input.GetKey("right")||Input.GetKey("left")) {
            estado = CharacterState.Walk;
            _interaction = true;
            if(Input.GetKey("right")){
                //mover a la derecha
                speedLR = speed;
            }
            else{
                //mover a la izquierda
                speedLR = -speed;
            }
        }

        if(Input.GetKey("up")||Input.GetKey("down")) {
            estado = CharacterState.Walk;
            _interaction = true;
            if(Input.GetKey("up")){
                //mover a la derecha
                speedFR = speed;

            }
            else{
                //mover a la izquierda
                speedFR = -speed;
            }
        }

        // Se verifica que el personaje deba saltar
        if(Input.GetKeyDown("space") && onTheGround){
            //saltar
            estado = CharacterState.JUMP;
            _interaction = true;
        }

        // Se verifica que el personaje deba rotar su vista
        if(Input.GetKey("a")||Input.GetKey("d")){
            estado = CharacterState.Walk;
            _interaction = true;
            if(Input.GetKey("a")){
                //rotar la cápsula a la izquierda
                rotDir = -rot;
            }
            else{
                //rotar la cápsula a la derecha
                rotDir = rot;
            }
        }

        if(!_interaction){
            estado = CharacterState.Idle;
            speedFR = 0;
            speedLR = 0;
            rotDir = 0;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Finish")){
            manager.silenceBackgroundMusic(true);
        }
        else if(other.collider.CompareTag("Ground")){
            onTheGround = true;
        }
    }
}
