#include "Person.h"


Person::Person(std::string first, std::string last, 
    int yearsOld) : firstName(first), lastName(last), 
    age(yearsOld)
{
}

std::string Person::getName()
{
    return firstName + " " + lastName;
}