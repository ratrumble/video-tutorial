using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Vector3 _initialPosition;
    private bool _birdLaunched = false;
    private float _timeSat = 0;
    Vector3 _positionWhenClicked;

    [SerializeField] float forcePower = 600; //replaces 600 in OnMouseSetup()

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        if(_birdLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= .1)
        {
            _timeSat += Time.deltaTime;
        }

        if (transform.position.y > 50 || _timeSat > 5)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        if (transform.position.y < -50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (transform.position.x > 50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (transform.position.x < -50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnMouseDown()
    {
        _positionWhenClicked = transform.position;
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _positionWhenClicked - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition*forcePower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdLaunched = true;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }
}
