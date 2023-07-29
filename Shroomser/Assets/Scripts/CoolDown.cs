using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class CoolDown : MonoBehaviour
{
    public Transform CoolDownUIPos;
    public GameObject coolDownUIMainGO;
    public Image FillAmountImage;
    float Timer;
    float _timerInside;
    public UnityEvent EventAfterCD;
    public static CoolDown Instance;
    public Movement movenent;
    Camera cam;

    public Button actionBtn;

    AudioSource sound;

    void Start()
    {
        Instance = this;
        cam = Camera.main;
        coolDownUIMainGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer > 0)
        {
            movenent.Animator.SetBool("Search", true);
            coolDownUIMainGO.SetActive(true);
            if(CoolDownUIPos != null)
                coolDownUIMainGO.transform.position = cam.WorldToScreenPoint(CoolDownUIPos.position);
            _timerInside += Time.deltaTime;
            FillAmountImage.fillAmount = _timerInside / Timer;
            if (_timerInside >= Timer)
            {
                if(sound != null)
                {
                    sound.Stop();
                    sound = null;
                }
                Timer = 0;
                _timerInside = 0;
                coolDownUIMainGO.SetActive(false);
                Movement.instance.IncreaceSpeed(100);

                actionBtn.interactable = true;
                if (EventAfterCD != null)
                    EventAfterCD.Invoke();
                EventAfterCD.RemoveAllListeners();
                movenent.Animator.SetBool("Search", false);
            }
        }
    }
    public void SetCD(float time, UnityAction Listener)
    {
        EventAfterCD.RemoveAllListeners();

        Timer = time;

        actionBtn.interactable = false;
        Movement.instance.DecreaceSpeed(100);
        EventAfterCD.AddListener(delegate { Listener(); });

    }
    public void SetCD(float time, UnityAction Listener, AudioSource sound)
    {

        SetCD(time, Listener);
        this.sound = sound;
        if (this.sound != null)
            this.sound.Play();
    }

}
