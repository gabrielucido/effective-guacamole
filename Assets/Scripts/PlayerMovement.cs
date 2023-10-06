using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   public Rigidbody2D _rigidBody {get; private set; }
    
    public Animator _animator;
    
    public SpriteRenderer _spriteRenderer;
    public PlayerInputHandler _playerInputHandler {get; private set; }

    private PlayerStateMachine _playerStateMachine;

    public bool isDying = false;

    public bool isSittingClassroom = false;

    public bool isSittingOffice = false;

    public bool canDetect = false;

    [SerializeField] public float speed;


    public Vector2 lastDirection;

    private Vector2 moveDirection;

    public Vector2 currentDirection;
   
   public GameObject visualCue;

   public GameObject targetFraseDisplay;

   public GameObject officeUI;

   public GameObject letterPlacement;

    private Vector2 _currentSpeed; 

    private Vector2 _workspace;
    public IEnumerator coroutine;
    void Awake()
    {
       _animator = GetComponent<Animator>();
       _rigidBody = GetComponent<Rigidbody2D>();
       _playerInputHandler = GetComponent<PlayerInputHandler>(); 
       _playerStateMachine = new PlayerStateMachine();
       _playerStateMachine.Add((int)PlayerStatesEnum._IDLE_, new IdlePlayerState(_playerStateMachine,this,"Idle"));
       _playerStateMachine.Add((int)PlayerStatesEnum._MOVING_X, new MovingPlayerState(_playerStateMachine,this,"Moving"));
       _playerStateMachine.Add((int)PlayerStatesEnum._MOVING_Y, new MovingPlayerState(_playerStateMachine,this,"Moving"));
       _playerStateMachine.Add((int)PlayerStatesEnum._DYING_,new DyingPlayerState(_playerStateMachine,this,"Dying"));
       _playerStateMachine.Add((int)PlayerStatesEnum._SITTING_CLASSROOM, new SittingPlayerState(_playerStateMachine,this,"SittingClassroom"));
       _playerStateMachine.Add((int)PlayerStatesEnum._SITTING_OFFICE,new SittingPlayerState(_playerStateMachine,this,"SittingOffice"));
       _playerStateMachine.SetCurrentState(_playerStateMachine.GetState((int)PlayerStatesEnum._IDLE_));
    }

    void Start()
    {
        visualCue.SetActive(false);
    }

    void Update()
    {

        Animate();
        _playerStateMachine.Update();

    }

    
    void FixedUpdate()
    {   
          _playerStateMachine.FixedUpdate();
    }

    public void Move(Vector2 dir)
    {
        lastDirection = dir;
        currentDirection = _playerInputHandler.movementInput;
        _workspace.Set(dir.x * speed * 5f, dir.y * speed * 5f);
        _rigidBody.velocity = _workspace;
        _currentSpeed = _workspace;       
    }

 

    public void Animate()
    {
        _animator.SetFloat("MoveX", _playerInputHandler.movementInput.x);
        _animator.SetFloat("MoveY",_playerInputHandler.movementInput.y);
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Chair"))
        {

            visualCue.SetActive(true);
             if (visualCue == true && _playerInputHandler.DidInteract())
            {
                
                gameObject.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y);
               
            }   
             
            gameObject.transform.position = new Vector2(other.gameObject.transform.position.x,other.gameObject.transform.position.y);
        }
         if(other.gameObject.CompareTag("OfficeChair"))
        {
            visualCue.SetActive(true);
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
            if (visualCue == true && _playerInputHandler.DidInteract())
            {
                letterPlacement.SetActive(true);
                gameObject.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y);
                targetFraseDisplay.SetActive(true);
                officeUI.SetActive(true);   
                visualCue.SetActive(false);
            }

            if(_playerInputHandler.DidLeave())
            {
                
                targetFraseDisplay.SetActive(false);
            }   
    }
    public void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Chair"))
        {
            isSittingClassroom = false;
            visualCue.SetActive(false);
        }

        if(other.gameObject.CompareTag("OfficeChair"))
        {
            isSittingOffice = false;
            visualCue.SetActive(false);
        }
    }
}
