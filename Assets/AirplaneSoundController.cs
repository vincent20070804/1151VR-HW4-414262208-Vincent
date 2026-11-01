using UnityEngine;

public class AirplaneSoundController : MonoBehaviour
{
    [Header("音效設定")]
    public AudioClip jetEngineSound; // 飛行時音效 (jet-engine.wav)
    public AudioClip crushSound;     // 撞到障礙物音效 (crush.wav)
    public AudioClip successSound;   // 成功飛過音效 (success.wav)

    private AudioSource audioSource;

    void Start()
    {
        // 取得飛機身上的 AudioSource 元件
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 遊戲開始時播放飛行引擎音效 (設定為循環播放)
        if (jetEngineSound != null)
        {
            audioSource.clip = jetEngineSound;
            audioSource.loop = true; 
            audioSource.Play();
        }
    }

    // 1. 當碰到障礙物時 (實體碰撞)
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("撞到障礙物！播放 crush.wav");
            if (crushSound != null)
            {
                audioSource.PlayOneShot(crushSound);
            }
        }
    }

    // 2. 當成功飛過障礙物/閘門時 (觸發器)
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoalGate"))
        {
            Debug.Log("成功飛過障礙物！播放 success.wav");
            if (successSound != null)
            {
                audioSource.PlayOneShot(successSound);
            }
        }
    }
}