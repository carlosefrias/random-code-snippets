import java.util.*;

class MatrixSpiralCopy {

static int[] spiralCopy(int[][] inputMatrix) {
    // your code goes here
    int[] result = new int[inputMatrix[0].length * inputMatrix.length];
    int startRow = 0;
    int startCol = 0;
    int lastCol = inputMatrix[0].length;
    int lastRow = inputMatrix.length;
    int indx = 0;

    while(startRow <= lastRow && startCol <= lastCol) {
        for(int col = startCol; col < lastCol; col++){
            result[indx++] = inputMatrix[startRow][col];
        }
        if(indx == result.length) break;
        for(int row = startRow+1; row < lastRow ; row++){
            result[indx++] = inputMatrix[row][lastCol-1];
        }
        if(indx == result.length) break;
        for(int col = lastCol - 2; col >= startCol ; col--){
            result[indx++] = inputMatrix[lastRow-1][col];
        }
        if(indx == result.length) break;
        for(int row = lastRow - 2; row > startRow; row--){
            result[indx++] = inputMatrix[row][startRow];
        }
        if(indx == result.length) break;
        startRow++;
        startCol++;
        lastRow--;
        lastCol--;
    }

    return result;
}

public static void main(String[] args) {
    // int[][] input = new int[][]{{1,2,3},{4,5,6},{7,8,9}};
    int[][] input = new int[][]{{1,2}};
    System.out.println(Arrays.toString(spiralCopy(input)));
}

}

/*
[[1,2]]
[1,2]
res[1,2] 1
row = 0
index = 2

first (7)
start = 1,1
end = 3,2
----------
next (13)
start = 2,2
end = 2,1

input:  inputMatrix  = [ [1,    2,   3,  4,   5],
                        [6,                  10],
                        [11,                 15],
                        [16,  17,  18,  19,  20] ]
                        
input:  inputMatrix  = [ [],
                        [,    7,   8,  9, ],
                        [,    12,  13,  14, ],
                        [,  ] ]                         

*/


//[[1,2]
// [3,4]]

//[1,2,4,3]
/*
Integer[] arr = new Integer[]{5,3,7,2};
Arrays.sort(arr, (a,b) -> (b-a));
System.out.println(Arrays.toString(arr));
*/