using UnityEngine;
using FMOD;
using FMOD.Studio;
using System.Collections.Generic;
using FMODUnity;

namespace Mir.Audio.MainMenu
{
    public class AudioManager : MonoBehaviour
    {
        private List<EventInstance> eventInstances;
        private List<StudioEventEmitter> eventEmitters;

        private EventInstance musicEventInstance;

        public static AudioManager instance { get; private set; }

        private void Awake()
        {
            if (instance != null)
            {
                UnityEngine.Debug.LogError("Found more than one Audio Manager in the scene.");
            }
            instance = this;

            eventEmitters = new List<StudioEventEmitter>();
            eventInstances = new List<EventInstance>();
        }

        private void Start()
        {
            InitializeMusic(MusicEvents.instance.music);
        }

        private void InitializeMusic(EventReference eventReference)
        {
            musicEventInstance = CreateEventInstance(eventReference);
            musicEventInstance.start();
        }

        public StudioEventEmitter InitializeEventEmitter(EventReference eventReference, GameObject emitterGameObject)
        {
            StudioEventEmitter emitter = emitterGameObject.GetComponent<StudioEventEmitter>();
            emitter.EventReference = eventReference;
            eventEmitters.Add(emitter);
            return emitter;
        }

        public EventInstance CreateEventInstance(EventReference eventReference)
        {
            EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
            eventInstances.Add(eventInstance);
            return eventInstance;
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
