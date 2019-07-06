// Prime problem:

// Create a program that will:

// Allow a user to input a number
// Allow the user to see if the number is prime or not
// If the number is not prime, tell the user what number it is divisible by
// Use a function to process whether or not the value is prime (this idea will be used in a future challenge
// Use double or Long for increased number length

#include<iostream>
using namespace std;

bool is_prime(long number)
{
    bool is_prime = true;
    long divisor = 2;
    while(is_prime && divisor < int(number / 2) + 1)
    {
        is_prime = !(number % divisor == 0);
        divisor++;
    }
    return is_prime;
}

long first_divisor(long number)
{
    for(int i = 2; i < int(number / 2) + 1; i++)
    {
        if (number % i == 0)
            return i;
    }
    return number;
}

long * get_all_divisors(long number)
{
    long* list;
    list = (long*) malloc(number * sizeof(long));  //memory allocated using malloc
    list[0] = 1;
    list[1] = 1;
    int pos = 2;
    for(int i = 2; i < (int) (number / 2) + 1; i++)
    {
        if(number % i == 0)
            list[pos++] = i;
    }
    list[pos++] = number;
    list[0] = pos;
    return list;
}

void display_divisors(long * list)
{
    long n = list[0];
    for(long i = 1; i < n; i++)
    {
        cout << list[i] << endl;
    }
}

int main()
{
    bool exit_program = false;
    while(!exit_program)
    {
        cout << "To exit the program please introduce the number 0" << endl;
        cout << "This program checks if a number is prime" << endl;
        cout << "Please insert a number to check" << endl;
        long number;
        cin >> number;
        if(number == 0) 
        {
            exit_program = true;
            cout << "Closing the program" << endl;
            break;
        }
        else if (!(number > 0 && number != 1))
        {
            cout << "Please introduce a positive whole number different than 1" << endl;
        }
        else
        {
            bool prime = is_prime(number);
            string answer = prime ? " is prime" : " is not prime";
            cout << number << answer << endl;
            if(!prime)
            {
                cout << "The smallest divisor of " << number << ", not counting 1, is " << first_divisor(number) << endl;
                cout << "All divisors of " << number << " are: " << endl;
                display_divisors(get_all_divisors(number));
            }
        }
    }
    return 0;
}