using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExplanationText : MonoBehaviour
{
    private TextMeshProUGUI _explanationText;

    void Awake()
    {
        _explanationText = GetComponent<TextMeshProUGUI>();
    }

	private void OnEnable()
	{
		Managers.VisualizationState.VisualizationStateChanged += UpdateExplanationTextToNewState;
		Managers.Vectors.OperationChanged += UpdateExplanationTextToNewOperation;
	}

	private void OnDisable()
	{
		Managers.VisualizationState.VisualizationStateChanged -= UpdateExplanationTextToNewState;
		Managers.Vectors.OperationChanged -= UpdateExplanationTextToNewOperation;
	}

	private void UpdateExplanationTextToNewState(eVisualizationState newState)
	{
		switch (newState)
		{
			case eVisualizationState.VectorOperations:
				_explanationText.text = Explanations.ExplanationByVectorOperation[Managers.Vectors.VectorOperation.operation];
				break;
			case eVisualizationState.MatrixTransformations:
				_explanationText.text = Explanations.MatrixTransformationExplanation;
				break;
		}
	}

	private void UpdateExplanationTextToNewOperation()
	{
		eVectorOperations operation = Managers.Vectors.VectorOperation.operation;
		_explanationText.text = Explanations.ExplanationByVectorOperation[operation];
	}
}
