/*
Instructions

Determine if a triangle is equilateral, isosceles, or scalene.

An equilateral triangle has all three sides the same length.

An isosceles triangle has at least two sides the same length. (It is sometimes specified as having exactly two sides the same length, but for the purposes of this exercise we'll say at least two.)

A scalene triangle has all sides of different lengths.
Note

For a shape to be a triangle at all, all sides have to be of length > 0, and the sum of the lengths of any two sides must be greater than or equal to the length of the third side. See Triangle Inequality.
Dig Deeper

The case where the sum of the lengths of two sides equals that of the third is known as a degenerate triangle - it has zero area and looks like a single line. Feel free to add your own code/tests to check for degenerate triangles.
*/

#include<iostream>

std::string check_type(double side1, double side2, double side3){
    double max_side = std::max(side1, side2); max_side = std::max(max_side, side3);
    double sum_other_sides = side1 + side2 + side3 - max_side;
    if(sum_other_sides < max_side)
        return "invalid triangle";
    if (sum_other_sides == max_side)
        return "degenerate triangle";
    if(side1 == side2 && side2 == side3)
        return "equilateral";
    if( (side1 == side2 && side2 != side3) ||
        (side1 == side3 && side1 != side2) ||
        (side2 == side3 && side1 != side2))
        return "isosceles";
    return "scalene";
}

int main(){
    std::cout << check_type(2,2,2) << std::endl;
    return 0;
}