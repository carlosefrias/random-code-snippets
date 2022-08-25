//each year which is an integer multiple of 4 (except for years evenly divisible by 100, but not by 400)
#include <iostream>

bool is_leap_year(long year){
    bool isMultipleOf4 = year % 4 == 0;
    bool isDivisibleBy100 = year % 100 == 0;
    bool isDivisibleBy400 = year % 400 == 0;
    
    if(isMultipleOf4 && !isDivisibleBy100)
        return true;
    else if(isDivisibleBy400)
        return true;
    else return false;
}

int main(){
    std::cout << is_leap_year(1997) << std::endl;
}