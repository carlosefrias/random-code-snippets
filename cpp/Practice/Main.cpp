#include<iostream>
#include "Person.h"

int main() 
{
    Person p1("John", "Snow", 26), p2("Carlos", "Frias", 39);

    std::string name = p1.getName();

    std::cout << name << std::endl;

    return 0;
}