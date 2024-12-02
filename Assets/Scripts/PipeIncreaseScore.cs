using UnityEngine;

public class PipeIncreaseScore : MonoBehaviour
{
    AudioSource _scoreSound;

    private void Start()
    {
        _scoreSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!_scoreSound.isPlaying)
            {
                _scoreSound.Play();
            }
            
            Score.instance.UpdateScore();
        }
    }
}
