using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    public enum DogState
    {
        None = -1,
        Normal = 1,
        Angry = 2,
        MaxAngry = 3,

    }

    public GameObject Score;
    public DogState _state;
    public float _fillness = 0;
    [HideInInspector]
    public Dog _currentDog;
    public double _score;
    public Text _scoreText;

    [SerializeField] private Image HealthBar;

    private void Start()
    {
        _score = 0;
        _scoreText = Score.GetComponent<Text>();
    }
    //[SerializeField] private Image smile;
    // [SerializeField] private List<Sprite> smileList;

    //public Spirit(SpiritType type = SpiritType.None, float fillness = 0)
    //{
    //    _type = type;
    //    _fillness = fillness;
    //}

    //public void SetFillness(float newFillness)
    //{
    //    LeanTween.value(gameObject, _fillness, newFillness, 2f)
    //        .setOnUpdate((float val) => {
    //            HealthBar.fillAmount = val; 
    //        })
    //      .setOnComplete(() =>
    //      {
    //          CheckState(); // Set Smile
    //      });
    //}

    public void SetParametres(Dog currentDog)
    {
        if (currentDog != null)
        {
            _currentDog = currentDog;
            _fillness = _currentDog.fury;
            HealthBar.fillAmount = _fillness;
        _score += Time.deltaTime*2;
        Score.GetComponent<Text>().text = (Math.Truncate(_score)).ToString();
        }
        //_scoreText.text = (Math.Truncate(_score)).ToString();
        //CheckState();
    }

    private void CheckState()
    {
        //if (_fillness < 25)
        //{
        //    _state = DogState.Normal;
        //    if (smileList[3] != null)
        //        smile.sprite = smileList[0];
        //    else
        //        smile.color = Color.black;
        //}
        //else if (_fillness < 50)
        //{
        //    _state = DogState.Angry;
        //    if (smileList[3] != null)
        //        smile.sprite = smileList[1];
        //    else
        //        smile.color = Color.red;
        //}
        //      else
        //{
        //    _state = DogState.MaxAngry;
        //    if (smileList[2] != null)
        //        smile.sprite = smileList[2];
        //    else
        //        smile.color = Color.green;
        //}
    }
}
