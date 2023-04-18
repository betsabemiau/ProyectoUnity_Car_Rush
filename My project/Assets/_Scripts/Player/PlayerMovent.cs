using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovent : MonoBehaviour
{
    Touch touch;
    Vector3 playerPos;
    [SerializeField] GameObject visuals;
    [SerializeField] GameObject particles;
    [SerializeField] Collider2D collider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            playerPos = Camera.main.ScreenToWorldPoint(touch.position);

            playerPos.x = Mathf.Clamp(playerPos.x, -5, 4.66f);
        }
        
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerPos.x, -3.25f), Time.deltaTime * 10f);
    }

    public void Die()
    {
        StartCoroutine(nameof(SlowDown));
    }

    IEnumerator SlowDown()
    {
        Time.timeScale = .3f;
        Instantiate(particles, transform.position, Quaternion.identity);
        collider.enabled = false;
        visuals.SetActive(false);

        yield return new WaitForSecondsRealtime(1.5f);

        Time.timeScale = 1;
        StartCoroutine(nameof(Restart));
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
