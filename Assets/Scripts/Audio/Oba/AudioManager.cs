using FMOD.Studio;
using FMODUnity;
using System.Collections.Generic;
using UnityEngine;

namespace Mir.Audio.Oba
{
    public class AudioManager : MonoBehaviour
    {
        private List<EventInstance> eventInstances;
        private List<StudioEventEmitter> eventEmitters;

        public static AudioManager instance { get; private set; }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Found more than one Audio Manager in the scene.");
            }
            instance = this;

            eventEmitters = new List<StudioEventEmitter>();
            eventInstances = new List<EventInstance>();
        }

        private void Start()
        {
            GameEventsManager.instance.onGamePause += PauseAllSounds;
            GameEventsManager.instance.onGameResume += ResuemeAllSounds;
        }

        public StudioEventEmitter InitializeEventEmitter(EventReference eventReference, GameObject emitterGameObject)
        {
            StudioEventEmitter eventEmitter = emitterGameObject.GetComponent<StudioEventEmitter>();
            eventEmitter.EventReference = eventReference;
            eventEmitters.Add(eventEmitter);
            return eventEmitter;
        }

        public EventInstance CreateEventInstance(EventReference sound)
        {
            EventInstance eventInstance = RuntimeManager.CreateInstance(sound);
            eventInstances.Add(eventInstance);
            return eventInstance;
        }

        private void PauseAllSounds()
        {
            foreach (EventInstance eventInstance in eventInstances)
            {
                eventInstance.setPaused(true);
            }
        }

        private void ResuemeAllSounds()
        {
            foreach (EventInstance eventInstance in eventInstances)
            {
                eventInstance.setPaused(false);
            }
        }

        public void CleanUp()
        {
            foreach (EventInstance eventInstance in eventInstances)
            {
                eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                eventInstance.release();
            }

            foreach (StudioEventEmitter emitter in eventEmitters)
            {
                emitter.Stop();
            }
        }

        private void OnDestroy()
        {
            CleanUp();
        }
    }
}