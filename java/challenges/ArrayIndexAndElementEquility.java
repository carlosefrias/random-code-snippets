public class ArrayIndexAndElementEquility{
  
  static int binarySearch(int[] arr, int start, int end){
    if(start == end && arr[start] == start) 
        return start;
    if(start > end) 
        return -1;
    int midIndx = start + (end - start) / 2;
    int val = arr[midIndx];
    
    if(val > midIndx){
        return binarySearch(arr, start, midIndx -1);
    }else if(val < midIndx){
        return binarySearch(arr, midIndx+1, end);
    }
    else{
        return binarySearch(arr, start, midIndx);
    }
  }
  
  static int indexEqualsValueSearch(int[] arr) {
    if(arr.length>100)
        return -1;
    return binarySearch(arr, 0, arr.length-1);
  }

  public static void main(String[] args) {
    int[] arr=new int[]{-2,-1,1,3,10};
    // int[] arr=new int[]{0,1,2,3,4};
    System.out.println(indexEqualsValueSearch(arr));
  }
}
