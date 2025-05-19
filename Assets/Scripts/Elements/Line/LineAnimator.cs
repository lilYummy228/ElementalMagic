using UnityEngine;

namespace Elements.Line
{
    public class LineAnimator : MonoBehaviour
    {
        [SerializeField] private Texture[] _textures;
        [SerializeField] private float _fps = 30f;

        private float _fpsCounter;
        private int _animationStep;

        public void Animate(LineRenderer lineRenderer)
        {
            _fpsCounter += Time.deltaTime;

            if (_fpsCounter >= 1f / _fps)
            {
                _animationStep++;

                if (_animationStep == _textures.Length)
                    _animationStep = 0;

                lineRenderer.material.SetTexture("_MainTex", _textures[_animationStep]);

                _fpsCounter = 0f;
            }
        }
    }
}
