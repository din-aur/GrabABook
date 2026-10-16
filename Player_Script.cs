using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Player_Script : MonoBehaviour
{
    public float HorizontalSpeed = 12f;
    public bool UseXAxis = false;
    private float currentTilt;
    [SerializeField] private float smoothingSpeed = 25f;
    public Rigidbody2D PlayerRigidBody;
    private Vector2 screenBorder;
    private float halfBody;
    public LogicManager Logic;
    public bool PlayerIsAlive = true;
    void Start()
    {
        Input.gyro.enabled = true;

        if(SceneManager.GetActiveScene().name == "PlayMenu")
        {
            Time.timeScale = 0f;
        }
        GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        screenBorder = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
        halfBody = GetComponent<SpriteRenderer>().bounds.size.x/2;
    }
    void Update()
    {
        if(!PlayerIsAlive || Time.timeScale == 0f)
        {
            return;
        }
        float rawTilt = Mathf.Clamp(Input.gyro.gravity.x*2.5f,-1f,1f);
        if (Mathf.Abs(rawTilt) < 0.05f) rawTilt = 0f;
        currentTilt = Mathf.Lerp(currentTilt, rawTilt, Time.deltaTime * smoothingSpeed);
        transform.Translate(Vector2.right*currentTilt*HorizontalSpeed*Time.deltaTime);
        float xBorder = Mathf.Clamp(transform.position.x,(-screenBorder.x + halfBody),(screenBorder.x - halfBody));
        transform.position = new Vector3(xBorder,transform.position.y,transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") || collision.CompareTag("Target"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if(enemy != null)
            {
                if(collision.CompareTag("Target"))
                {
                    SonicManager.instance.PlaySound("GetTextbook");
                } else if(collision.CompareTag("Enemy"))
                {
                    SonicManager.instance.PlaySound("GetOthers");
                }
                Logic.TakeDamage(enemy.damageValue);
                Logic.addPoint(enemy.pointToAdd);
                Logic.addTextbookCount(enemy.TextbookAmount);
                Logic.addLunchboxCount(enemy.LunchboxAmount);
                Logic.addMinimartCount(enemy.MinimartAmount);
            }
        }
        if (LogicManager.Auras <= 0)
        {
            Logic.gameOver();
            PlayerIsAlive = false;
        }
    }
}