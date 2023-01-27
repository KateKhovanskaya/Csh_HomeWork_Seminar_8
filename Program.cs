// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию
//элементы каждой строки двумерного массива
int[,] arr54= GetArray(4,3,0,10);
PrintArray(arr54);
Console.WriteLine();
//SortArr(arr54);
//PrintArray(arr54);
Console.WriteLine($"Минимальная сумма элементов в строке: {FindMinRow(arr54)}");

//-------Методы----------
int[,] GetArray(int m, int n, int minValue, int maxValue){
    int[,] result = new int[m,n];
    for(int i = 0; i < m; i++){
        for(int j = 0; j < n; j++){
            result[i,j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintArray(int[,] array){
    for(int i = 0; i < array.GetLength(0); i++){
        for(int j = 0; j < array.GetLength(1); j++){
            Console.Write($"{array[i,j]} ");
        }
        Console.WriteLine();
    }
}

void SortArr(int[,] arr){
    for(int i=0; i<arr.GetLength(0); i++){
        int sortSize=arr.GetLength(1)-1;
        while (sortSize>=1){
            for(int j=0; j<sortSize;j++){
                if(arr[i,j+1]>arr[i,j]){
                int temp=arr[i,j];
                    arr[i,j]=arr[i,j+1];
                    arr[i,j+1]=temp;
                }
            }
            sortSize--;
        }
    }
}

//Задача 56: Задайте прямоугольный двумерный массив. Напишите программу,
//которая будет находить строку с наименьшей суммой элементов.

int FindMinRow(int[,] arr){
    int minRow=0;
    int min=0;
    for(int j=0; j<arr.GetLength(1); j++){
        min+=arr[0,j];
    }
    for(int i=1; i<arr.GetLength(0); i++){
        int sum=0;
        for(int j=0; j<arr.GetLength(1); j++){
            sum+= arr[i,j];
        }
        if (sum<min){
            min=sum;
            minRow=i;
        }
    }
    return minRow+1;
}