﻿﻿namespace MDELuaDecompiler.LuaFileTypes.Structures
{
    public enum LuaOpCode
    {
        HKS_OPCODE_GETFIELD,
        HKS_OPCODE_TEST,
        HKS_OPCODE_CALL_I,
        HKS_OPCODE_CALL_C,
        HKS_OPCODE_EQ,
        HKS_OPCODE_EQ_BK,
        HKS_OPCODE_GETGLOBAL,
        HKS_OPCODE_MOVE,
        HKS_OPCODE_SELF,
        HKS_OPCODE_RETURN,
        HKS_OPCODE_GETTABLE_S,
        HKS_OPCODE_GETTABLE_N,
        HKS_OPCODE_GETTABLE,
        HKS_OPCODE_LOADBOOL,
        HKS_OPCODE_TFORLOOP,
        HKS_OPCODE_SETFIELD,
        HKS_OPCODE_SETTABLE_S,
        HKS_OPCODE_SETTABLE_S_BK,
        HKS_OPCODE_SETTABLE_N,
        HKS_OPCODE_SETTABLE_N_BK,
        HKS_OPCODE_SETTABLE,
        HKS_OPCODE_SETTABLE_BK,
        HKS_OPCODE_TAILCALL_I,
        HKS_OPCODE_TAILCALL_C,
        HKS_OPCODE_TAILCALL_M,
        HKS_OPCODE_LOADK,
        HKS_OPCODE_LOADNIL,
        HKS_OPCODE_SETGLOBAL,
        HKS_OPCODE_JMP,
        HKS_OPCODE_CALL_M,
        HKS_OPCODE_CALL,
        HKS_OPCODE_INTRINSIC_INDEX,
        HKS_OPCODE_INTRINSIC_NEWINDEX,
        HKS_OPCODE_INTRINSIC_SELF,
        HKS_OPCODE_INTRINSIC_INDEX_LITERAL,
        HKS_OPCODE_INTRINSIC_NEWINDEX_LITERAL,
        HKS_OPCODE_INTRINSIC_SELF_LITERAL,
        HKS_OPCODE_TAILCALL,
        HKS_OPCODE_GETUPVAL,
        HKS_OPCODE_SETUPVAL,
        HKS_OPCODE_ADD,
        HKS_OPCODE_ADD_BK,
        HKS_OPCODE_SUB,
        HKS_OPCODE_SUB_BK,
        HKS_OPCODE_MUL,
        HKS_OPCODE_MUL_BK,
        HKS_OPCODE_DIV,
        HKS_OPCODE_DIV_BK,
        HKS_OPCODE_MOD,
        HKS_OPCODE_MOD_BK,
        HKS_OPCODE_POW,
        HKS_OPCODE_POW_BK,
        HKS_OPCODE_NEWTABLE,
        HKS_OPCODE_UNM,
        HKS_OPCODE_NOT,
        HKS_OPCODE_LEN,
        HKS_OPCODE_LT,
        HKS_OPCODE_LT_BK,
        HKS_OPCODE_LE,
        HKS_OPCODE_LE_BK,
        HKS_OPCODE_CONCAT,
        HKS_OPCODE_TESTSET,
        HKS_OPCODE_FORPREP,
        HKS_OPCODE_FORLOOP,
        HKS_OPCODE_SETLIST,
        HKS_OPCODE_CLOSE,
        HKS_OPCODE_CLOSURE,
        HKS_OPCODE_VARARG,
        HKS_OPCODE_TAILCALL_I_R1,
        HKS_OPCODE_CALL_I_R1,
        HKS_OPCODE_SETUPVAL_R1,
        HKS_OPCODE_TEST_R1,
        HKS_OPCODE_NOT_R1,
        HKS_OPCODE_GETFIELD_R1,
        HKS_OPCODE_SETFIELD_R1,
        HKS_OPCODE_NEWSTRUCT,
        HKS_OPCODE_DATA,
        HKS_OPCODE_SETSLOTN,
        HKS_OPCODE_SETSLOTI,
        HKS_OPCODE_SETSLOT,
        HKS_OPCODE_SETSLOTS,
        HKS_OPCODE_SETSLOTMT,
        HKS_OPCODE_CHECKTYPE,
        HKS_OPCODE_CHECKTYPES,
        HKS_OPCODE_GETSLOT,
        HKS_OPCODE_GETSLOTMT,
        HKS_OPCODE_SELFSLOT,
        HKS_OPCODE_SELFSLOTMT,
        HKS_OPCODE_GETFIELD_MM,
        HKS_OPCODE_CHECKTYPE_D,
        HKS_OPCODE_GETSLOT_D,
        HKS_OPCODE_GETGLOBAL_MEM,
        HKS_OPCODE_MAX,
    }
}