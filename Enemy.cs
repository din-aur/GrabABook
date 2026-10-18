using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LogicManager Logic;
    public int damageValue;
    public int pointToAdd;
    public int TextbookAmount;
    public int LunchboxAmount;
    public int MinimartAmount;
    void Start()
    {
        GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Player") || other.CompareTag("Deadzone") || other.CompareTag("Target"))
        {
            Destroy(this.gameObject);
        }
    }
}