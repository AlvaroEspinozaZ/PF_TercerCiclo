using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourC : MonoBehaviour
{
    [Header("Component References")]
    public Animator playerAnimator;

    //Animation String IDs
    private int playerMovementAnimationID;
    private int playerAttackAnimationID;

    public void UpdateMovementAnimation(float movementBlendValue)
    {
        playerAnimator.SetFloat("Movement", movementBlendValue);
    }
    public void PlayAttackAnimation1()
    {
        playerAnimator.SetTrigger("Attack");
    }
    public void PlayAttackAnimation2()
    {
        playerAnimator.SetTrigger("Attack2");
    }
    public void EnemyAttackAnimation()
    {
        playerAnimator.SetTrigger("AttackEnemy");
    }
    public void PlayShootAnimation()
    {
        playerAnimator.SetTrigger("ShootWea");
    }
    public void PlayTumbarseAnimation()
    {
        playerAnimator.SetTrigger("Tumbarse");
    }
    public void PlayJumpAnimation()
    {
        playerAnimator.SetTrigger("Jump");
    }
    public void PlayReciveDEne1Animation()
    {
        playerAnimator.SetTrigger("ReciveDEne1");
    }
    public void PlayReciveDEne2Animation()
    {
        playerAnimator.SetTrigger("ReciveDEne2");
    }
    public void PlayReciveDPlayerAnimation()
    {
        playerAnimator.SetTrigger("ReciveDPlayer");
    }
    public void PlayDeadPlayerAnimation()
    {
        playerAnimator.SetTrigger("DeadPlayer");
    }
    public void PlayDeadEnemyAnimation()
    {
        playerAnimator.SetTrigger("DeadEnemy");
    }
}
