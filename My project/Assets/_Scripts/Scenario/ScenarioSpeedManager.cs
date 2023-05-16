using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioSpeedManager : MonoBehaviour
{
    int _timeNextSpeedUp = 10;
    [SerializeField] float baseCarSpeed;
    [SerializeField] float baseScenarioSpeed;
    [SerializeField] float multiplier;

    float targetScenario;
    float targetCar;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(SpeedUp), _timeNextSpeedUp);

        GlobalVariables.CarSpeed = baseCarSpeed;
        GlobalVariables.scenarioSpeed = baseScenarioSpeed;
        GlobalVariables.phase = 0;
    }
    private void SpeedUp()
    {
        _timeNextSpeedUp--;

        StartCoroutine(nameof(SmoothChange));

        if (_timeNextSpeedUp >= 8)
            Invoke(nameof(SpeedUp), _timeNextSpeedUp);
    }

    IEnumerator SmoothChange()
    {
        targetScenario = GlobalVariables.scenarioSpeed * multiplier;
        targetCar = GlobalVariables.CarSpeed * multiplier;
        
        yield return new WaitUntil(CanContinue);
    }

    private bool CanContinue()
    {

        GlobalVariables.scenarioSpeed = Mathf.Lerp(GlobalVariables.scenarioSpeed, targetScenario, Time.deltaTime);
        GlobalVariables.CarSpeed = Mathf.Lerp(GlobalVariables.CarSpeed, targetCar, Time.deltaTime);

        if (targetScenario - GlobalVariables.scenarioSpeed < 0.1f)
        {
            GlobalVariables.scenarioSpeed = targetScenario;
            GlobalVariables.CarSpeed = targetCar;
            GlobalVariables.phase++;
            return true;
        }

        return false;
    }
}