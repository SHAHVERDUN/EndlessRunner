using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private float _velocityModyfier;

    private RawImage _rawImage;

    private float _imageUVPositionX;

    private void Start()
    {
        _rawImage = GetComponent<RawImage>();
    }

    private void Update()
    {
        SetImageUVPosition();
    }

    private void SetImageUVPosition()
    {
        _imageUVPositionX += Time.deltaTime * _velocityModyfier;

        if (_imageUVPositionX >= 1)
        {
            _imageUVPositionX = 0;
        }

        _rawImage.uvRect = new Rect(_imageUVPositionX, 0, _rawImage.uvRect.width, _rawImage.uvRect.height);
    }
}