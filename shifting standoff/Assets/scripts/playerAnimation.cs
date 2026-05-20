using UnityEditor;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    [SerializeField] private MonoScript Difficulty;
    [SerializeField] public Animator animator;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ShootGun()
    {
        animator.ResetTrigger("Attack");
        animator.SetTrigger("Attack");
    }

    
}




