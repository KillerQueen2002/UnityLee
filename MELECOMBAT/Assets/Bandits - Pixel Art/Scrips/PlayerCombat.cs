using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;// xác dinh diem tan công ( AttackPoint )
    public float attackRange = 0.5f; // vùng tan công 
    public LayerMask enemyLayers; // Class ke thù 

    public int attackDamage = 20;

    public float attackRate = 2f; // ti le tan cong
    float nextAttackTime = 0f; // time tan cong tiep theo

    
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }

    void Attack()
    {
        // play an attack animation
        animator.SetTrigger("Attack");

        // detect anemies in range of attack
       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); 
        // thu thap tat ca các ??i t??ng mà vòng trong cham vào, luu chúng vào bien hitEnemies

        // dame them
        foreach(Collider2D enemy in hitEnemies)// lap lai mai khi gap 1 enemy trong hitEnemies
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage); // truy cap vao scrip Enemy va goi ham TakeDamage
        }
    }
     void OnDrawGizmosSelected()// bán kính circle attackPoint
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);// ve 1 cricle truc quan trong chinh sua
    }
}
