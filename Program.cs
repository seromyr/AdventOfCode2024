﻿// See https://aka.ms/new-console-template for more information

using AdventOfCode2024;

DayOne dayOneResult = new ("One", "Data/day-one-input.txt");
DayTwo dayTwoResult = new ("Two","Data/day-two-input.txt");
DayThree dayThreeResult = new ("Three","Data/day-three-input.txt");

Console.WriteLine("Hello, World!");
// dayOneResult.ShowResult();
// dayTwoResult.ShowResult();
dayThreeResult.ShowResult();
Console.ReadLine();