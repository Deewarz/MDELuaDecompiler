using System;
using System.Collections.Generic;
using System.IO;
using DSLuaDecompiler.LuaFileTypes.OpCodeTables;
using DSLuaDecompiler.LuaFileTypes.Structures;
using luadec;
using PhilLibX.IO;

namespace DSLuaDecompiler.LuaFileTypes
{
    public class LuaFileDS : LuaFile
    {
        public LuaFileDS(string filePath, BinaryReader reader) : base(filePath, reader) {}

        public override Dictionary<int, LuaOpCode> OpCodeTable => DefaultOpCodeTable.OpCodeTable;
        public override Action<luadec.IR.Function, Function> GenerateIR { get; set; } = LuaDisassembler.GenerateIRHKS;
        public override void ReadHeader()
        {
            Header = new FileHeader()
            {
                Magic = Reader.ReadChars(4).ToString(),
                LuaVersion = Reader.ReadByte(),
                CompilerVersion = Reader.ReadByte(),
                Endianness = Reader.ReadByte(),
                SizeOfInt = Reader.ReadByte(),
                SizeOfSizeT = Reader.ReadByte(),
                SizeOfInstruction = Reader.ReadByte(),
                SizeOfLuaNumber = Reader.ReadByte(),
                IntegralFlag = Reader.ReadByte(),
                GameByte = Reader.ReadByte(),
                Unknown = Reader.ReadByte(),
            };

            Header.ConstantTypeCount = Reader.ReadInt32();
            for (int i = 0; i < Header.ConstantTypeCount; i++)
            {
                Reader.ReadInt32();
                Reader.ReadInt32();
                var str = Reader.ReadNullTerminatedString();
            }
        }

        public override void ReadFunctions()
        {
            MainFunction = new Function(this);
        }

        public override void ReadFunctionHeader(Function function)
        {
            function.UpvalCount = Reader.ReadInt32();
            function.ParameterCount = Reader.ReadInt32();
            function.UsesVarArg = Reader.ReadByte() == 1;
            function.RegisterCount = Reader.ReadInt32();
            function.InstructionCount = Reader.ReadInt32();
            Reader.ReadInt32();

            // Add some padding
            int extra = 4 - (int)Reader.BaseStream.Position % 4;
            if (extra > 0 && extra < 4)
                Reader.ReadBytes(extra);
        }

        public override Instruction ReadInstruction(Function function)
        {
            var instruction = new Instruction();
            // Reading the values attached to the instruction
            // A = 8 bits
            // C = 9 bits
            // B = 8 bits
            // OpCode = 7 bits
            instruction.A = Reader.ReadByte();

            int cValue = Reader.ReadByte();
            byte bValue = Reader.ReadByte();
            if (GetBit(bValue, 0) == 1)
                instruction.ExtraCBit = true;
            instruction.C = (uint)cValue;

            instruction.B = (uint)(bValue >> 1);
            byte flagsB = Reader.ReadByte();
            if (GetBit(flagsB, 0) == 1)
                instruction.B += 128;

            //instruction.OpCode = LuaOpCode.HKS_OPCODE_UNK;
            if (OpCodeTable.TryGetValue(flagsB >> 1, out LuaOpCode opCode))
                instruction.OpCode = opCode;

            instruction.Bx = (uint)(instruction.B * 512 + instruction.C + (instruction.ExtraCBit ? 256 : 0));
            instruction.SBx = (int)(instruction.Bx - 65536 + 1);

            return instruction;
        }

        public override void ReadConstants(Function function)
        {
            function.ConstantCount = Reader.ReadInt32();
            for (int i = 0; i < function.ConstantCount; i++)
            {
                var constant = new Constant()
                {
                    Type = (ConstantType) Reader.ReadByte()
                };
                switch (constant.Type)
                {
                    case ConstantType.TBoolean:
                        constant.BoolValue = Reader.ReadByte() == 1;
                        break;
                    case ConstantType.TNumber:
                        constant.NumberValue = Math.Round(Reader.ReadSingle(), 2, MidpointRounding.ToEven);
                        break;
                    case ConstantType.TString:
                        Reader.ReadInt32(); // String length, not needed since it's null terminated
                        Reader.ReadInt32(); // Unknown, always null
                        constant.StringValue = Reader.ReadNullTerminatedUTF8String();
                        break;
                }
                function.Constants.Add(constant);
            }
        }

        public override void ReadFunctionFooter(Function function)
        {
            Reader.ReadInt64();
            
            function.LocalVarsCount = Reader.ReadInt32();
            function.UpvalCount = Reader.ReadInt32();
            
            Reader.ReadInt64();
            
            long sizeluapath = Reader.ReadInt64();
            function.Path = Reader.ReadFixedString((int)sizeluapath);
            long sizechunkname = Reader.ReadInt64();
            function.Name = Reader.ReadFixedString((int)sizechunkname);

            Reader.ReadBytes(4 * function.InstructionCount);

            for (int i = 0; i < function.LocalVarsCount; i++)
            {
                Reader.ReadUInt64();
                var local = new Local()
                {
                    Name = Reader.ReadNullTerminatedString(),
                    Start = Reader.ReadInt32(),
                    End = Reader.ReadInt32()
                };
                function.Locals.Add(local);
                if (!local.Name.StartsWith("("))
                {
                    if (!function.LocalMap.ContainsKey(local.Start))
                    {
                        function.LocalMap[local.Start] = new List<Local>();
                    }
                    function.LocalMap[local.Start].Add(local);
                }
            }

            for (int i = 0; i < function.UpvalCount; i++)
            {
                Reader.ReadUInt64();
                function.Upvalues.Add(new Upvalue()
                {
                    Name = Reader.ReadNullTerminatedString()
                });
            }

            function.SubFunctionCount = Reader.ReadInt32();
        }

        public override void ReadSubFunctions(Function function)
        {
            for (int i = 0; i < function.SubFunctionCount; i++)
            {
                function.ChildFunctions.Add(new Function(this));
            }
        }
    }
}