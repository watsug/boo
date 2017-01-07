namespace Boo.Lang.Compiler.Util
{
    using System;

#if DNXCORE50
    public delegate TOutput Converter<in TInput, out TOutput>(TInput input);
#endif

    public class ArrayUtil
    {
        public static TOutput[] ConvertAll<TInput, TOutput>(TInput[] array, Converter<TInput, TOutput> converter)
        {
#if DNXCORE50
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (converter == null)
            {
                throw new ArgumentNullException("converter");
            }
            TOutput[] array2 = new TOutput[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array2[i] = converter(array[i]);
            }
            return array2;
        }
#else
        return Array.ConvertAll<TInput, TOutput>(array, converter);
#endif
    }
}