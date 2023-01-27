// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию
//элементы каждой строки двумерного массива
//int[,] arr54= GetArray(3,4,0,10);
// 
//SortArr(arr54);int[,] arr1= GetArray(2,2,0,10);
// int[,] arr2= GetArray(2,2,0,10);
// PrintArray(arr1);
// Console.WriteLine();
// PrintArray(arr2);
// Console.WriteLine();
// int[,] matricesProduct=MatricesProduct(arr1, arr2);
// PrintArray(matricesProduct);
//PrintArray(arr54);
//Console.WriteLine($"Минимальная сумма элементов в строке: {FindMinRow(arr54)}");
// int[,] spiral=Spiral(6,6);
// PrintArray1(spiral);
int[,,] arr3D60 = GetArray3D(2,2,2);
PrintArray3D(arr3D60);
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

void PrintArray1(int[,] array){
    for(int i = 0; i < array.GetLength(0); i++){
        for(int j = 0; j < array.GetLength(1); j++){
            Console.Write(string.Format("{0:d2}",array[i,j])+" ");
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

//Задача 58: Задайте две матрицы. Напишите программу, которая будет находить
//произведение двух матриц.
int[,] MatricesProduct(int[,] arr1, int[,] arr2){
    int[,] resultArr= new int[arr1.GetLength(0), arr1.GetLength(1)];
    for(int i=0; i<resultArr.GetLength(0); i++){
        for(int j=0; j<resultArr.GetLength(1); j++){
            for(int k=0; k<resultArr.GetLength(0); k++){
                resultArr[i,j]+=arr1[i,k]*arr2[k,j];
            }
        }
    }
    return resultArr;
}

//Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
int[,] Spiral(int row, int column){
    int[,] rezult=new int[row, column];
    int napravlenie=1;
    int rowStart=0;
    int rowEnd=row-1;
    int columnStart=0;
    int columnEnd=column-1;
    int count=1;
    while(count<= row*column){
        if(napravlenie==1){
            for(int j=columnStart; j<=columnEnd; j++){
                rezult[rowStart, j]=count;
                count++;
            }
            rowStart+=1;
            napravlenie=2;
        }
        if(count>row*column) return rezult;
        if(napravlenie==2){
            for(int i=rowStart; i<=rowEnd; i++){
                rezult[i,columnEnd]=count;
                count++;
            }
            columnEnd-=1;
            napravlenie=3;
        }
        if(count>row*column) return rezult;
        if(napravlenie==3){
            for(int j=columnEnd; j>=columnStart; j--){
                rezult[rowEnd,j]=count;
                count++;
            }
            rowEnd-=1;
            napravlenie=4;
        }
        if(count>row*column) return rezult;
        if(napravlenie==4){
            for(int i=rowEnd; i>=rowStart; i--){
                rezult[i, columnStart]=count;
                count++;
            }
            columnStart+=1;
            napravlenie=1;
        }
        if(count>row*column) return rezult;
    }
    return rezult;
}

//Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
//Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого
//элемента.

bool IsNumberInArr(int number, int[,,] arr3D){
    for(int i=0; i< arr3D.GetLength(0); i++){
        for(int j=0; j<arr3D.GetLength(1); j++){
            for(int k=0; k<arr3D.GetLength(1); k++){
                if(arr3D[i,j,k]==number) return true;
            }
        }
    }
    return false;
}

int[,,] GetArray3D(int m, int n, int k){
    int[,,] rezultArr=new int[m,n,k];
    for(int i=0; i< rezultArr.GetLength(0); i++){
        for(int j=0; j<rezultArr.GetLength(1); j++){
            for(int l=0; l<rezultArr.GetLength(2); l++){
                int nextNum=new Random().Next(10, 100);
                while(IsNumberInArr(nextNum, rezultArr)){
                    nextNum=new Random().Next(10, 100);
                }
                rezultArr[i,j,l]=nextNum;
            }
        }
    }
    return rezultArr;
}

void PrintArray3D(int[,,] array3D){
    for(int i=0; i< array3D.GetLength(0); i++){
        for(int j=0; j<array3D.GetLength(1); j++){
            for(int k=0; k<array3D.GetLength(2); k++){
                Console.Write($"{array3D[i,j,k]} ({i}, {j}, {k}) ");
            }
            Console.WriteLine();
        }
    }
}