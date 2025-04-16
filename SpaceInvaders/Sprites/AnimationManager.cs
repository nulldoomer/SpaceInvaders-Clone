using Microsoft.Xna.Framework;

namespace SpaceInvaders.Sprites
{
    internal class AnimationManager
    {
        private readonly int _numFrames;
        private readonly int _numColumns;
        private readonly Vector2 _size;

        private int _counter;
        private int _activeFrame;
        private readonly int _interval;

        private int _rowPos;
        private int _colPos;
        public AnimationManager(int numFrames, int numColumns, Vector2 size)
        {
            _numFrames = numFrames;
            _numColumns = numColumns;
            _size = size;
            _counter = 0;
            _activeFrame = 0;
            _interval = 30;
            _rowPos = 0;
            _colPos = 0;
        }

        public void Update()
        {
            _counter++;
            if (_counter <= _interval) return;
            _counter = 0;
            NextFrame();
        }

        private void NextFrame()
        {
            _activeFrame++;
            _colPos++;
            if (_activeFrame >= _numFrames)
            {
                ResetAnimation();
            }
            
            if (_colPos < _numColumns) return;
            _colPos = 0;
            _rowPos++;
        }

        private void ResetAnimation()
        {
            _activeFrame = 0;
            _colPos = 0;
            _rowPos = 0;
        }

        public Rectangle GetFrame()
        {
            return new Rectangle(
                _colPos * (int)_size.X,
                _rowPos * (int)_size.Y,
                (int)_size.X,
                (int)_size.Y
                );
        }
    }
}
