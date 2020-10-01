using System;
using System.Threading;

namespace Panel_Persian
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            string myText = "سلام رکسانا سلام";
            
            int matrixWidth = 0;
            foreach (char item in myText)
                if (item == 'ا' || item == 'آ')
                    matrixWidth += 5;
                else if (item == ' ')
                    matrixWidth += 6;
                else
                    matrixWidth += 12;

            if (matrixWidth < 100)
                throw new Exception("String too long.");
            char[,] matrix = new char[13, matrixWidth];
            int currentWidth = matrixWidth - 1;
            bool isFirstLetter = false;

            for(int i = 0; i < myText.Length - 1; i++)
            {
                if (i == 0 || 
                    myText[i - 1] == ' ' || 
                    myText[i - 1] == 'ا' ||
                    myText[i - 1] == 'د' ||
                    myText[i - 1] == 'ذ' ||
                    myText[i - 1] == 'ر' ||
                    myText[i - 1] == 'ز' ||
                    myText[i - 1] == 'ژ' ||
                    myText[i - 1] == 'و')
                    isFirstLetter = true;
                else
                    isFirstLetter = false;

                if (myText[i] == ' ')
                {
                    currentWidth -= 6;
                    continue;
                }

                if (myText[i + 1] == ' ')
                    CapiitalCaseMatrixSet(ref matrix, ref currentWidth, myText[i], isFirstLetter);
                else
                    LowerCaseMatrixSet(ref matrix, ref currentWidth, myText[i], isFirstLetter);
            }

            if (myText[myText.Length - 2 ] == ' ' ||
                myText[myText.Length - 2 ] == 'ا' ||
                myText[myText.Length - 2 ] == 'د' ||
                myText[myText.Length - 2 ] == 'ذ' ||
                myText[myText.Length - 2 ] == 'ر' ||
                myText[myText.Length - 2 ] == 'ز' ||
                myText[myText.Length - 2] == 'ژ' ||
                myText[myText.Length - 2] == 'و')
                isFirstLetter = true;
            else
                isFirstLetter = false;
            CapiitalCaseMatrixSet(ref matrix, ref currentWidth, myText[myText.Length - 1], isFirstLetter);

            while (true)
            {
                int windowWidth = 100;
                int startIndex = matrixWidth - windowWidth;
                int endIndex = matrixWidth - 1;

                for (int i = 1; i <= windowWidth; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    for (int j = 0; j <= 12; j++)
                    {
                        string result = "";
                        for (int k = startIndex + (endIndex - startIndex - i + 1); k <= endIndex; k++)
                            result = result + matrix[j, k];
                        Console.WriteLine(result);
                    }
                    Thread.Sleep(10);
                    Console.Clear();
                }
                while (true)
                {
                    startIndex = startIndex - 1;
                    endIndex = endIndex - 1;
                    if (startIndex < 0)
                        break;

                    Console.WriteLine();
                    Console.WriteLine();
                    for (int j = 0; j <= 12; j++)
                    {
                        string result = "";
                        for (int k = startIndex; k <= endIndex; k++)
                            result = result + matrix[j, k];
                        Console.WriteLine(result);
                    }
                    Thread.Sleep(10);
                    Console.Clear();
                }

                for(int i = 1; i <= 100; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    for (int j = 0; j <= 12; j++)
                    {
                        string result = "";
                        for (int l = 1; l <= i; l++)
                            result = result + ' ';
                        for (int k = 0; k <= endIndex - i + 1; k++)
                            result = result + matrix[j, k];
                        Console.WriteLine(result);
                    }
                    Thread.Sleep(10);
                    Console.Clear();
                }
            }
        }

        private static void LowerCaseMatrixSet(ref char[,] matrix, ref int currentWidth, char v, bool isFirstLetter)
        {
            switch(v)
            {
                #region آ
                case 'آ':
                    matrix[0, currentWidth] = '@';
                    matrix[1, currentWidth] = '@';
                    currentWidth--;
                    matrix[1, currentWidth] = '@';
                    currentWidth--;
                    for(int i = 1; i <= 9; i++)
                    {
                        if (i == 2)
                            continue;
                        matrix[i, currentWidth] = '@';
                    }
                    currentWidth--;
                    matrix[1, currentWidth] = '@';
                    currentWidth--;
                    matrix[1, currentWidth] = '@';
                    matrix[2, currentWidth] = '@';
                    currentWidth--;
                    break;
                #endregion
                #region الف
                case 'ا':
                    for (int i = 0; i < 10; i++)
                        matrix[i , currentWidth] = '@';
                    currentWidth -= 5;
                    break;
                #endregion
                #region ب
                case 'ب':
                    //matrix[6, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i<= 11; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        if (i == 5)
                            matrix[11, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region پ
                case 'پ':
                    //matrix[6, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 11; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        if (i == 5)
                            matrix[11, currentWidth] = '@';
                        if (i == 6)
                            matrix[12, currentWidth] = '@';
                        if (i == 7)
                            matrix[11, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ت
                case 'ت':
                    matrix[7, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 11; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        if (i == 6)
                            matrix[5, currentWidth] = '@';
                        if (i == 8)
                            matrix[5, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ث
                case 'ث':
                    //matrix[6, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 11; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        if (i == 5)
                            matrix[5, currentWidth] = '@';
                        if (i == 6)
                            matrix[4, currentWidth] = '@';
                        if (i == 7)
                            matrix[5, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ج
                case 'ج':
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 7; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        if(i == 1)
                            matrix[11, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region چ
                case 'چ':
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 7; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        if (i == 1)
                            matrix[11, currentWidth] = '@';
                        if (i == 2)
                            matrix[12, currentWidth] = '@';
                        if (i == 3)
                            matrix[11, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ح
                case 'ح':
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 7; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region خ
                case 'خ':
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    matrix[4, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 7; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region د
                case 'د':
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    matrix[8, currentWidth] = '@';
                    matrix[10, currentWidth] = '@';
                    currentWidth--;
                    matrix[7, currentWidth] = '@';
                    matrix[11, currentWidth] = '@';
                    currentWidth--;
                    matrix[6, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 8; i++)
                        currentWidth--;
                    break;
                #endregion
                #region ذ
                case 'ذ':
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    matrix[8, currentWidth] = '@';
                    matrix[10, currentWidth] = '@';
                    currentWidth--;
                    matrix[7, currentWidth] = '@';
                    matrix[11, currentWidth] = '@';
                    currentWidth--;
                    matrix[6, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    matrix[4, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 8; i++)
                        currentWidth--;
                    break;
                #endregion
                #region ر
                case 'ر':
                    matrix[9, currentWidth] = '@';
                    matrix[10, currentWidth] = '@';
                    matrix[11, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    for(int i = 1; i <= 6; i++)
                    {
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    for (int i = 1; i <= 5; i++)
                        currentWidth--;
                    break;
                #endregion
                #region ز
                case 'ز':
                    matrix[9, currentWidth] = '@';
                    matrix[10, currentWidth] = '@';
                    matrix[11, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    for (int i = 1; i <= 6; i++)
                    {
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    for (int i = 1; i <= 5; i++)
                        currentWidth--;
                    break;
                #endregion
                #region ژ
                case 'ژ':
                    matrix[9, currentWidth] = '@';
                    matrix[10, currentWidth] = '@';
                    matrix[11, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    for (int i = 1; i <= 6; i++)
                    {
                        matrix[12, currentWidth] = '@';
                        if (i == 2)
                            matrix[6, currentWidth] = '@';
                        if (i == 3)
                            matrix[7, currentWidth] = '@';
                        currentWidth--;
                    }
                    for (int i = 1; i <= 5; i++)
                        currentWidth--;
                    break;
                #endregion
                #region س
                case 'س':
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 2; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 2; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 5; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ش
                case 'ش':
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    matrix[4, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 2; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        if(i == 1)
                            matrix[3, currentWidth] = '@';
                        if (i == 2)
                            matrix[4, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 2; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 5; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ص
                case 'ص':
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 3; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 3; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 3; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ض
                case 'ض':
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 3; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        if (i == 1)
                            matrix[5, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 3; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 3; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ط
                case 'ط':
                    for(int i = 9; i >= 6; i--)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 9; i >= 2; i--)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 5; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ظ
                case 'ظ':
                    for (int i = 9; i >= 6; i--)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    matrix[4, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 9; i >= 2; i--)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 5; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ع
                case 'ع':
                    if(isFirstLetter)
                    {
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[8, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        currentWidth--;
                        for (int i = 1; i <= 6; i++)
                        {
                            matrix[9, currentWidth] = '@';
                            currentWidth--;
                        }
                    }
                    else
                    {
                        for(int i = 1; i <= 2; i++)
                        {
                            matrix[9, currentWidth] = '@';
                            currentWidth--;
                        }
                        matrix[9, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[8, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[8, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        currentWidth--;
                        for (int i = 1; i <= 3; i++)
                        {
                            matrix[9, currentWidth] = '@';
                            currentWidth--;
                        }
                    }
                    break;
                #endregion
                #region غ
                case 'غ':
                    if (isFirstLetter)
                    {
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[4, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[8, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        currentWidth--;
                        for (int i = 1; i <= 6; i++)
                        {
                            matrix[9, currentWidth] = '@';
                            currentWidth--;
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= 2; i++)
                        {
                            matrix[9, currentWidth] = '@';
                            currentWidth--;
                        }
                        matrix[9, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[8, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[4, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[8, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        currentWidth--;
                        for (int i = 1; i <= 3; i++)
                        {
                            matrix[9, currentWidth] = '@';
                            currentWidth--;
                        }
                    }
                    break;
                #endregion
                #region ف
                case 'ف':
                    for(int i = 9; i >= 5; i--)
                        matrix[i, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    currentWidth--;
                    for(int i = 1; i <= 3; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[5, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    for (int i = 7; i >= 5; i--)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 7; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ق
                case 'ق':
                    for (int i = 9; i >= 5; i--)
                        matrix[i, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 3; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[5, currentWidth] = '@';
                        if (i == 2)
                            matrix[3, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    for (int i = 7; i >= 5; i--)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 7; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ک
                case 'ک':
                    matrix[9, currentWidth] = '@';
                    matrix[1, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[2, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    matrix[4, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 7; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region گ
                case 'گ':
                    matrix[9, currentWidth] = '@';
                    matrix[1, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[2, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    matrix[1, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    matrix[4, currentWidth] = '@';
                    matrix[2, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 7; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ل
                case 'ل': 
                    for(int i = 9; i >= 0; i--)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for(int i = 1; i <= 11; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region م
                case 'م': 
                    for(int i = 9; i <= 12; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for(int i = 1; i <= 3; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    for (int i = 9; i <= 12; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for(int i = 1; i <= 7; i ++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ن
                case 'ن':
                    //matrix[6, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 11; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region و
                case 'و': 
                    for (int i = 7; i <= 12; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    matrix[7, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    currentWidth--;
                    matrix[7, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    currentWidth--;
                    matrix[7, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    currentWidth--;
                    for(int i = 7; i <= 9; i++)
                        matrix[i, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    currentWidth--;
                    for(int i = 1; i <= 4; i++)
                    {
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    for (int i = 1; i <= 3; i++)
                        currentWidth--;
                    break;
                #endregion
                #region ه
                case 'ه':
                    for (int i = 7; i <= 11; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for(int i = 1; i <= 3; i++)
                    {
                        matrix[7, currentWidth] = '@';
                        matrix[9, currentWidth] = '@';
                        matrix[11, currentWidth] = '@';
                        currentWidth--;
                    }
                    for (int i = 7; i <= 11; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for(int i = 1; i <= 7; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ی
                case 'ی':
                    matrix[7, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 11; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        if (i == 6 || i == 4)
                            matrix[11, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
            }
        }

        private static void CapiitalCaseMatrixSet(ref char[,] matrix, ref int currentWidth, char v, bool isFirstLetter)
        {
            switch (v)
            {
                #region آ
                case 'آ':
                    matrix[0, currentWidth] = '@';
                    matrix[1, currentWidth] = '@';
                    currentWidth--;
                    matrix[1, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 9; i++)
                    {
                        if (i == 2)
                            continue;
                        matrix[i, currentWidth] = '@';
                    }
                    currentWidth--;
                    matrix[1, currentWidth] = '@';
                    currentWidth--;
                    matrix[1, currentWidth] = '@';
                    matrix[2, currentWidth] = '@';
                    currentWidth--;
                    break;
                #endregion
                #region الف
                case 'ا':
                    for (int i = 0; i < 10; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth -= 5;
                    break;
                #endregion
                #region ب
                case 'ب':
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 9; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        if (i == 5)
                            matrix[11, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    currentWidth--;
                    break;
                #endregion
                #region پ
                case 'پ':
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 9; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        if (i == 5 || i == 7)
                            matrix[11, currentWidth] = '@';
                        if (i == 6)
                            matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    currentWidth--;
                    break;
                #endregion
                #region ت
                case 'ت':
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 9; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        if (i == 4 || i == 6)
                            matrix[5, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    currentWidth--;
                    break;
                #endregion
                #region ث
                case 'ث':
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 9; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        if (i == 5 || i == 7)
                            matrix[5, currentWidth] = '@';
                        if (i == 6)
                            matrix[4, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    break;
                #endregion
                #region ج
                case 'ج':
                    matrix[10, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    currentWidth--;
                    matrix[11, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[4, currentWidth] = '@';
                    currentWidth--;

                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    currentWidth--;
                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[2, currentWidth] = '@';
                    currentWidth--;
                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[1, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    currentWidth--;
                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[2, currentWidth] = '@';
                    currentWidth--;
                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    currentWidth--;

                    matrix[11, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    currentWidth--;
                    matrix[10, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 8; i <= 9; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth -= 3;
                    break;
                #endregion
                #region چ
                case 'چ':
                    matrix[10, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    currentWidth--;
                    matrix[11, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[4, currentWidth] = '@';
                    currentWidth--;

                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    currentWidth--;
                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[2, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[1, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    currentWidth--;
                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[2, currentWidth] = '@';
                    currentWidth--;
                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    currentWidth--;

                    matrix[11, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    currentWidth--;
                    matrix[10, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 8; i <= 9; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth -= 3;
                    break;
                #endregion
                #region ح
                case 'ح':
                    matrix[10, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    currentWidth--;
                    matrix[11, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[4, currentWidth] = '@';
                    currentWidth--;

                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    currentWidth--;
                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[2, currentWidth] = '@';
                    currentWidth--;
                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[1, currentWidth] = '@';
                    currentWidth--;
                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[2, currentWidth] = '@';
                    currentWidth--;
                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    currentWidth--;

                    matrix[11, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    currentWidth--;
                    matrix[10, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 8; i <= 9; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth -= 3;
                    break;
                #endregion
                #region خ
                case 'خ':
                    matrix[10, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    currentWidth--;
                    matrix[11, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[4, currentWidth] = '@';
                    currentWidth--;

                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    currentWidth--;
                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[2, currentWidth] = '@';
                    currentWidth--;
                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[1, currentWidth] = '@';
                    matrix[0, currentWidth] = '@';
                    currentWidth--;
                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[2, currentWidth] = '@';
                    currentWidth--;
                    matrix[12, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    currentWidth--;

                    matrix[11, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    currentWidth--;
                    matrix[10, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 8; i <= 9; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth -= 3;
                    break;
                #endregion
                #region د
                case 'د':
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    matrix[8, currentWidth] = '@';
                    matrix[10, currentWidth] = '@';
                    currentWidth--;
                    matrix[7, currentWidth] = '@';
                    matrix[11, currentWidth] = '@';
                    currentWidth--;
                    matrix[6, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 8; i++)
                        currentWidth--;
                    break;
                #endregion
                #region ذ
                case 'ذ':
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    matrix[8, currentWidth] = '@';
                    matrix[10, currentWidth] = '@';
                    currentWidth--;
                    matrix[7, currentWidth] = '@';
                    matrix[11, currentWidth] = '@';
                    currentWidth--;
                    matrix[6, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    matrix[4, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 8; i++)
                        currentWidth--;
                    break;
                #endregion
                #region ر
                case 'ر':
                    matrix[9, currentWidth] = '@';
                    matrix[10, currentWidth] = '@';
                    matrix[11, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    for (int i = 1; i <= 6; i++)
                    {
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    for (int i = 1; i <= 5; i++)
                        currentWidth--;
                    break;
                #endregion
                #region ز
                case 'ز':
                    matrix[9, currentWidth] = '@';
                    matrix[10, currentWidth] = '@';
                    matrix[11, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    for (int i = 1; i <= 6; i++)
                    {
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    for (int i = 1; i <= 5; i++)
                        currentWidth--;
                    break;
                #endregion
                #region ژ
                case 'ژ':
                    matrix[9, currentWidth] = '@';
                    matrix[10, currentWidth] = '@';
                    matrix[11, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    for (int i = 1; i <= 6; i++)
                    {
                        matrix[12, currentWidth] = '@';
                        if (i == 2)
                            matrix[6, currentWidth] = '@';
                        if (i == 3)
                            matrix[7, currentWidth] = '@';
                        currentWidth--;
                    }
                    for (int i = 1; i <= 5; i++)
                        currentWidth--;
                    break;
                #endregion
                #region س
                case 'س':
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 2; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 2; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    matrix[10, currentWidth] = '@';
                    matrix[11, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 3; i++)
                    {
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    matrix[10, currentWidth] = '@';
                    matrix[11, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    currentWidth--;
                    break;
                #endregion
                #region ش
                case 'ش':
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;

                    matrix[9, currentWidth] = '@';
                    matrix[4, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    currentWidth--;

                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 2; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    matrix[10, currentWidth] = '@';
                    matrix[11, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 3; i++)
                    {
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    matrix[10, currentWidth] = '@';
                    matrix[11, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    //matrix[6, currentWidth] = '@';
                    currentWidth--;
                    currentWidth--;
                    break;
                #endregion
                #region ص
                case 'ص':
                    matrix[7, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    matrix[7, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    matrix[8, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 7; i <= 12; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 5; i++)
                    {
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    for (int i = 7; i <= 12; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    currentWidth--;
                    break;
                #endregion
                #region ض
                case 'ض':
                    matrix[7, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    currentWidth--;
                    matrix[7, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    matrix[8, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 7; i <= 12; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 5; i++)
                    {
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    for (int i = 7; i <= 12; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    currentWidth--;
                    break;
                #endregion
                #region ط
                case 'ط':
                    for (int i = 9; i >= 6; i--)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 9; i >= 2; i--)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 5; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ظ
                case 'ظ':
                    for (int i = 9; i >= 6; i--)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    matrix[4, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 9; i >= 2; i--)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 5; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ع
                case 'ع':
                    if (isFirstLetter)
                    {
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[8, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        for (int i = 1; i <= 5; i++)
                        {
                            matrix[9, currentWidth] = '@';
                            matrix[12, currentWidth] = '@';
                            currentWidth--;
                        }
                        for(int i = 9; i <= 12; i++)
                            matrix[i, currentWidth] = '@';
                        currentWidth--;
                    }
                    else
                    {
                        for (int i = 1; i <= 2; i++)
                        {
                            matrix[9, currentWidth] = '@';
                            matrix[12, currentWidth] = '@';
                            currentWidth--;
                        }
                        matrix[9, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[8, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[8, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        for (int i = 1; i <= 2; i++)
                        {
                            matrix[9, currentWidth] = '@';
                            matrix[12, currentWidth] = '@';
                            currentWidth--;
                        }
                        for(int i = 9; i <=12; i++)
                            matrix[i, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region غ
                case 'غ':
                    if (isFirstLetter)
                    {
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        matrix[5, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[8, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        for (int i = 1; i <= 5; i++)
                        {
                            matrix[9, currentWidth] = '@';
                            matrix[12, currentWidth] = '@';
                            currentWidth--;
                        }
                        for (int i = 9; i <= 12; i++)
                            matrix[i, currentWidth] = '@';
                        currentWidth--;
                    }
                    else
                    {
                        for (int i = 1; i <= 2; i++)
                        {
                            matrix[9, currentWidth] = '@';
                            matrix[12, currentWidth] = '@';
                            currentWidth--;
                        }
                        matrix[9, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[8, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        matrix[4, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[8, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                        for (int i = 1; i <= 2; i++)
                        {
                            matrix[9, currentWidth] = '@';
                            matrix[12, currentWidth] = '@';
                            currentWidth--;
                        }
                        for (int i = 9; i <= 12; i++)
                            matrix[i, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ف
                case 'ف':
                    for (int i = 9; i >= 5; i--)
                        matrix[i, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 3; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[5, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    for (int i = 7; i >= 5; i--)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 6; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    break;
                #endregion
                #region ق
                case 'ق':
                    for(int i = 7; i <= 12; i++)
                        matrix[i, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    currentWidth--;
                    for(int i = 1; i <= 3; i++)
                    {
                        matrix[7, currentWidth] = '@';
                        matrix[9, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        if (i == 2)
                            matrix[5, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[7, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    currentWidth--;
                    for(int i = 1; i <= 6; i++)
                    {
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    for(int i = 9; i <= 12; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    break;
                #endregion
                #region ک
                case 'ک':
                    matrix[9, currentWidth] = '@';
                    matrix[1, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[2, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    matrix[4, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 6; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    break;
                #endregion
                #region گ
                case 'گ':
                    matrix[9, currentWidth] = '@';
                    matrix[1, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[2, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    matrix[1, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[6, currentWidth] = '@';
                    matrix[4, currentWidth] = '@';
                    matrix[2, currentWidth] = '@';
                    currentWidth--;
                    matrix[9, currentWidth] = '@';
                    matrix[5, currentWidth] = '@';
                    matrix[3, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 6; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[8, currentWidth] = '@';
                    matrix[7, currentWidth] = '@';
                    currentWidth--;
                    break;
                #endregion
                #region ل
                case 'ل': 
                    for(int i = 0; i <= 12; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for(int i = 1; i <= 10; i++)
                    {
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    for (int i = 9; i <= 12; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    break;
                #endregion
                #region م
                case 'م':
                    for (int i = 9; i <= 12; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 3; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    for (int i = 9; i <= 12; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 6; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        currentWidth--;
                    }
                    matrix[9, currentWidth] = '@';
                    matrix[10, currentWidth] = '@';
                    matrix[11, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    currentWidth--;
                    break;
                #endregion
                #region ن
                case 'ن': 
                    for(int i = 9; i <= 12; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    for(int i = 1; i <= 10; i++)
                    {
                        matrix[12, currentWidth] = '@';
                        if(i == 5)
                            matrix[7, currentWidth] = '@';
                        currentWidth--;
                    }
                    for (int i = 9; i <= 12; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    break;
                #endregion
                #region و
                case 'و':
                    for (int i = 7; i <= 12; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    matrix[7, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    currentWidth--;
                    matrix[7, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    currentWidth--;
                    matrix[7, currentWidth] = '@';
                    matrix[9, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 7; i <= 9; i++)
                        matrix[i, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    currentWidth--;
                    for (int i = 1; i <= 4; i++)
                    {
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    for (int i = 1; i <= 3; i++)
                        currentWidth--;
                    break;
                #endregion
                #region ه
                case 'ه': 
                    if(isFirstLetter)
                    {
                        currentWidth -= 2;

                        matrix[9, currentWidth] = '@';
                        matrix[8, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[5, currentWidth] = '@';
                        currentWidth--;

                        matrix[9, currentWidth] = '@';
                        matrix[5, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        currentWidth--;
                        matrix[9, currentWidth] = '@';
                        matrix[8, currentWidth] = '@';
                        currentWidth--;

                        currentWidth -= 2;
                    }
                    else
                    {
                        for(int i = 1; i <= 6; i++)
                        {
                            matrix[9, currentWidth] = '@';
                            currentWidth--;
                        }
                        matrix[9, currentWidth] = '@';
                        matrix[8, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[5, currentWidth] = '@';
                        currentWidth--;
                        for(int i = 1; i <= 4; i++)
                        {
                            matrix[5, currentWidth] = '@';
                            matrix[7, currentWidth] = '@';
                            currentWidth--;
                        }
                        matrix[5, currentWidth] = '@';
                        matrix[6, currentWidth] = '@';
                        matrix[7, currentWidth] = '@';
                        currentWidth--;
                    }
                    break;
                #endregion
                #region ی
                case 'ی':
                    matrix[9, currentWidth] = '@';
                    matrix[10, currentWidth] = '@';
                    matrix[11, currentWidth] = '@';
                    matrix[12, currentWidth] = '@';
                    currentWidth--;

                    for (int i = 1; i <= 4; i++)
                    {
                        matrix[9, currentWidth] = '@';
                        matrix[10, currentWidth] = '@';
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    for(int i = 1; i <= 6; i++)
                    {
                        matrix[12, currentWidth] = '@';
                        currentWidth--;
                    }
                    for(int i = 9; i <=12; i++)
                        matrix[i, currentWidth] = '@';
                    currentWidth--;
                    break;
                #endregion
            }
        }
    }
}
