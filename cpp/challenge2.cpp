// Create a program that will:

// Allow a user to input a number to iterate up to
// Allow the user to see all the dual primes, 
// and a list of the numbers that are NOT dual prime
// Use either a vector or a list and their inherent member functions
// to handle the data from the loop

#include<iostream>
#include<vector>

using namespace std;

bool is_prime(long &number)
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

vector<long> list_dual_less_than(long &number)
{
    vector<long> v = {};
    int previous = 0;
    for(long i = 2; i <= number; i++)
    {
        if(is_prime(i))
        {
            long next = i + 2;
            if(is_prime(next))
            {
                if(i != previous)
                    v.push_back(i);
                v.push_back(next);
                previous = next;
            }
        }
    }
    return v;
}

void display_vector(vector<long> &v)
{
    for(long n : v)
    {
        cout << n << endl;
    }
}

vector<long> non_dual_primes(vector<long> &dual_primes, long &number)
{
    vector<long> non_dual_primes = {};
    int pos = 0;
    for(long i = 2; i <= number; i++)
    {
        if(is_prime(i))
        {
            if(dual_primes.at(pos) != i)
            {
                non_dual_primes.push_back(i);
            }
            else
                pos++;
        }
    }
    return non_dual_primes;
}

int main()
{
    long number = 1024;
    vector<long> vec = list_dual_less_than(number);
    vector<long> ndp = non_dual_primes(vec, number);
    cout << "dual primes: " << endl;
    display_vector(vec);
    cout << "Non dual primes: " << endl;
    display_vector(ndp);
}