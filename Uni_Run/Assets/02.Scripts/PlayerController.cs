using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerController�� �÷��̾� ĳ���ͷμ� Player ���� ������Ʈ�� ������
public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; // ��� �� ����� ����� Ŭ��
    public float jumpForce = 700f; // ���� ��

    private int jumpCount = 0; // ���� ���� Ƚ��
    private bool isGrounded = false; // �ٴڿ� ��Ҵ��� ��Ÿ��
    private bool isDead = false; // ��� ����
    public int health= 3;

    private Rigidbody2D playerRigidbody; // ����� ������ٵ� ������Ʈ
    private Animator animator; // ����� �ִϸ����� ������Ʈ
    private AudioSource playerAudio; // ����� ����� �ҽ� ������Ʈ


    private void Start()
        // �ʱ�ȭ
        // ���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update()
        // ����� �Է��� �����ϰ� �����ϴ� ó��
    {
        if(isDead)
        { //��� �� �� �̻� �������� �ʰ� ����
            return;
        }
        
        //���콺 ���� ��ư�� �������� && �ִ� ���� Ƚ��(2)�� �������� �ʾҴٸ�
        if(Input.GetMouseButtonDown(0) && jumpCount <2)
        {
            //���� Ƚ�� ����
            jumpCount++;
            //���� ������ �ӵ��� ���������� ����(0,0)�� ����
            playerRigidbody.velocity = Vector2.zero;
            //������ٵ� �������� ���ֱ�
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            //����� �ҽ� ���
            playerAudio.Play();
        }
        else if(Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y>0)
        {
            //���콺 ���ʹ�ư���� ���� ���� ���� && �ӵ��� y���� ������(���� �����)
            //���� �ӵ��� �������� ����
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        // �ִϸ������� Grounded �Ķ���͸� isGrounded ������ ����
        animator.SetBool("Grounded", isGrounded);

    }

    private void Die()
        // ��� ó��
    {
        // �ִϸ������� Die Ʈ���� �Ķ���͸� ��
        animator.SetTrigger("Die");
        // ����� �ҽ��� �Ҵ�� ����� Ŭ���� deathClip���� ����
        playerAudio.clip = deathClip;
        // ��� ȿ���� ���
        playerAudio.Play();

        // �ӵ��� ����(0,0)�� ����
        playerRigidbody.velocity = Vector2.zero;
        // ��� ���¸� true�� ����
        isDead = true;

        //���� �Ŵ����� ���ӿ��� ó�� ����
        GameManager.instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D other)
        // Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹�� ����
    {
        if (other.gameObject.tag == "Collect")
        {
            GameManager.instance.AddScore(1);
            other.gameObject.SetActive(false);
        }

        else if (other.tag == "Dead" && !isDead)
        {
            //�浹�� ������ �±װ� Dead�̸� ���� ������� �ʾҴٸ� Die()����
            health -= 1;
            if(health == 0)
            { Die(); }
        }
        else if(other.tag == "Death")
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
        // �ٴڿ� ������� �����ϴ� ó��
    {
        // � �ݶ��̴��� �������, �浹 ǥ���� ������ ���� ������
        if(collision.contacts[0].normal.y>0.7f)
        {
            //isGrounded�� true�� �����ϰ�, ���� ���� Ƚ���� 0���� ����
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
        // �ٴڿ��� ������� �����ϴ� ó��
    {
        //� �ݶ��̴����� ������ ��� isGrounded�� false�� ����
        isGrounded = false;
    }
}
