using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    
    [SerializeField] private Animator an;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private PlayerMovement pm;

    private int _currentState;
    private float _lock;
    private bool _landed;
    private bool _falling;

    private static readonly int _idle = Animator.StringToHash("PlayerIdle");
    private static readonly int _run = Animator.StringToHash("PlayerRun");
    private static readonly int _jump = Animator.StringToHash("PlayerJump");
    private static readonly int _fall = Animator.StringToHash("PlayerFall");
    private static readonly int _land = Animator.StringToHash("PlayerLand");
    private static readonly int _wallslide = Animator.StringToHash("PlayerWallSlide");
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Animations
        var state = GetState();

        if (state == _currentState)
        {
            return;
        }
        else
        {
            an.CrossFade(state, 0, 0);
            _currentState = state;
        }
    }
    
    private int GetState()
    {
        if (Time.time < _lock) return _currentState;

        if (pm.isWallSliding()) return _wallslide;
        if (pm.IsWallJumping()) return _jump;
        if (pm.IsDashing()) return LockState(_run, an.GetCurrentAnimatorStateInfo(_run).length);
        if (_landed) return LockState(_land, an.GetCurrentAnimatorStateInfo(_land).length + 0.2f);

        if (pm.IsGrounded()) return pm.GetHorizontal() == 0 ? _idle : _run;
        return rb.velocity.y > 0 ? _jump : _fall;

        int LockState(int s, float t)
        {
            _lock = Time.time + t;
            return s;
        }
    }
}
