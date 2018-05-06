using System;

namespace Queue
{
    public class Queue<T>
    {
        private int _currentPosition;
        private readonly T[] _mas;

        public Queue(int len)
        {
            _currentPosition = -1;
            _mas = new T[len];
        }

        public void Put(T element)
        {
            if (_currentPosition >= _mas.Length-1)
                throw new InvalidOperationException();

            _currentPosition++;
            _mas[_currentPosition] = element;
        }

        public T Get()
        {
            if(_currentPosition<0)
                throw new InvalidOperationException();

            var res = _mas[0];
            for (var i=0; i < _currentPosition; i++)
            {
                _mas[i] = _mas[i + 1];
            }
            _currentPosition--;
            return res;
        }

    }
}