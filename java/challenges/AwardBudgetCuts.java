import java.io.*;
import java.util.*;

class AwardBudgetCuts {
  
  static double findGrantsCap(double[] grantsArray, double newBudget) {
    // your code goes here
    Arrays.sort(grantsArray);
    for(int i = 0; i < grantsArray.length / 2; i++)
    {
        double temp = grantsArray[i];
        grantsArray[i] = grantsArray[grantsArray.length - i - 1];
        grantsArray[grantsArray.length - i - 1] = temp;
    }
    double originalSum = 0;
    
    for(double element: grantsArray){
      originalSum += element;
    }
    /*
    [4,2] ,3
    
    */
    double val, currentSum, sum = 0;
    for(int i = 0; i < grantsArray.length; i++){
      val = grantsArray[i];
      sum += val;
      currentSum = originalSum - sum + val * (i + 1);
      if(currentSum <= newBudget){
        double leftOver = newBudget - currentSum;
        return val + leftOver/i;
      }
    }
    return newBudget / grantsArray.length; 
  }

  public static void main(String[] args) {
    double[] arr = new double[]{4,2};
    System.out.println(findGrantsCap(arr, 3));

  }

}