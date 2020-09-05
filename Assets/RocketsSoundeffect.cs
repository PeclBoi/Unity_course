using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Assets {

    class RocketsSoundeffect : MonoBehaviour {
        AudioSource audioSource;

        public RocketsSoundeffect(AudioSource audioSource) {
            this.audioSource = audioSource;
        }

        public void StartThrustSoundeffect() {
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        }

        public void StopThrustSoundeffect() {
            if (audioSource.isPlaying) {
                audioSource.Stop();
            }
        }


    }
}
