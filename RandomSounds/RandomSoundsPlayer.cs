using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Cekay.RandomSounds
{
    public class RandomSoundsPlayer : UdonSharpBehaviour
    {
        [SerializeField] GameObject AudioObject;
        [SerializeField] AudioSource Audio;
        [SerializeField] AudioClip[] Clips;

        [SerializeField] int MaxX;
        [SerializeField] int MaxY;
        [SerializeField] int MaxZ;
        [SerializeField] int MinX;
        [SerializeField] int MinY;
        [SerializeField] int MinZ;
        [SerializeField] int Chance;
        [SerializeField] float NextEventDelay;

        private bool IsPlaying = false;

        void Start()
        {

        }

        private void Update()
        {
            if (IsPlaying == false)
            {
                int hit = Random.Range(0, Chance);

                if (hit == 0)
                {
                    AudioEvent();
                }
            }
        }

        private void AudioEvent()
        {
            IsPlaying = true;
            AudioObject.transform.position = new Vector3(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY), Random.Range(MinZ, MaxZ));
            Audio.pitch = Random.Range(0.8f, 1.2f);
            Audio.PlayOneShot(Clips[Random.Range(0, Clips.Length)]);
            SendCustomEventDelayedSeconds(nameof(ResetAudioEvent), NextEventDelay);
        }

        public void ResetAudioEvent()
        {
            IsPlaying = false;
        }
    }
}