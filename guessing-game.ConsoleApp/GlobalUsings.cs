// These below are implicit in modern .NET
// (On a console application) (Kinda bad practice)
//
// System is a namespace (So does this file)
// using System; (uses System namespace)
// Namespaces are just organizational labels inside your code
// (which the purpose is to store types)
//
// Files without declared namespaces still belong to the
// global namespace
//
// Those are sub-namespaces (They are not inclusive)
// (They need to be imported independently)
//
// System.Collections.Generic;
// System.IO;
// System.Linq;
// System.Net.Http;
// System.Threading;
// System.Threading.Tasks;
//
// A GlobalUsings.cs file containing all namespaces being used
// on your project is a good practice
//
global using System;
global using System.Security.Cryptography;
global using System.Threading;
