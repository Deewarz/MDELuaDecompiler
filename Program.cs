﻿

using luadec.IR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Function = luadec.IR.Function;

namespace luadec
{
    class Program
    {
        public static int SsaWrongcount = 0;
        public static int BlockAlreadyCodegenned = 0;
        public static int BlockNotUsed = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("CoD Havok Decompiler made from katalash's DSLuaDecompiler");

            var files = new List<string>();
            
            foreach (var arg in args)
            {
                var attr = File.GetAttributes(arg);
                // determine if we're a directory first
                // if so only includes file that are of ".lua" or ".luac" extension
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    files.AddRange(Directory.GetFiles(arg, "*.lua*", SearchOption.AllDirectories).ToList());
                }
                else if (Path.GetExtension(arg).Contains(".lua"))
                {
                    files.Add(arg);
                }
                else
                {
                    Console.WriteLine($"Invalid argument passed {arg} | {File.GetAttributes(arg)}!");
                }
            }
            
            // make sure to remove duplicates
            files = files.Distinct().ToList();
            // also remove any already dumped files
            files.RemoveAll(elem => elem.EndsWith(".dec.lua"));

            // if we ever want to pursue directory structure
            //if (!Directory.Exists("output"))
            //{
            //    Directory.CreateDirectory("output");
            //}

            Console.WriteLine($"Total of {files.Count} to process.");
            var count = 0;
            var errors = 0; // TODO: ??
            foreach (var filePath in files)
            {
                Console.WriteLine($"Decompiling file {filePath}");

                var output = DSLuaDecompiler.LuaFileTypes.LuaFile.LoadLuaFile(filePath, new MemoryStream(File.ReadAllBytes(filePath)));

                // TODO: ??
                Function.DebugIDCounter = 0;
                Function.IndentLevel = 0;
                LuaDisassembler.SymbolTable = new SymbolTable();

                var main = new IR.Function();

                output.GenerateIR(main, output.MainFunction);

                //var outputPath = Path.GetFileNameWithoutExtension(filePath) + ".dec.lua";
                //var outputPath = Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(filePath) + ".dec.lua";

                var outputPath = "Out" + Path.DirectorySeparatorChar + Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar;
                var outputName = Path.GetFileName(filePath);

                if (!Directory.Exists(Path.GetDirectoryName(outputPath)));
                {
                    Directory.CreateDirectory(outputPath);
                }

                File.WriteAllText(outputPath + outputName, main.ToString());
                count++;

                //try
                //{
                //    var output = DSLuaDecompiler.LuaFileTypes.LuaFile.LoadLuaFile(filePath, new MemoryStream(File.ReadAllBytes(filePath)));

                //    // TODO: ??
                //    Function.DebugIDCounter = 0;
                //    Function.IndentLevel = 0;
                //    LuaDisassembler.SymbolTable = new SymbolTable();

                //    var main = new IR.Function();

                //    output.GenerateIR(main, output.MainFunction);

                //    var outputPath = Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(filePath) + ".dec.lua";

                //    File.WriteAllText(outputPath, main.ToString());
                //    count++;
                //}
                //catch (Exception e)
                //{
                //    errors++;

                //    var tempColor = Console.ForegroundColor;

                //    Console.ForegroundColor = ConsoleColor.Red;
                //    Console.WriteLine($"ERROR: Decompilation Failure -- {e.Message}, no file generated.");
                //    Console.ForegroundColor = tempColor;
                //}
            }

            var prevColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Blue;
            /*Console.WriteLine($"ssaWrongcount: {SsaWrongcount}");
            Console.WriteLine($"blockAlreadyCodegenned: {BlockAlreadyCodegenned}");
            Console.WriteLine($"BlockNotUsed: {BlockNotUsed}");*/
            Console.WriteLine($"Decompilation complete! Processed {count} files with {errors} errors.");
            Console.ForegroundColor = prevColor;
        }
    }
}
