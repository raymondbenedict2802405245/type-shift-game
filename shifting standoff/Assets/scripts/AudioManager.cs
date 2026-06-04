using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    public AudioSource SFX;
    public AudioSource BGM;

    public AudioClip GunshotSFX;
    public AudioClip playerDmgSFX;
    public AudioClip enemyDmgSFX;
    public AudioClip typing;
    public AudioClip mainmenu;
    public AudioClip battlescene;


    private bool isGameOver = false;
    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    public void playLobbyBGM()
    {
        BGM.clip = mainmenu;
        BGM.Play();
    }

    public void playgameBGM()
    {
        BGM.clip = battlescene;
        BGM.Play();
    }

    public void stopgameBGM()
    {
        BGM.Stop();
    }
    
    
    public void playGunshot()
    {
        if (isGameOver) return;
        SFX.PlayOneShot(GunshotSFX);
    }

    public void playerDmg()
    {
        if (isGameOver) return;
        SFX.PlayOneShot(playerDmgSFX);
    }

    public void enemyDmg()
    {
        if (isGameOver) return;
        SFX.PlayOneShot(enemyDmgSFX);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
}
