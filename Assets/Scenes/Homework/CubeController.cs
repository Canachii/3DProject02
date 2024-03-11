using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class CubeController : MonoBehaviour
{
    public float speed = 1.0f;

    private float _x;
    private float _z;
    private Vector3 _position;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _position = transform.position;
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Finish") &&
            GameManager.Instance.ItemCount >= GameManager.Instance.requireCoins)
        {
            GameManager.Instance.StageClear();
        }
        
        if (other.gameObject.CompareTag("Respawn"))
        {
            _position = other.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
            transform.position = _position + Vector3.up * 0.1f;
            transform.rotation = Quaternion.identity;
        }

        if (other.CompareTag("Item"))
        {
            Debug.Log("Item collected!");
            if (GameManager.Instance.itemCollectedSound)
                GameManager.Instance.audioSource.PlayOneShot(GameManager.Instance.itemCollectedSound);
            GameManager.Instance.ItemCount++;
            other.gameObject.SetActive(false);
        }

        GameManager.Instance.UpdateUI();
    }
}