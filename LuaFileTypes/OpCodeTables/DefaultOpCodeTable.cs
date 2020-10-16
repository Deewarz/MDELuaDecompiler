﻿using System.Collections.Generic;
using DSLuaDecompiler.LuaFileTypes.Structures;

namespace DSLuaDecompiler.LuaFileTypes.OpCodeTables
{
    public class DefaultOpCodeTable
    {
        public static Dictionary<int, LuaOpCode> OpCodeTable = new Dictionary<int, LuaOpCode>()
        {
            { 0,        LuaOpCode.HKS_OPCODE_GETFIELD },
            { 1,        LuaOpCode.HKS_OPCODE_TEST },
            { 2,        LuaOpCode.HKS_OPCODE_CALL_I },
            { 3,        LuaOpCode.HKS_OPCODE_CALL_C },
            { 4,        LuaOpCode.HKS_OPCODE_EQ },
            { 5,        LuaOpCode.HKS_OPCODE_EQ_BK },
            { 6,        LuaOpCode.HKS_OPCODE_GETGLOBAL },
            { 7,        LuaOpCode.HKS_OPCODE_MOVE },
            { 8,        LuaOpCode.HKS_OPCODE_SELF },
            { 9,        LuaOpCode.HKS_OPCODE_RETURN },
            { 10,        LuaOpCode.HKS_OPCODE_GETTABLE_S },
            { 11,        LuaOpCode.HKS_OPCODE_GETTABLE_N },
            { 12,        LuaOpCode.HKS_OPCODE_GETTABLE },
            { 13,        LuaOpCode.HKS_OPCODE_LOADBOOL },
            { 14,        LuaOpCode.HKS_OPCODE_TFORLOOP },
            { 15,        LuaOpCode.HKS_OPCODE_SETFIELD },
            { 16,        LuaOpCode.HKS_OPCODE_SETTABLE_S },
            { 17,        LuaOpCode.HKS_OPCODE_SETTABLE_S_BK },
            { 18,        LuaOpCode.HKS_OPCODE_SETTABLE_N },
            { 19,        LuaOpCode.HKS_OPCODE_SETTABLE_N_BK },
            { 20,        LuaOpCode.HKS_OPCODE_SETTABLE },
            { 21,        LuaOpCode.HKS_OPCODE_SETTABLE_BK },
            { 22,        LuaOpCode.HKS_OPCODE_TAILCALL_I },
            { 23,        LuaOpCode.HKS_OPCODE_TAILCALL_C },
            { 24,        LuaOpCode.HKS_OPCODE_TAILCALL_M },
            { 25,        LuaOpCode.HKS_OPCODE_LOADK },
            { 26,        LuaOpCode.HKS_OPCODE_LOADNIL },
            { 27,        LuaOpCode.HKS_OPCODE_SETGLOBAL },
            { 28,        LuaOpCode.HKS_OPCODE_JMP },
            { 29,        LuaOpCode.HKS_OPCODE_CALL_M },
            { 30,        LuaOpCode.HKS_OPCODE_CALL },
            { 31,        LuaOpCode.HKS_OPCODE_INTRINSIC_INDEX },
            { 32,        LuaOpCode.HKS_OPCODE_INTRINSIC_NEWINDEX },
            { 33,        LuaOpCode.HKS_OPCODE_INTRINSIC_SELF },
            { 34,        LuaOpCode.HKS_OPCODE_INTRINSIC_INDEX_LITERAL },
            { 35,        LuaOpCode.HKS_OPCODE_INTRINSIC_NEWINDEX_LITERAL },
            { 36,        LuaOpCode.HKS_OPCODE_INTRINSIC_SELF_LITERAL },
            { 37,        LuaOpCode.HKS_OPCODE_TAILCALL },
            { 38,        LuaOpCode.HKS_OPCODE_GETUPVAL },
            { 39,        LuaOpCode.HKS_OPCODE_SETUPVAL },
            { 40,        LuaOpCode.HKS_OPCODE_ADD },
            { 41,        LuaOpCode.HKS_OPCODE_ADD_BK },
            { 42,        LuaOpCode.HKS_OPCODE_SUB },
            { 43,        LuaOpCode.HKS_OPCODE_SUB_BK },
            { 44,        LuaOpCode.HKS_OPCODE_MUL },
            { 45,        LuaOpCode.HKS_OPCODE_MUL_BK },
            { 46,        LuaOpCode.HKS_OPCODE_DIV },
            { 47,        LuaOpCode.HKS_OPCODE_DIV_BK },
            { 48,        LuaOpCode.HKS_OPCODE_MOD },
            { 49,        LuaOpCode.HKS_OPCODE_MOD_BK },
            { 50,        LuaOpCode.HKS_OPCODE_POW },
            { 51,        LuaOpCode.HKS_OPCODE_POW_BK },
            { 52,        LuaOpCode.HKS_OPCODE_NEWTABLE },
            { 53,        LuaOpCode.HKS_OPCODE_UNM },
            { 54,        LuaOpCode.HKS_OPCODE_NOT },
            { 55,        LuaOpCode.HKS_OPCODE_LEN },
            { 56,        LuaOpCode.HKS_OPCODE_LT },
            { 57,        LuaOpCode.HKS_OPCODE_LT_BK },
            { 58,        LuaOpCode.HKS_OPCODE_LE },
            { 59,        LuaOpCode.HKS_OPCODE_LE_BK },
            { 60,        LuaOpCode.HKS_OPCODE_CONCAT },
            { 61,        LuaOpCode.HKS_OPCODE_TESTSET },
            { 62,        LuaOpCode.HKS_OPCODE_FORPREP },
            { 63,        LuaOpCode.HKS_OPCODE_FORLOOP },
            { 64,        LuaOpCode.HKS_OPCODE_SETLIST },
            { 65,        LuaOpCode.HKS_OPCODE_CLOSE },
            { 66,        LuaOpCode.HKS_OPCODE_CLOSURE },
            { 67,        LuaOpCode.HKS_OPCODE_VARARG },
            { 68,        LuaOpCode.HKS_OPCODE_TAILCALL_I_R1 },
            { 69,        LuaOpCode.HKS_OPCODE_CALL_I_R1 },
            { 70,        LuaOpCode.HKS_OPCODE_SETUPVAL_R1 },
            { 71,        LuaOpCode.HKS_OPCODE_TEST_R1 },
            { 72,        LuaOpCode.HKS_OPCODE_NOT_R1 },
            { 73,        LuaOpCode.HKS_OPCODE_GETFIELD_R1 },
            { 74,        LuaOpCode.HKS_OPCODE_SETFIELD_R1 },
            { 75,        LuaOpCode.HKS_OPCODE_NEWSTRUCT },
            { 76,        LuaOpCode.HKS_OPCODE_DATA },
            { 77,        LuaOpCode.HKS_OPCODE_SETSLOTN },
            { 78,        LuaOpCode.HKS_OPCODE_SETSLOTI },
            { 79,        LuaOpCode.HKS_OPCODE_SETSLOT },
            { 80,        LuaOpCode.HKS_OPCODE_SETSLOTS },
            { 81,        LuaOpCode.HKS_OPCODE_SETSLOTMT },
            { 82,        LuaOpCode.HKS_OPCODE_CHECKTYPE },
            { 83,        LuaOpCode.HKS_OPCODE_CHECKTYPES },
            { 84,        LuaOpCode.HKS_OPCODE_GETSLOT },
            { 85,        LuaOpCode.HKS_OPCODE_GETSLOTMT },
            { 86,        LuaOpCode.HKS_OPCODE_SELFSLOT },
            { 87,        LuaOpCode.HKS_OPCODE_SELFSLOTMT },
            { 88,        LuaOpCode.HKS_OPCODE_GETFIELD_MM },
            { 89,        LuaOpCode.HKS_OPCODE_CHECKTYPE_D },
            { 90,        LuaOpCode.HKS_OPCODE_GETSLOT_D },
            { 91,        LuaOpCode.HKS_OPCODE_GETGLOBAL_MEM },
            { 92,        LuaOpCode.HKS_OPCODE_MAX },
        };
    }
}