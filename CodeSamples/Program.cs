using CodeSamples.Design_Patterns._TestPatterns;
using CodeSamples.Design_Patterns.Middleware;
using CodeSamples.Test;
using System;

Tester t = new();
t.MakeTea();

await t.MakeTeaAsync();

