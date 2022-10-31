namespace AdventOfCodeShared.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] RemoveAt<T>(this T[] arr, int index)
        {
            T[] newArray = new T[arr.Length - 1];

            int i = 0;
            int j = 0;
            while (i < arr.Length)
            {
                if (i != index)
                {
                    newArray[j] = arr[i];
                    j++;
                }

                i++;
            }

            return newArray;
        }

        public static T Pop<T>(this T[] arr)
        {
            T last = arr[arr.Length - 1];
            arr.RemoveAt(arr.Length - 1);
            return last;
        }

        public static T[] Add<T>(this T[] arr, params T[] items)
        {
            arr ??= System.Array.Empty<T>();

            // Join the arrays
            T[] result = new T[arr.Length + items.Length];
            arr.CopyTo(result, 0);
            items.CopyTo(result, arr.Length);
            return result;
        }

        public static T[] Add<T>(this T[] arr, T item)
        {
            arr ??= System.Array.Empty<T>();

            // Join the arrays
            T[] result = new T[arr.Length + 1];
            arr.CopyTo(result, 0);
            result[arr.Length] = item;
            return result;
        }

    }
}
