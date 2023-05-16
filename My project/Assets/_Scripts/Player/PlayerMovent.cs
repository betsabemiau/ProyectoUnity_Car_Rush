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
    [SerializeField] AudioClip kaboomClip;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject perdisteUI;
    [SerializeField] ScoreManager scoreManager;

    [SerializeField] Sprite defaultSprite;

    // Start is called before the first frame update
    void Start()
    {
        visuals.GetComponent<SpriteRenderer>().sprite = GlobalVariables.currentSprite ? GlobalVariables.currentSprite : defaultSprite;
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
        audioSource.clip = kaboomClip;
        audioSource.Play();
        scoreManager.contadorActivo = false;
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
        perdisteUI.SetActive(true);
        // TODO Aparecer Ui de restart
        //
        // Esto Reinicia
        //SceneManager.LoadScene(0);
    }
}
