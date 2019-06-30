// Problem: calculate the persistence of a number
// The persistence of a number is the number os times it's digits can be multiplied
// until we get a one digit number

#include <iostream>
#include <stdio.h>
#define MAX_NUMBER_DIGITS 50
using namespace std;


bool is_one_digit(long number)
{
    char str [MAX_NUMBER_DIGITS];
    int n = sprintf (str, "%ld", number);
    return n == 1;
}

long product_digits(long number)
{
    char str [MAX_NUMBER_DIGITS];
    int n = sprintf (str, "%ld", number);
    long product = 1;
    for(int i = 0; i < n; ++i)
    {
        product *= (int) str[i] - (int)'0'; 
    }
    return product;
}

int persistence(long number)
{
    //TODO: Check argument type
    int persistence = 0;
    while(!is_one_digit(number))
    {
        number = product_digits(number); 
        cout << number << endl;
        persistence++;
    }
    return persistence;
}

int main() 
{
    long val = 227777778;
    int per = persistence(val);
    cout << "the persistence of " << val << " is " << per << endl;
    return 0;
}