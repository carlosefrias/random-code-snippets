/*
Given an age in seconds, calculate how old someone would be on:

Mercury: orbital period 0.2408467 Earth years
Venus: orbital period 0.61519726 Earth years
Earth: orbital period 1.0 Earth years, 365.25 Earth days, or 31557600 seconds
Mars: orbital period 1.8808158 Earth years
Jupiter: orbital period 11.862615 Earth years
Saturn: orbital period 29.447498 Earth years
Uranus: orbital period 84.016846 Earth years
Neptune: orbital period 164.79132 Earth years
So if you were told someone were 1,000,000,000 seconds old, you should be able to say that they're 31.69 Earth-years old.
*/

#include <iostream>
const double mercury = 0.2408467;
const double venus = 0.61519726;
const double earth = 1.0;
const double mars = 1.8808158;
const double jupiter = 11.862615;
const double saturn = 29.447498;
const double uranus = 84.016846;
const double neptune = 164.79132;

const double seconds_in_a_year = 31558118.4; //365.256*24*60*60

double how_old(long seconds, std::string planet){
    auto years_on_earth = seconds / seconds_in_a_year;
    if (planet == "mercury")
        return years_on_earth / mercury;
    else if (planet == "venus")
        return years_on_earth / venus;
    else if (planet == "earth")
        return years_on_earth;
    else if (planet == "mars")
        return years_on_earth / mars;
    else if (planet == "jupiter")
        return years_on_earth / jupiter;
    else if (planet == "saturn")
        return years_on_earth / saturn;
    else if (planet == "uranus")
        return years_on_earth / uranus;
    else if (planet == "neptune")
        return years_on_earth / neptune;
    else
        return -1.0;
}

int main(){
    std::cout << how_old(1000000000, "neptune") << std::endl;
    return 0;
}