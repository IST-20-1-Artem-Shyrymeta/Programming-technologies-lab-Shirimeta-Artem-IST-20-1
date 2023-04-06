using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
 public float speed = 5f;
 public float jumpForce = 12f;
 public float distanceToGround;
 public LayerMask groundMask;
 private Rigidbody2D rb;
 private Animator anim;
 private float horizontal;
 private bool facingRight;
 private bool grounded;
 void Start()
 {
 //ініціалізація компонентів
 rb = GetComponent<Rigidbody2D>();
 anim = GetComponent<Animator>();
 }
 void FixedUpdate()
 {
 //вхідні дані про переміщення вліво-вправо
 horizontal = Input.GetAxis("Horizontal");
 //анімація ходьби
 anim.SetFloat("Move", Mathf.Abs(horizontal));
 //перевірка чи персонаж стоїть на землі
 CheckGround();
 //зміна напрямку персонажа
 if (horizontal > 0 && facingRight || horizontal < 0 && !facingRight)
 Flip();
 //анімація ударів
 if (Input.GetMouseButtonDown(0))
 anim.SetTrigger("Punch");
 if (Input.GetMouseButtonDown(1))
 anim.SetTrigger("Kick");
 //реалізація стрибку та його анімації
 if (Input.GetKeyDown(KeyCode.Space) && grounded)
 Jump();
 //анімація приземлення після стрибку
 if (rb.velocity.y < 0)
 anim.SetBool("Jump", false);
 //переміщення персонажа вліво-вправо
 if (horizontal != 0)
 Move();
 }
 private void CheckGround()
 {
 grounded = Physics2D.Raycast(rb.position, Vector3.down, distanceToGround,
groundMask);
 }
 private void Jump()
 {
 rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
 anim.SetBool("Jump", true);
 }
 private void Move()
 {
 rb.velocity = new Vector3(horizontal * speed, rb.velocity.y);
 Vector3 position = rb.position;
 position.x = Mathf.Clamp(position.x, -5, 6);
 rb.position = position;
 }
 private void Flip()
 {
 facingRight = !facingRight;
 transform.Rotate(0, 180, 0);
 }
}
