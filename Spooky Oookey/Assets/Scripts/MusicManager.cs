using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public int MAX_PUMPKINS = 8;

    int numPumpkins = 0;

    public GameObject calmMusic;
    public GameObject intenseMusic;

    AudioSource calm;
    AudioSource intense;

    float MAX_VOLUME = 0.5f;

    float crossfadeTarget = 0f;

    float crossfade = 0f;
    float crossfadeIncrementStepSize = 0.0001f;

    private void Start()
    {
        EventManager.OnPumpkinGrows += IncrementTotalPumpkins;
        numPumpkins = 0;

        calm = calmMusic.GetComponent<AudioSource>();
        intense = intenseMusic.GetComponent<AudioSource>();

        calm.Play();
        intense.Play();

        UpdateAudioCrossfade();
    }

    private void Update()
    {
        if (crossfade != crossfadeTarget)
        {
            float crossfadeDiff = crossfadeTarget - crossfade; 
            if (Mathf.Abs(crossfadeDiff) < crossfadeIncrementStepSize)
            {
                crossfade = crossfadeTarget;
            }
            else
            {
                crossfade += Mathf.Sign(crossfadeDiff) * crossfadeIncrementStepSize;
            }
        }

        calm.volume = MAX_VOLUME * (1 - crossfade);
        intense.volume = MAX_VOLUME * crossfade;
    }

    void IncrementTotalPumpkins()
    {
        numPumpkins += 1;
        UpdateAudioCrossfade();
    }

    void UpdateAudioCrossfade()
    {
        crossfadeTarget = Mathf.Min((float)numPumpkins / (float)MAX_PUMPKINS, 1f);
    }
}
