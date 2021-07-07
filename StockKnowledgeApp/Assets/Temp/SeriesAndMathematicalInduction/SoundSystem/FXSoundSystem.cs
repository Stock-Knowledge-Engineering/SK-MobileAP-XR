using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSoundSystem : SoundSystem
{

    protected new static FXSoundSystem _instance;
    public new static FXSoundSystem Instance { get { return _instance; } }



    // Start is called before the first frame update
    public override void Awake() {

        if (_instance == null) {
            _instance = this;
            audioSource = GetComponent<AudioSource>();
            OnStart();
        } else {
            Destroy(this.gameObject);
        }

    }

    public override void OnStart() {
        base.OnStart();
    }
}
