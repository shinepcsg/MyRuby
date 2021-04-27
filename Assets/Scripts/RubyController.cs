using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 5f;

    public int maxHealth = 5;
    public int currentHealth;
    public int Health { get { return currentHealth; } }

    Rigidbody2D rigidbody2d;


    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }


    void Update()
    {
        //Input -> 모르는 클래스 등장 "Unity Input"검색(네이버 검색보다 구글 검색)
        // 매뉴얼 페이지 확인, 엄청 많은 API중 한개 -> 많은 API를 모두 외울 수 없다. 
        // 사전 처럼 그때 그때 필요한것들을 참고해서 개발하자 -> 샘플 코드만 보고 적용.
        // 예상한바로 작동안하면 매뉴얼 정독
        // https://docs.unity3d.com/kr/current/ScriptReference/Input.html 
        // https://docs.unity3d.com/kr/530/ScriptReference/Input.html

        //Input.GetKey      // 키를 누르고 있을때 
        //Input.GetKeyDown  // 키를 눌렀을때
        //Input.GetKeyUp    // 누른 키를 땠을때
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Debug.Log("숫자 1을 눌렀다");


        float horizontal = 0;
        float vertical = 0;

        // 방법1이나 2중 한개만 있으면 됨.
        // 방법1 : 축 이용방법 ( Project setting -> Input Manager Axis에 값을 등록하여 사용, 에디터 설정도 참고하여야 해서 불편
        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");

        // 방법 2 : 키코드를 직접 입력하여 키입력 감지. 부드러운 움직임 제거
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            horizontal = -1;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            horizontal = 1;


        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            vertical = 1;

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            vertical = -1;
        //방법 2 끝.

       //Debug.Log(horizontal);

       Vector2 position = rigidbody2d.position;
        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;
        rigidbody2d.MovePosition(position);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
