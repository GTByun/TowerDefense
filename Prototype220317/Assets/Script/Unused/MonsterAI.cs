using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public float speedMagni;
    public float speed;
    private float synthSpeed;
    private float modular;
    
    enum MonsterMove
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }
    private MonsterMove move;

    public float Speed { set => speed = value; }

    private void Awake()
    {
        move = MonsterMove.Up;
    }

    private void OnEnable()
    {
        move = MonsterMove.Up;
        synthSpeed = speedMagni * speed;
    }

    

    private void Start()
    {
        modular = GameManager.gameManager.modular;
        transform.position = new Vector2(modular * -2, modular * -2);
    }

    private void Update()
    {
        if (GameManager.gameManager.GameOn) 
        {
            switch (move)
            {
                case MonsterMove.Left:
                    transform.Translate(synthSpeed * Time.deltaTime * Vector2.left);
                    break;
                case MonsterMove.Down:
                    transform.Translate(synthSpeed * Time.deltaTime * Vector2.down);
                    if (transform.position.y <= modular * -2)
                    {
                        transform.position = new Vector2(transform.position.x, modular * -2);
                        move = MonsterMove.Left;
                    }
                    break;
                case MonsterMove.Right:
                    transform.Translate(synthSpeed * Time.deltaTime * Vector2.right);
                    if (transform.position.x >= modular * 2)
                    {
                        transform.position = new Vector2(modular * 2, transform.position.y);
                        move = MonsterMove.Down;
                    }
                    break;
                case MonsterMove.Up:
                    transform.Translate(synthSpeed * Time.deltaTime * Vector2.up);
                    if (transform.position.y >= modular * 2)
                    {
                        transform.position = new Vector2(transform.position.x, modular * 2);
                        move = MonsterMove.Right;
                    }
                    break;
            }
        }
    }
}
