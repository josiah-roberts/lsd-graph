namespace LSD
{
    class MatrixArray<T>
    {
        private T[] array;
        public int Size { get; private set; }
        public MatrixArray(int size)
        {   
            Size = size;
            array = new T[(size * (size - 1)) / 2];
        }

        public T this[int x, int y]
        {
            get
            {
                if (x > y)
                    return array[y + (x * (x + 1) / 2)];

                return array[x + (y * (y + 1) / 2)];
            }
            set
            {
                if (x > y)
                    array[y + (x * (x + 1) / 2)] = value;
                else
                    array[x + (y * (y + 1) / 2)] = value;
            }
        }
    }
}
