using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class CubeController : MonoBehaviour
{
    public float speed = 1.0f;

    private float _x;
    private float _z;
    private Rigidbody _rb;
    
private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        _x = Input.GetAxisRaw("Horizontal");
        _z = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_x, _rb.velocity.y, _z) * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish") && GameManager.Instance.Items >= GameManager.Instance.requireCoins)
        {
            Debug.Log("Stage Clear!");
            GameManager.Instance.Items = 0;
            GameManager.Score += 10000;
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            GameManager.Instance.Items = 0;
            GameManager.Deaths++;
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.CompareTag("Item"))
        {
            Debug.Log("Item collected!");
            GameManager.Instance.Items++;
            Destroy(other.gameObject);
        }
    
        GameManager.Instance.UpdateUI();
    }
}