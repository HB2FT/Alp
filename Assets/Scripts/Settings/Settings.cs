using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        SavedState savedState = Load();

        audioSource.volume = savedState.volume;

        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        Save();
    }

    void Update()
    {
        
    }

    SavedState Load()
    {

        SavedState savedState = null;

        try
        {
            using(FileStream fileStream = new FileStream(".settings", FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new();
                savedState = (SavedState)binaryFormatter.Deserialize(fileStream);
            }
        }
        catch (SerializationException e)
        {
            Debug.LogException(e);
        }

        return savedState;
    }

    public void Save()
    {
        float volume = audioSource.volume;
        bool isFullscreen = true;

        SavedState savedState = new SavedState(volume, isFullscreen);

        try
        {
            using (FileStream fileStream = new (".settings", FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, savedState);
            }
        }
        catch (SerializationException e)
        {
            Debug.LogException(e);
        }
    }

    [Serializable]
    class SavedState
    {
        public float volume;
        public bool isFullscreen;

        public SavedState(float volume, bool isFullscreen)
        {
            this.volume = volume;
            this.isFullscreen = isFullscreen;
        }
    }
}
