using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowCurrentDate : MonoBehaviour
{
  public Text currentDateText;
  public ObservableDate currentDate;

  void Start() {
    // this.currentDate = Birthday;
    this.currentDateText.text = DateTime.Today.ToString();
  }

  void Update() {
    this.currentDateText.text = "Current Date: " + this.currentDate.Value().ToString("yyyy-MM-dd");
  }
}
